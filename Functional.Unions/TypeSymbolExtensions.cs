using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading;

namespace Functional.Unions;

internal static class TypeSymbolExtensions
{
	private static Dictionary<string, string> _primitiveMapping = new Dictionary<string, string>()
	{
		{ "System.Boolean", "bool" },
		{ "System.Byte", "byte" },
		{ "System.SByte", "sbyte" },
		{ "System.Char", "char" },
		{ "System.Decimal", "decimal" },
		{ "System.Double", "double" },
		{ "System.Single", "float" },
		{ "System.Int32", "int" },
		{ "System.UInt32", "uint" },
		{ "System.Int64", "long" },
		{ "System.UInt64", "ulong" },
		{ "System.Int16", "short" },
		{ "System.UInt16", "ushort" },
		{ "System.Object", "object" },
		{ "System.String", "string" }
	};

	public static bool TryGetPrivateOrProtectedParameterlessConstructor(this INamedTypeSymbol typeSymbol, out IMethodSymbol constructor)
		=> typeSymbol.InstanceConstructors.TryGetFirst(m => !m.Parameters.Any(), out constructor) && !constructor.DeclaredAccessibility.IsAccessibleInternally();

	public static bool HasPrivateOrProtectedParameterlessConstructor(this INamedTypeSymbol typeSymbol)
		=> typeSymbol.TryGetPrivateOrProtectedParameterlessConstructor(out _);

	public static IEnumerable<ITypeSymbol> GetGenericParents(this INamedTypeSymbol typeSymbol)
		=> (typeSymbol.ContainingType?.GetContainingTypeHierarchy() ?? Enumerable.Empty<ITypeSymbol>())
			.Where(t => t is INamedTypeSymbol namedType && namedType.TypeParameters.Any());

	public static bool HasGenericParents(this INamedTypeSymbol typeSymbol)
		=> typeSymbol
			.GetGenericParents()
			.Any();

	public static IEnumerable<ITypeSymbol> GetContainingTypeHierarchy(this ITypeSymbol type)
	{
		if (type.ContainingType != null)
			foreach (var t in type.ContainingType.GetContainingTypeHierarchy())
				yield return t;
		yield return type;
	}

	public static IEnumerable<ITypeSymbol> GetBaseTypeHierarchy(this ITypeSymbol type)
	{
		if (type.BaseType != null)
			foreach (var t in type.BaseType.GetBaseTypeHierarchy())
				yield return t;
		yield return type;
	}

	public static IEnumerable<INamedTypeSymbol> GetContainingTypeHierarchy(this INamedTypeSymbol type)
	{
		if (type.ContainingType != null)
			foreach (var t in type.ContainingType.GetContainingTypeHierarchy())
				yield return t;
		yield return type;
	}

	public static IEnumerable<INamedTypeSymbol> GetBaseTypeHierarchy(this INamedTypeSymbol type)
	{
		if (type.BaseType != null)
			foreach (var t in type.BaseType.GetBaseTypeHierarchy())
				yield return t;
		yield return type;
	}

	public static IEnumerable<TypeDeclarationSyntax> GetDeclaringSyntaxReferences(this ITypeSymbol typeSymbol, CancellationToken cancellationToken)
		=> typeSymbol
			.DeclaringSyntaxReferences
			.Select(s => s.GetSyntax(cancellationToken))
			.OfType<TypeDeclarationSyntax>();

	public static bool IsDerivedFrom(this ITypeSymbol symbol, INamedTypeSymbol attributeTypeSymbol)
	{
		if (symbol.Equals(attributeTypeSymbol, SymbolEqualityComparer.Default))
			return true;

		if (symbol.BaseType != null)
			return symbol.BaseType.IsDerivedFrom(attributeTypeSymbol);

		return false;
	}

	public static string GetFullNameWithNamespace(this ITypeSymbol typeSymbol, string classSeparator, bool prefixWithGlobal)
	{
		if (typeSymbol is ITypeParameterSymbol typeParameterSymbol)
			return typeParameterSymbol.Name;

		var ns = typeSymbol.GetFullNamespace();
		var typeName = String.Join(classSeparator, typeSymbol.GetContainingTypeHierarchy().Select(t => t.Name));

		if (String.IsNullOrEmpty(ns))
			return typeName;

		var name = $"{ns}.{typeName}";

		if (_primitiveMapping.TryGetValue(name, out var primitiveName))
			return primitiveName;

		return prefixWithGlobal
			? $"global::{name}"
			: name;
	}

	public static string GetFullNamespace(this ITypeSymbol typeSymbol)
		=> typeSymbol.ContainingNamespace.GetFullNamespace();

	private static string GetFullNamespace(this INamespaceSymbol namespaceSymbol)
		=> namespaceSymbol.ContainingNamespace != null && !namespaceSymbol.ContainingNamespace.IsGlobalNamespace
			? $"{namespaceSymbol.ContainingNamespace.GetFullNamespace()}.{namespaceSymbol.Name}"
			: namespaceSymbol.Name;

	public static IEnumerable<IFieldSymbol> GetFields(this ITypeSymbol typeSymbol)
		=> typeSymbol
			.GetMembers()
			.OfType<IFieldSymbol>();

	public static IEnumerable<IPropertySymbol> GetProperties(this ITypeSymbol typeSymbol)
		=> typeSymbol
			.GetMembers()
			.OfType<IPropertySymbol>();

	public static string ToCSharpTypeCode(this ITypeSymbol typeSymbol)
		=> $"{typeSymbol.GetFullNameWithNamespace(".", true)}{typeSymbol.ToCSharpGenericArgumentCode()}{(typeSymbol.NullableAnnotation == NullableAnnotation.Annotated ? "?" : String.Empty)}";

	public static string ToCSharpGenericArgumentCode(this ITypeSymbol typeSymbol)
	{
		if (typeSymbol is INamedTypeSymbol namedTypeSymbol)
		{
			var parameterNames = namedTypeSymbol
				.TypeArguments
				.Select(type => type.ToCSharpTypeCode())
				.ToArray();

			return parameterNames.Any() ? $"<{String.Join(", ", parameterNames)}>" : String.Empty;
		}

		return String.Empty;
	}
}
