using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using static Functional.Unions.Code;

namespace Functional.Unions;

public record DiscriminatedUnionTypeInformation(INamedTypeSymbol UnionType, INamedTypeSymbol[] Types)
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
	public static Result<DiscriminatedUnionTypeInformation, ValidationFailure[]> TryCreate(INamedTypeSymbol type, IImmutableSet<INamedTypeSymbol> discriminatedUnionAttributes)
	{
		if (!TryGetDiscriminatedUnionAttributeData(type, discriminatedUnionAttributes, out var attributeData))
			return new[] { new ValidationFailure.NoDiscriminatedUnionAttribute(type) };

		var failures = Validate(type, attributeData).ToArray();

		if (failures.Any())
			return failures;

		return new DiscriminatedUnionTypeInformation(type, attributeData.AttributeClass.TypeArguments.OfType<INamedTypeSymbol>().ToArray());
	}
#pragma warning restore CS8602 // Dereference of a possibly null reference.

	private static IEnumerable<ValidationFailure> Validate(INamedTypeSymbol type, AttributeData attributeData)
	{
		if (attributeData.AttributeClass is null)
		{
			yield return new ValidationFailure.AttributeClassNull(type, attributeData);
			yield break;
		}

		foreach (var typeArgument in attributeData.AttributeClass.TypeArguments.Where(t => t is not INamedTypeSymbol))
			yield return new ValidationFailure.UnrecognizedType(type, attributeData, typeArgument);

		var typeArguments = attributeData.AttributeClass.TypeArguments.OfType<INamedTypeSymbol>().ToArray();

		foreach (var group in typeArguments.GroupBy<INamedTypeSymbol, INamedTypeSymbol>(_ => _, SymbolEqualityComparer.Default).Where(g => g.Count() >= 2))
			yield return new ValidationFailure.DuplicateType(type, attributeData, group.Key);

		foreach (var group in typeArguments.Distinct<INamedTypeSymbol>(SymbolEqualityComparer.Default).GroupBy(t => t.Name).Where(g => g.Count() >= 2))
			yield return new ValidationFailure.DuplicateTypeName(type, attributeData, group.Key, group.ToArray());
	}

	private static bool TryGetDiscriminatedUnionAttributeData(INamedTypeSymbol typeSymbol, IImmutableSet<INamedTypeSymbol> discriminatedUnionAttributes, out AttributeData attributeData)
		=> typeSymbol
			.GetAttributes()
			.TryGetFirst(att => att.AttributeClass is not null && discriminatedUnionAttributes.Contains(att.AttributeClass.ConstructedFrom), out attributeData);

	public record ValidationFailure
	{
		public interface IHasAttribute
		{
			INamedTypeSymbol Type { get; } 
			AttributeData DiscrimiantedUnionAttribute { get; }
		}

		public record NoDiscriminatedUnionAttribute(INamedTypeSymbol Type) : ValidationFailure;

		public record AttributeClassNull(INamedTypeSymbol Type, AttributeData DiscrimiantedUnionAttribute) : ValidationFailure, IHasAttribute;

		public record UnrecognizedType(INamedTypeSymbol Type, AttributeData DiscrimiantedUnionAttribute, ITypeSymbol TypeArgument) : ValidationFailure, IHasAttribute;

		public record DuplicateType(INamedTypeSymbol Type, AttributeData DiscrimiantedUnionAttribute, INamedTypeSymbol TypeArgument) : ValidationFailure, IHasAttribute;

		public record DuplicateTypeName(INamedTypeSymbol Type, AttributeData DiscrimiantedUnionAttribute, string TypeName, INamedTypeSymbol[] TypeArguments) : ValidationFailure, IHasAttribute;
	}
}
