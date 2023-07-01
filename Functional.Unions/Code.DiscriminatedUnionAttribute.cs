namespace Functional.Unions;

public static partial class Code
{
	public static class DiscriminatedUnionAttribute
	{
		public const string Namespace = "Functional";
		public const string Name = "DiscriminatedUnionAttribute";

		public static int MaxSupportedTypes => _numbers.Count;

		private static readonly IReadOnlyList<string> _numbers = new[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };

		public static string GetCode()
		{
			var builder = new StringBuilder();

			builder.AppendLine($"#nullable enable");
			builder.AppendLine();
			builder.AppendLine($"namespace {Namespace}");
			builder.AppendLine($"{{");
			builder.AppendLine(_numbers.Select((_, i) => GetCode(i + 1)).Join($"{Environment.NewLine}{Environment.NewLine}"));
			builder.AppendLine($"}}");
			builder.AppendLine();
			builder.AppendLine($"#nullable disable");

			return builder.ToString();
		}

		private static string GetCode(int genericTypeParameterCount)
		{
			var numbers = _numbers.Take(genericTypeParameterCount);

			var builder = new StringBuilder();

			builder.AppendLine($"	[global::System.AttributeUsage(global::System.AttributeTargets.Class, AllowMultiple = false)]");
			builder.AppendLine($"	internal class {Name}<{numbers.Join(", ", s => $"T{s}")}> : global::System.Attribute");
			builder.AppendLine($"	{{");
			builder.Append($"	}}");

			return builder.ToString();
		}
	}
}
