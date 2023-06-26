namespace Functional.Unions
{
	public static class NamedTypeSymbolExtensions
	{
		public static string GetTypeKindCodeString(this INamedTypeSymbol typeSymbol)
			=> typeSymbol.TypeKind switch
			{
				TypeKind.Struct => typeSymbol.IsRecord ? "record struct" : "struct",
				TypeKind.Interface => "interface",
				_ => typeSymbol.IsRecord ? "record" : "class"
			};
	}
}
