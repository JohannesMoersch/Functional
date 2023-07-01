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

						[{AnalyzerTest.LocationMarkerError}DiscriminatedUnion<Blah, Other, Blah>{AnalyzerTest.LocationMarkerError}]
						public partial record TestUnion;
					}}",
				new DiscriminatedUnionAttributeGenerator()
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

					[{AnalyzerTest.LocationMarkerError}DiscriminatedUnion<Blah, Other, TestOne.Other>{AnalyzerTest.LocationMarkerError}]
					public partial record TestUnion;
				}}",
				new DiscriminatedUnionAttributeGenerator()
			)
			.WithAnalyzers(new DiscriminatedUnionAttributeAnalyzer())
			.ShouldHaveDiagnostic
			(
				AnalyzerDiagnosticDescriptors.DuplicateTypeNameInDiscriminatedUnion,
				"Other"
			);
}
