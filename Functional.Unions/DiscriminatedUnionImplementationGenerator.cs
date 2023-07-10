using Microsoft.CodeAnalysis;

namespace Functional.Unions;

[Generator]
public sealed class DiscriminatedUnionImplementationGenerator : ISourceGenerator
{
	public void Initialize(GeneratorInitializationContext context)
		=> context.RegisterForSyntaxNotifications(() => new DiscriminatedUnionSyntaxReceiver());

	public void Execute(GeneratorExecutionContext context)
	{
		// Restrict attribute to types and don't allow multiple

		if (context.SyntaxReceiver is not DiscriminatedUnionSyntaxReceiver syntaxReceiver)
			return;

		var discriminatedUnionInterfaceTypes = context.Compilation.GetDiscriminatedUnionTypes();

		foreach (var candidate in syntaxReceiver.Candidates)
		{
			var typeMatches = context
				.Compilation
				.GetSemanticModel(candidate.SyntaxTree)
				.GetDiscriminatedUnionTypes(candidate, discriminatedUnionInterfaceTypes, context.CancellationToken);

			foreach (var typeMatch in typeMatches)
			{
				if (!DiscriminatedUnionTypeInformation.TryCreate(typeMatch).TryGetValue(out var success, out _))
					continue;
				
				context.AddSource($"{success.UnionType.Name}.g.cs", Code.DiscriminatedUnion.Implementation.GetCode(success.UnionType, success.ArgumentTypes));
			}
		}
	}
}
