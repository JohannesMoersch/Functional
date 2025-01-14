using System.Collections;
using System.Collections.Frozen;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Functional.Tests;

public partial class GenerateEnumerableExtensionsTests
{

	[GeneratedRegex("\\[Theory\\]\\s*(?:\\[[\\w\\.<,>\\s]+\\]\\s*)*public\\s+Task\\s+(?<method>[\\w]+?)(?:(?:With|And)(?<parameters>[\\w]+?))*\\s*\\([\\w\\.<,>\\s]+\\)")]
	private static partial Regex GetMethodExtractionRegex();

	[Fact(Explicit = true)]
	public void GenerateTests()
	{
		var expectedMethods = MethodSignature
			.GetExpectedFunctionalEnumerableExtensions()
			.GroupBy(m => m.MethodName)
			.ToFrozenDictionary
			(
				g => g.Key, 
				g => g.ToArray()
			);

		var testSourcePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../EnumerableExtensionsTests");
		var testFiles = Directory
			.GetFiles(testSourcePath, "*Tests.cs")
			.Select(path => 
				(
					methodName: Regex.Replace(Path.GetFileName(path), "Tests\\.cs$", ""), 
					filePath: GetMethodExtractionRegex().Matches(File.ReadAllText(path))
				)
			)
			.ToFrozenDictionary(f => f.methodName, f => f.filePath);
	}
}
