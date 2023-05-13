using Functional;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Tests.Utilities;

public record MethodSignature
{
	public record TypeSignature
	{
		public (Type? type, int? number) Type { get; init; }

		public bool IsArray { get; init; }

		public EquatableList<TypeSignature> GenericTypeArguments { get; init; }

		public TypeSignature(Type type, bool isArray) : this((type, null), isArray, Array.Empty<TypeSignature>()) { }

		public TypeSignature(Type type, params TypeSignature[] genericTypeArguments) : this((type, null), false, genericTypeArguments) { }

		public TypeSignature((Type? type, int? number) type, bool isArray) : this(type, isArray, Array.Empty<TypeSignature>()) { }

		public TypeSignature((Type? type, int? number) type, IReadOnlyList<TypeSignature> genericTypeArguments) : this(type, false, genericTypeArguments) { }

		private TypeSignature((Type? type, int? number) type, bool isArray, IReadOnlyList<TypeSignature> genericTypeArguments)
		{
			Type = type;
			IsArray = isArray;
			GenericTypeArguments = genericTypeArguments.ToEquatableList();
		}

		public override string ToString()
			=> Type.type is Type type
				? GenericTypeArguments.Any()
					? $"{type.Name.Split('`')[0]}<{String.Join(", ", GenericTypeArguments)}>"
					: $"{type.Name}{(IsArray ? "[]" : "")}"
				: $"T{Type.number}{(IsArray ? "[]" : "")}";
	}

	public string MethodName { get; init; }
	public TypeSignature ReturnType { get; init; }
	public EquatableList<TypeSignature> GenericTypeArguments { get; init; }
	public EquatableList<(TypeSignature TypeSignature, bool IsOut)> ParameterTypes { get; init; }

	public MethodSignature(string methodName, TypeSignature returnType, IReadOnlyList<TypeSignature> genericTypeArguments, IReadOnlyList<(TypeSignature TypeSignature, bool IsOut)> parameterTypes)
	{
		MethodName = methodName;
		ReturnType = returnType;
		GenericTypeArguments = genericTypeArguments.ToEquatableList();
		ParameterTypes = parameterTypes.ToEquatableList();
	}

	public override string ToString()
		=> $"\t{ReturnType} {MethodName}{(GenericTypeArguments.Any() ? $"<{String.Join(", ", GenericTypeArguments)}>" : "")}(this {String.Join(", ", ParameterTypes.Select(o => $"{(o.IsOut ? "out " : "")}{o.TypeSignature}"))})";
}
