using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System.Reflection;

namespace Functional.Unions.Tests;

public static class AnalyzerTest
{
	public static string LocationMarkerError => GetLocationMarker(DiagnosticSeverity.Error);
	public static string LocationMarkerWarning => GetLocationMarker(DiagnosticSeverity.Warning);
	public static string LocationMarkerInfo => GetLocationMarker(DiagnosticSeverity.Info);

	private static string GetLocationMarker(DiagnosticSeverity severity)
		=> $"/*{{LOCATION_MARKER_{severity.ToString().ToUpper()}}}*/";

	public static Compilation CreateCompilation(string source, params ISourceGenerator[] sourceGenerators)
	{
		var compilation = CSharpCompilation
			.Create
			(
				"Compilation",
				new[] { CSharpSyntaxTree.ParseText(source) },
				new[] { MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location) },
				new CSharpCompilationOptions(OutputKind.ConsoleApplication)
			);


		CSharpGeneratorDriver
			.Create(sourceGenerators)
			.RunGeneratorsAndUpdateCompilation(compilation, out var outputCompilation, out _);

		return outputCompilation;
	}

	public static async Task ShouldHaveDiagnostic(this CompilationWithAnalyzers compilation, DiagnosticDescriptor descriptor, params string[] descriptionArguments)
	{
		var diagnostics = (await compilation.GetAnalyzerDiagnosticsAsync())
			.Where(diagnostic => diagnostic.Id == descriptor.Id)
			.ToArray();
		
		if (diagnostics.Length == 0)
			throw new Exception($"No diagnostic with id \"{descriptor.Id}\" found.");

		if (diagnostics.Length >= 2)
			throw new Exception($"Multiple diagnostics with id \"{descriptor.Id}\" found.");

		var location = compilation.Compilation.GetDiagnosticLocation();

		diagnostics[0].Id.Should().Be(descriptor.Id);
		diagnostics[0].GetMessage().Should().Be(String.Format(descriptor.MessageFormat.ToString(), descriptionArguments));
		diagnostics[0].Severity.Should().Be(location.Severity);
		diagnostics[0].Location.SourceTree.Should().Be(location.SyntaxTree);
		diagnostics[0].Location.SourceSpan.Should().Be(location.Span);
	}

	public static (SyntaxTree SyntaxTree, TextSpan Span, DiagnosticSeverity Severity) GetDiagnosticLocation(this Compilation compilation)
	{
		var markerBlocks = compilation
			.SyntaxTrees
			.SelectMany(tree => new[]
				{
					tree.GetLocationMarkers(DiagnosticSeverity.Error),
					tree.GetLocationMarkers(DiagnosticSeverity.Warning),
					tree.GetLocationMarkers(DiagnosticSeverity.Info)
				}
			)
			.Where(data => data.Markers.Length == 4)
			.Select(data => (data.SyntaxTree, Span: new TextSpan(data.Markers[1], data.Markers[2] - data.Markers[1]), data.Severity))
			.ToArray();

		if (markerBlocks.Length == 0)
			throw new Exception("Failed to find diagnostic marker block in compilation.");

		if (markerBlocks.Length >= 2)
			throw new Exception("Found multiple diagnostic marker blocks in compilation.");

		return markerBlocks[0];
	}

	private static (SyntaxTree SyntaxTree, int[] Markers, DiagnosticSeverity Severity) GetLocationMarkers(this SyntaxTree syntaxTree, DiagnosticSeverity severity)
		=>
		(
			syntaxTree,
			syntaxTree
				.GetCompilationUnitRoot()
				.DescendantTrivia(_ => true, false)
				.Where(t => t.IsKind(SyntaxKind.MultiLineCommentTrivia))
				.Where(c => c.ToFullString() == GetLocationMarker(severity))
				.SelectMany(c => new[] { c.Span.Start, c.Span.End })
				.OrderBy(l => l)
				.ToArray(),
			severity
		);
}
