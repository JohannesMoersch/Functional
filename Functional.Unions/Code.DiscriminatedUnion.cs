namespace Functional.Unions;

public static partial class Code
{
	public static string GetDiscriminatedUnion(INamedTypeSymbol unionType, INamedTypeSymbol[] types, string?[] typeNames)
	{
		var builder = new StringBuilder();

		builder.AppendLine($"#nullable enable");
		builder.AppendLine();
		builder.AppendLine($"namespace {unionType.GetFullNamespace()}");
		builder.AppendLine($"{{");
		builder.AppendLine($"	public abstract partial {unionType.GetTypeKindCodeString()} {unionType.Name}");
		builder.AppendLine($"	{{");
		builder.AppendLine(types.Select((t, i) => GetNestedType(unionType, t, typeNames[i])).Join(Environment.NewLine));
		builder.AppendLine($"	}}");
		builder.AppendLine($"}}");
		builder.AppendLine();
		builder.AppendLine($"#nullable disable");

		return builder.ToString();
	}

	private static string GetNestedType(INamedTypeSymbol unionType, INamedTypeSymbol nestedType, string? overrideName)
	{
		var builder = new StringBuilder();

		builder.AppendLine($"		public sealed record {overrideName ?? nestedType.Name} : {unionType}");
		builder.AppendLine($"		{{");
		builder.AppendLine($"		}}");

		return builder.ToString();
	}
}
