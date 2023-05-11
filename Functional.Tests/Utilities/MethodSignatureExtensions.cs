using Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Functional.Tests.Utilities
{
	public static class MethodSignatureExtensions
	{
		public static MethodSignature ToMethodSignature(this MethodInfo methodInfo)
		{
			var typeArguments = methodInfo.DeclaringType?.IsGenericType ?? false
				? methodInfo.DeclaringType.GetGenericArguments().Where(t => t.IsGenericTypeParameter)
				: Array.Empty<Type>();

			var methodArguments = methodInfo.IsGenericMethod
				? methodInfo.GetGenericArguments().Where(t => t.IsGenericMethodParameter)
				: Array.Empty<Type>();

			var typeMapping = typeArguments
				.Concat(methodArguments)
				.Select((t, i) => (type: t, index: i))
				.ToDictionary(o => o.type, o => o.index);

			return new MethodSignature
			(
				methodInfo.Name,
				methodInfo.ReturnType.ToTypeSignature(typeMapping),
				methodArguments.Select(t => t.ToTypeSignature(typeMapping)).ToArray(),
				methodInfo.GetParameters().Select(p => ((p.IsOut ? p.ParameterType.GetElementType() ?? p.ParameterType : p.ParameterType).ToTypeSignature(typeMapping), p.IsOut)).ToArray()
			);
		}

		public static MethodSignature.TypeSignature ToTypeSignature(this Type type, IReadOnlyDictionary<Type, int> typeMapping)
			=> type.IsGenericType
				? new MethodSignature.TypeSignature(
					(type.GetGenericTypeDefinition(), null),
					type.GetGenericArguments().Select(t => t.ToTypeSignature(typeMapping)).ToArray()
				)
				: new MethodSignature.TypeSignature(
					typeMapping.TryGetValue(type, out var num)
						? (null, num)
						: (type, null),
					Array.Empty<MethodSignature.TypeSignature>()
				);
	}
}
