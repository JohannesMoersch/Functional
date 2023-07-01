using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace Functional.Unions;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class DiscriminatedUnionAttributeAnalyzer : DiagnosticAnalyzer
{
	public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
		=> ImmutableArray
			.Create
			(
				AnalyzerDiagnosticDescriptors.DuplicateTypeInDiscriminatedUnion,
				AnalyzerDiagnosticDescriptors.DuplicateTypeNameInDiscriminatedUnion
			);

	public override void Initialize(AnalysisContext context)
	{
		context.EnableConcurrentExecution();

		context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze);

		context
			.RegisterCompilationStartAction
			(
				contextStart =>
				{
					var discriminatedUnionAttributes = contextStart.Compilation.GetDiscriminatedUnionTypes();

					contextStart
						.RegisterSymbolAction
						(
							context =>
							{
								if (context.Symbol is not INamedTypeSymbol namedTypeSymbol)
									return;

								if (DiscriminatedUnionTypeInformation.TryCreate(namedTypeSymbol, discriminatedUnionAttributes).TryGetValue(out _, out var failures))
									return;

								foreach (var failure in failures)
								{
									var _ =
									failure switch
									{
										DiscriminatedUnionTypeInformation.ValidationFailure.DuplicateType duplicateType => ReportDiagnostic(context, duplicateType),
										DiscriminatedUnionTypeInformation.ValidationFailure.DuplicateTypeName duplicateTypeName => ReportDiagnostic(context, duplicateTypeName),
										_ => null
									};
								}
							},
							SymbolKind.NamedType
						);
				}
			);
	}

	private object? ReportDiagnostic(SymbolAnalysisContext context, DiscriminatedUnionTypeInformation.ValidationFailure.DuplicateType duplicateType)
		=> ReportDiagnostic
		(
			context,
			AnalyzerDiagnosticDescriptors.DuplicateTypeInDiscriminatedUnion,
			duplicateType,
			duplicateType.TypeArgument.GetFullNameWithNamespace("+", false)
		);

	private object? ReportDiagnostic(SymbolAnalysisContext context, DiscriminatedUnionTypeInformation.ValidationFailure.DuplicateTypeName duplicateTypeName)
		=> ReportDiagnostic
		(
			context, 
			AnalyzerDiagnosticDescriptors.DuplicateTypeNameInDiscriminatedUnion, 
			duplicateTypeName, 
			duplicateTypeName.TypeName
		);

	private object? ReportDiagnostic(SymbolAnalysisContext context, DiagnosticDescriptor descriptor, DiscriminatedUnionTypeInformation.ValidationFailure.IHasAttribute attribute, params object?[] messageArguments)
	{
		if (attribute.DiscrimiantedUnionAttribute.ApplicationSyntaxReference is SyntaxReference syntaxReference)
		{
			context
				.ReportDiagnostic
				(
					Diagnostic.Create
					(
						descriptor,
						Location.Create(syntaxReference.SyntaxTree, syntaxReference.Span),
						messageArguments
					)
				);
		}

		return null;
	}
}
