using System.Collections.Immutable;

namespace Functional.Unions.Tests;

public static class CompilationExtensions
{
	public static CompilationWithAnalyzers WithAnalyzers(this Compilation compilation, params DiagnosticAnalyzer[] analyzers)
		=> compilation
		.WithAnalyzers(ImmutableArray.Create(analyzers));
}
