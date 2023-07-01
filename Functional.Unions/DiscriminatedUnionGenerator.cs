namespace Functional.Unions;

[Generator]
public sealed class DiscriminatedUnionGenerator : ISourceGenerator
{
	public void Initialize(GeneratorInitializationContext context)
		=> context.RegisterForSyntaxNotifications(() => new DiscriminatedUnionSyntaxReceiver());

	public void Execute(GeneratorExecutionContext context)
	{
		// Restrict attribute to types and don't allow multiple

		if (context.SyntaxReceiver is not DiscriminatedUnionSyntaxReceiver syntaxReceiver)
			return;

		var discriminatedUnionAttributes = context.Compilation.GetDiscriminatedUnionTypes();

		foreach (var candidate in syntaxReceiver.Candidates)
		{
			var semanticModel = context
				.Compilation
				.GetSemanticModel(candidate.SyntaxTree);

			var typeSymbol = semanticModel.GetDeclaredSymbol(candidate, context.CancellationToken);

			if (typeSymbol is not INamedTypeSymbol namedTypeSymbol)
				continue;

			var result = DiscriminatedUnionTypeInformation.TryCreate(namedTypeSymbol, discriminatedUnionAttributes);

			if (!result.TryGetValue(out var success, out _))
				continue;

			context.AddSource($"{namedTypeSymbol.Name}.g.cs", Code.DiscriminatedUnion.GetCode(namedTypeSymbol, success.Types));
		}
	}
}
