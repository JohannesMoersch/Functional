namespace Functional.Unions;

public static partial class Code
{
	public static string GetDiscriminatedUnion(INamedTypeSymbol unionType, INamedTypeSymbol[] types)
	{
		var builder = new StringBuilder();

		builder.AppendLine($"#nullable enable");
		builder.AppendLine();
		builder.AppendLine($"namespace {unionType.GetFullNamespace()}");
		builder.AppendLine($"{{");
		builder.AppendLine($"	public abstract partial {unionType.GetTypeKindCodeString()} {unionType.Name}");
		builder.AppendLine($"	{{");
		builder.AppendLine(DiscriminatedUnion_GetNestedTypes(unionType, types));
		builder.AppendLine($"		");
		builder.AppendLine($"		private {unionType.Name}() {{ }}");
		builder.AppendLine($"		");
		builder.AppendLine($"		public abstract T Match<T>({DiscriminatedUnion_GetMatchParameters(types)});");
		builder.AppendLine($"		");
		builder.AppendLine(DiscriminatedUnion_GetCreateMethods(unionType, types));
		builder.AppendLine($"		");
		builder.AppendLine(DiscriminatedUnion_CreateByImplicitCasts(unionType, types));
		builder.AppendLine($"	}}");
		builder.AppendLine($"}}");
		builder.AppendLine();
		builder.Append($"#nullable disable");

		return builder.ToString();
	}

	private static string DiscriminatedUnion_GetNestedTypes(INamedTypeSymbol unionType, INamedTypeSymbol[] types)
		=> types
			.Select(t => DiscriminatedUnion_GetNestedType(unionType, t, types))
			.Join($"{Environment.NewLine}{Environment.NewLine}");

	// TODO - Swap record for class?
	private static string DiscriminatedUnion_GetNestedType(INamedTypeSymbol unionType, INamedTypeSymbol nestedType, INamedTypeSymbol[] types)
	{
		var name = nestedType.Name;
		var lowerName = name.ToLower();

		var nestedTypeName = nestedType.GetFullNameWithNamespace(".", true);

		var builder = new StringBuilder();

		builder.AppendLine($"		public sealed record {name} : {unionType.GetFullNameWithNamespace(".", true)}");
		builder.AppendLine($"		{{");
		builder.AppendLine($"			private readonly {nestedTypeName} _{lowerName};");
		builder.AppendLine($" 			");
		builder.AppendLine($"			public {name}({nestedTypeName} {lowerName}) ");
		builder.AppendLine($"				=> _{lowerName} = {lowerName};");
		builder.AppendLine($"			");
		builder.AppendLine($"			public override T Match<T>({DiscriminatedUnion_GetMatchParameters(types)})");
		builder.AppendLine($"				=> on{name}.Invoke(_{lowerName});");
		builder.AppendLine($"			");
		builder.AppendLine($"			public {nestedTypeName} Unwrap()");
		builder.AppendLine($"				=> _{lowerName};");
		if (nestedType.TypeKind != TypeKind.Interface)
		{
			builder.AppendLine($"			");
			builder.AppendLine($"			public static implicit operator {nestedTypeName}({name} {lowerName})");
			builder.AppendLine($"				=> {lowerName}.Unwrap();");
		}
		builder.Append($"		}}");

		return builder.ToString();
	}

	// TODO - Assure names are unique
	private static string DiscriminatedUnion_GetMatchParameters(INamedTypeSymbol[] types)
		=> types
			.Select(type => $"global::System.Func<{type.GetFullNameWithNamespace(".", true)}, T> on{type.Name}")
			.Join(", ");

	private static string DiscriminatedUnion_GetCreateMethods(INamedTypeSymbol unionType, INamedTypeSymbol[] types)
		=> types
			.Select(t => DiscriminatedUnion_GetCreateMethod(unionType, t))
			.Join($"{Environment.NewLine}{Environment.NewLine}");

	private static string DiscriminatedUnion_GetCreateMethod(INamedTypeSymbol unionType, INamedTypeSymbol nestedType)
	{
		var builder = new StringBuilder();

		builder.AppendLine($"		public static {unionType.GetFullNameWithNamespace(".", true)} Create({nestedType.GetFullNameWithNamespace(".", true)} {nestedType.Name.ToLower()})");
		builder.Append($"			=> new {nestedType.Name}({nestedType.Name.ToLower()});");

		return builder.ToString();
	}

	private static string DiscriminatedUnion_CreateByImplicitCasts(INamedTypeSymbol unionType, INamedTypeSymbol[] types)
		=> types
			.Select(t => DiscriminatedUnion_CreateByImplicitCast(unionType, t))
			.Join($"{Environment.NewLine}{Environment.NewLine}");

	private static string DiscriminatedUnion_CreateByImplicitCast(INamedTypeSymbol unionType, INamedTypeSymbol nestedType)
	{
		var builder = new StringBuilder();

		builder.AppendLine($"		public static implicit operator {unionType.GetFullNameWithNamespace(".", true)}({nestedType.GetFullNameWithNamespace(".", true)} {nestedType.Name.ToLower()})");
		builder.Append($"			=> Create({nestedType.Name.ToLower()});");

		return builder.ToString();
	}
}
