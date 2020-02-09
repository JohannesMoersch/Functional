const path = require("path"),
    spawnSync = require("child_process").spawnSync,
    fs = require("fs"),
    https = require("https")

class Action {
    constructor() {
        this.PROJECTS = process.env.INPUT_PROJECTS
        this.GITHUB_TOKEN = process.env.INPUT_GITHUB_TOKEN
        this.NUGET_KEY = process.env.INPUT_NUGET_KEY
    }

    LogWarning(msg) {
        console.log(`##[warning]${msg}`)
    }

    LogFailure(msg) {
        console.log(`##[error]${msg}`)
        throw new Error(msg)
    }

    ExecuteCommand(cmd, options) {
        var input = cmd.split(" ")
        var tool = input[0]
        var args = input.slice(1)
        return spawnSync(tool, args, options)
    }

    ExecuteCommandAndCapture(cmd) {
        return this.ExecuteCommand(cmd, { encoding: "utf-8" }).stdout
    }

    ExecuteCommandInProcess(cmd) {
        this.ExecuteCommand(cmd, { encoding: "utf-8", stdio: [process.stdin, process.stdout, process.stderr] })
    }

    ResolveIfExists(filePath, msg) {
        var fullPath = path.resolve(process.env.GITHUB_WORKSPACE, filePath)
        if (!fs.existsSync(fullPath)) 
            this.LogFailure(msg)
        return fullPath
    }

    PushPackage(project, projectFilePath, version) {
        this.ExecuteCommandInProcess(`dotnet pack -c Release ${projectFilePath} -o .`)
        
        var nugetPushResponse = ""// this.ExecuteCommandAndCapture(`dotnet nuget push ${project}.${version}.nupkg -s https://api.nuget.org/v3/index.json -k ${this.NUGET_KEY}`)
        var nugetErrorRegex = /(error: Response status code does not indicate success.*)/

        if (nugetErrorRegex.test(nugetPushResponse)) {
            this.LogFailure(`${nugetErrorRegex.exec(nugetPushResponse)[1]}`)
        } else {
            console.log(`${project} successfully published.`)
        }
    }

    PublishPackage(project, version) {
        var projectFilePath = this.ResolveIfExists(project + "/" + project + ".csproj", project + " project file not found.")

        var fileContent = fs.readFileSync(projectFilePath, { encoding: "utf-8" })

        var titleInfo = new RegExp("<Title>(.*)<\/Title>").exec(fileContent)

        if (!titleInfo)
            this.LogFailure("Unable to extract package title.")

        https.get(`https://api.nuget.org/v3-flatcontainer/${titleInfo[1]}/index.json`, res => {
            let body = ""

            if (res.statusCode == 404)
                this.LogWarning(`${project} could not be found on nuget.org.`)

            if (res.statusCode == 200) {
                res.setEncoding("utf8")
                res.on("data", chunk => body += chunk)
                res.on("end", () => {
                    if (JSON.parse(body).versions.indexOf(version) < 0) {
                        this.PushPackage(project, projectFilePath, version)
                    } else {
                        this.LogWarning(`${project} v${version} already on nuget.org`)
                    }
                })
            }
        }).on("error", e => {
            this.LogWarning(`Could not reach nuget.org: ${e.message}`)
        })
    }

    TagRepository(version) {
        var tag = `v${version}`

        if (this.ExecuteCommandAndCapture(`git ls-remote --tags origin ${tag}`).indexOf(tag) >= 0) {
            console.log(`Tag ${tag} already exists.`)
            return false
        }

        this.ExecuteCommand("git config user.name \"$(git --no-pager log --format=format:'%an' -n 1)\"")
        this.ExecuteCommand("git config user.email \"$(git --no-pager log --format=format:'%ae' -n 1)\"")

        this.ExecuteCommandInProcess(`git tag ${tag}`, { encoding: "utf-8" })
        this.ExecuteCommandInProcess(`git push https://${process.env.GITHUB_ACTOR}:${this.GITHUB_TOKEN}@github.com/${process.env.GITHUB_REPOSITORY}.git ${tag}`, { encoding: "utf-8" })

        console.log(`Tag ${tag} created.`)

        return true;
    }

    run() {
        if (!this.NUGET_KEY) {
            this.LogWarning("NUGET_KEY was not provided")
            return
        }

        if (!this.ExecuteCommandAndCapture("dotnet --version")) {
            this.LogWarning("dotnet not found.")
            return
        }

        var versionFilePath = this.ResolveIfExists("Directory.Build.props", "Version file not found.")

        var fileContent = fs.readFileSync(versionFilePath, { encoding: "utf-8" })
        
        var versionInfo = new RegExp("<Version>(.*)<\/Version>").exec(fileContent)

        if (!versionInfo)
            this.LogFailure("Unable to extract version information.")

        if (this.TagRepository(versionInfo[1])) {
            this.PROJECTS.split(" ").forEach(project => {
                this.PublishPackage(project, versionInfo[1])
            })
        }
    }
}

new Action().run()