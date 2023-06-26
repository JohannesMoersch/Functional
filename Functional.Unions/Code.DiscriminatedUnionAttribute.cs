namespace Functional.Unions;

public static partial class Code
{
	public const string DiscriminatedUnionAttribute_Namespace = "Functional";
	public const string DiscriminatedUnionAttribute_Name = "DiscriminatedUnionAttribute";
	
	public static int MaxSupportedTypes => _numbers.Count;

	private static readonly IReadOnlyList<string> _numbers = new[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };

	public static IReadOnlyList<string> DiscriminatedUnionAttribute_TypeNamePropertyNames { get; } = _numbers.Select(n => $"{n}Name").ToArray();

	public static string GetDiscriminatedUnionAttributes()
	{
		var builder = new StringBuilder();

		builder.AppendLine($"#nullable enable");
		builder.AppendLine();
		builder.AppendLine($"namespace {DiscriminatedUnionAttribute_Namespace}");
		builder.AppendLine($"{{");
		builder.AppendLine(_numbers.Select((_, i) => GetDiscriminatedUnionAttribute(i + 1)).Join(Environment.NewLine));
		builder.AppendLine($"}}");
		builder.AppendLine();
		builder.AppendLine($"#nullable disable");

		return builder.ToString();
	}

	private static string GetDiscriminatedUnionAttribute(int genericTypeParameterCount)
	{
		var numbers = _numbers.Take(genericTypeParameterCount);

		var builder = new StringBuilder();

		builder.AppendLine($"	public class {DiscriminatedUnionAttribute_Name}<{numbers.Join(", ", s => $"T{s}")}> : global::System.Attribute");
		builder.AppendLine($"	{{");
		builder.AppendLine(DiscriminatedUnionAttribute_TypeNamePropertyNames.Join($"{Environment.NewLine}{Environment.NewLine}", s => $"		public string? {s} {{ get; set; }}"));
		builder.AppendLine($"	}}");

		return builder.ToString();
	}
}
