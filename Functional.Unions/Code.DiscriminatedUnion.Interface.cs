namespace Functional.Unions;

public static partial class Code
{
	public static partial class DiscriminatedUnion
	{
		public static class Interface
		{
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

				builder.AppendLine($"	internal interface {Name}<{numbers.Join(", ", s => $"T{s}")}>");
				builder.AppendLine($"	{{");
				builder.Append($"	}}");

				return builder.ToString();
			}
		}
	}
}
