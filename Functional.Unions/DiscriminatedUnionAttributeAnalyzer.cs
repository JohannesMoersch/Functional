using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.FindSymbols;
using System.Collections.Immutable;
using System.Threading;

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
					var discriminatedUnionInterfaceTypes = contextStart.Compilation.GetDiscriminatedUnionTypes();

					contextStart
						.RegisterSemanticModelAction
						(
							context =>
							{
								var syntaxRoot = context.SemanticModel.SyntaxTree.GetRoot(context.CancellationToken);

								foreach (var typeMatch in context.SemanticModel.GetDiscriminatedUnionTypes(syntaxRoot, discriminatedUnionInterfaceTypes, context.CancellationToken))
								{
									if (DiscriminatedUnionTypeInformation.TryCreate(typeMatch).TryGetValue(out _, out var failures))
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
								}
							}
						);
				}
			);
	}

	private object? ReportDiagnostic(SemanticModelAnalysisContext context, DiscriminatedUnionTypeInformation.ValidationFailure.DuplicateType duplicateType)
	=> ReportDiagnostic
		(
			context,
			AnalyzerDiagnosticDescriptors.DuplicateTypeInDiscriminatedUnion,
			duplicateType.TypeArgumentSyntax.Select(t => t.GetLocation()),
			duplicateType.TypeArgument.GetFullNameWithNamespace("+", false)
		);

	private object? ReportDiagnostic(SemanticModelAnalysisContext context, DiscriminatedUnionTypeInformation.ValidationFailure.DuplicateTypeName duplicateTypeName)
		=> ReportDiagnostic
		(
			context,
			AnalyzerDiagnosticDescriptors.DuplicateTypeNameInDiscriminatedUnion, 
			duplicateTypeName.TypeArgumentSyntax.Select(t => t.GetLocation()),
			duplicateTypeName.TypeName
		);

	private object? ReportDiagnostic(SemanticModelAnalysisContext context, DiagnosticDescriptor descriptor, IEnumerable<Location> locations, params object?[] messageArguments)
	{
		var locationArray = locations.ToArray();

		if (locationArray.Any())
		{
			context
				.ReportDiagnostic
				(
					Diagnostic.Create
					(
						descriptor,
						locationArray[0],
						locationArray.Skip(1),
						messageArguments
					)
				);
		}

		return null;
	}
}
