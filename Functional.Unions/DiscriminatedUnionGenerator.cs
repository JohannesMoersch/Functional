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

		var discriminatedUnionAttributes = GetDiscriminatedUnionTypes(context.Compilation);

		foreach (var candidate in syntaxReceiver.Candidates)
		{
			var semanticModel = context
				.Compilation
				.GetSemanticModel(candidate.SyntaxTree);

			var typeSymbol = semanticModel.GetDeclaredSymbol(candidate, context.CancellationToken);

			if (typeSymbol is not INamedTypeSymbol namedTypeSymbol)
				continue;

			int typeCount = 0;
			if (!namedTypeSymbol.GetAttributes().TryGetFirst(att => att.AttributeClass is not null && discriminatedUnionAttributes.TryGetValue(att.AttributeClass.ConstructedFrom, out typeCount), out var attribute) || attribute.AttributeClass == null)
				continue;

			if (attribute.AttributeClass.TypeArguments.Any(s => s is not INamedTypeSymbol))
				continue;

			var typeSymbols = attribute.AttributeClass.TypeArguments.Cast<INamedTypeSymbol>().ToArray();

			context.AddSource($"{namedTypeSymbol.Name}.g.cs", Code.GetDiscriminatedUnion(namedTypeSymbol, typeSymbols));
		}
	}

	private IReadOnlyDictionary<INamedTypeSymbol, int> GetDiscriminatedUnionTypes(Compilation compilation)
		=> Enumerable
			.Range(1, Code.MaxSupportedTypes)
			.Select(i => (Key: compilation.Assembly.GetTypeByMetadataName($"{Code.DiscriminatedUnionAttribute_Namespace}.{Code.DiscriminatedUnionAttribute_Name}`{i}") ?? throw new Exception("Couldn't find discriminated union attribute type."), Value: i))
			.ToDictionary<(INamedTypeSymbol Key, int Value), INamedTypeSymbol, int>(kvp => kvp.Key, kvp => kvp.Value, SymbolEqualityComparer.Default);
}
