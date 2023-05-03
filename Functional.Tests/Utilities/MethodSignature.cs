using Functional;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Tests.Utilities;

public record MethodSignature
{
	public record TypeSignature
	{
		public (Type? type, int? number) Type { get; }
		public EquatableList<TypeSignature> GenericTypeArguments { get; }

		public TypeSignature(Type type) : this((type, null), Array.Empty<TypeSignature>()) { }

		public TypeSignature(Type type, params TypeSignature[] genericTypeArguments) : this((type, null), genericTypeArguments) { }

		public TypeSignature((Type? type, int? number) type) : this(type, Array.Empty<TypeSignature>()) { }

		public TypeSignature((Type? type, int? number) type, IReadOnlyList<TypeSignature> genericTypeArguments)
		{
			Type = type;
			GenericTypeArguments = genericTypeArguments.ToEquatableList();
		}

		public override string ToString()
			=> Type.type is Type type
				? GenericTypeArguments.Any()
					? $"{type.Name.Split('`')[0]}<{String.Join(", ", GenericTypeArguments)}>"
					: type.Name
				: $"T{Type.number}";
	}

	public string MethodName { get; init; }
	public TypeSignature ReturnType { get; init; }
	public EquatableList<TypeSignature> GenericTypeArguments { get; init; }
	public EquatableList<TypeSignature> ParameterTypes { get; init; }

	public MethodSignature(string methodName, TypeSignature returnType, IReadOnlyList<TypeSignature> genericTypeArguments, IReadOnlyList<TypeSignature> parameterTypes)
	{
		MethodName = methodName;
		ReturnType = returnType;
		GenericTypeArguments = genericTypeArguments.ToEquatableList();
		ParameterTypes = parameterTypes.ToEquatableList();
	}

	public override string ToString()
		=> $"\t{ReturnType} {MethodName}{(GenericTypeArguments.Any() ? $"<{String.Join(", ", GenericTypeArguments)}>" : "")}(this {String.Join(", ", ParameterTypes)})";
}
