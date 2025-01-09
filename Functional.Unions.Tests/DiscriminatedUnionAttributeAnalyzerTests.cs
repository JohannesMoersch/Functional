namespace Functional.Unions.Tests;

public class DiscriminatedUnionAttributeAnalyzerTests
{
	[Fact]
	public Task ShouldReportDuplicateTypeAsError()
		=> AnalyzerTest
			.CreateCompilation($@"
					using Functional;

					namespace Test
					{{
						public record struct Blah;
						public record struct Other;

						public partial record TestUnion : DiscriminatedUnion<Blah, Other, {AnalyzerTest.LocationMarkerError}Blah{AnalyzerTest.LocationMarkerError}>;
					}}",
				new DiscriminatedUnionInterfaceGenerator()
			)
			.WithAnalyzers(new DiscriminatedUnionAttributeAnalyzer())	
			.ShouldHaveDiagnostic
			(
				AnalyzerDiagnosticDescriptors.DuplicateTypeInDiscriminatedUnion,
				"Test.Blah"
			);

	[Fact]
	public Task ShouldReportDuplicateTypeNameAsError()
		=> AnalyzerTest
			.CreateCompilation($@"
				using Functional;

				namespace TestOne
				{{
					public record struct Other;
				}}

				namespace TestTwo
				{{
					public record struct Blah;
					public record struct Other;

					public partial record TestUnion : DiscriminatedUnion<Blah, Other, {AnalyzerTest.LocationMarkerError}TestOne.Other{AnalyzerTest.LocationMarkerError}>;
				}}",
				new DiscriminatedUnionInterfaceGenerator()
			)
			.WithAnalyzers(new DiscriminatedUnionAttributeAnalyzer())
			.ShouldHaveDiagnostic
			(
				AnalyzerDiagnosticDescriptors.DuplicateTypeNameInDiscriminatedUnion,
				"Other"
			);
}
