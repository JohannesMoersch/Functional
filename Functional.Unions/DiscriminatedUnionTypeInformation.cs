namespace Functional.Unions;

public record DiscriminatedUnionTypeInformation(INamedTypeSymbol UnionType, INamedTypeSymbol[] ArgumentTypes)
{
	public static Result<DiscriminatedUnionTypeInformation, ValidationFailure[]> TryCreate(SemanticModelExtensions.DerivedTypeMatch typeMatch)
	{
		var failures = Validate(typeMatch).ToArray();

		if (failures.Any())
			return failures;

		return new DiscriminatedUnionTypeInformation(typeMatch.DiscriminatedUnion, typeMatch.DiscriminatedUnionInterfaceTypeArguments.Select(t => t.TypeSymbol).OfType<INamedTypeSymbol>().ToArray());
	}

	private static IEnumerable<ValidationFailure> Validate(SemanticModelExtensions.DerivedTypeMatch typeMatch)
	{
		var unionTypeInfo = new ValidationFailure.DiscriminatedUnionTypeInfo(typeMatch.DiscriminatedUnionSyntaxNode, typeMatch.DiscriminatedUnionInterfaceSyntaxNode);

		foreach (var typeArgument in typeMatch.DiscriminatedUnionInterfaceTypeArguments.Where(argument => argument.TypeSymbol is not INamedTypeSymbol))
			yield return new ValidationFailure.UnrecognizedType(unionTypeInfo, typeArgument.SyntaxNode);

		foreach (var group in typeMatch
			.DiscriminatedUnionInterfaceTypeArguments
			.GroupBy(type => type.TypeSymbol, SymbolEqualityComparer.Default)
			.Where(g => g.Count() >= 2)
		)
		{
			if (group.Key is INamedTypeSymbol typeSymbol)
				yield return new ValidationFailure.DuplicateType(unionTypeInfo, typeSymbol, group.Select(t => t.SyntaxNode).SwapFirstAndSecondItems().ToArray());
		}

		foreach (var group in typeMatch
			.DiscriminatedUnionInterfaceTypeArguments
			.GroupBy(argument => argument.TypeSymbol?.Name)
			.Where(g => g.Count() >= 2)
		)
		{
			if (group.Key is string name && group.Select(argument => argument.TypeSymbol).Distinct(SymbolEqualityComparer.Default).Count() > 1)
				yield return new ValidationFailure.DuplicateTypeName(unionTypeInfo, name, group.Select(t => t.SyntaxNode).SwapFirstAndSecondItems().ToArray());
		}
	}

	public record ValidationFailure
	{
		public record DiscriminatedUnionTypeInfo(TypeDeclarationSyntax SyntaxNode, GenericNameSyntax InterfaceSyntaxNode);

		public record UnrecognizedType(DiscriminatedUnionTypeInfo DiscriminatedUnion, TypeSyntax TypeArgumentSyntax) : ValidationFailure;

		public record DuplicateType(DiscriminatedUnionTypeInfo DiscriminatedUnion, INamedTypeSymbol TypeArgument, IReadOnlyList<TypeSyntax> TypeArgumentSyntax) : ValidationFailure;

		public record DuplicateTypeName(DiscriminatedUnionTypeInfo DiscriminatedUnion, string TypeName, IReadOnlyList<TypeSyntax> TypeArgumentSyntax) : ValidationFailure;
	}
}
