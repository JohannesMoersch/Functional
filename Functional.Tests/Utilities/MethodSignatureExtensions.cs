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
				methodInfo.GetParameters().Select(p => ((p.IsOut ? p.ParameterType.GetElementType() ?? p.ParameterType : p.ParameterType).ToTypeSignature(typeMapping), p.IsOut, p.GetIsNullable())).ToArray()
			);
		}

		public static MethodSignature.TypeSignature ToTypeSignature(this Type type, IReadOnlyDictionary<Type, int> typeMapping)
			=> type.IsGenericType
				? new MethodSignature.TypeSignature(
					(type.GetGenericTypeDefinition(), null),
					type.GetGenericArguments().Select(t => t.ToTypeSignature(typeMapping)).ToArray()
				)
				: type.IsArray
					? new MethodSignature.TypeSignature(
						typeMapping.TryGetValue(type.GetElementType() ?? type, out var num)
							? (null, num)
							: (type.GetElementType() ?? type, null),
						true
					)
					: new MethodSignature.TypeSignature(
						typeMapping.TryGetValue(type, out num)
							? (null, num)
							: (type, null),
						false
					);

		private static bool GetIsNullable(this ParameterInfo parameter)
			=> parameter
				.GetNullableContext() switch
			{
				0 => !parameter.ParameterType.IsValueType,
				1 => !parameter.ParameterType.IsValueType && parameter.GetNullable().ValueOrDefault(1) == 2,
				2 => !parameter.ParameterType.IsValueType && parameter.GetNullable().ValueOrDefault(2) == 2,
				_ => throw new Exception()
			};

		private static Option<int> GetNullable(this ParameterInfo parameter)
			=> parameter
				.GetCustomAttributes()
				.GetNullable();

		private static Option<int> GetNullable(this IEnumerable<Attribute> attributes)
			=> attributes
				.TryFirst(a => a.GetType().FullName == "System.Runtime.CompilerServices.NullableAttribute")
				.Bind(a => Option.FromNullable((a.GetType().GetField("NullableFlags") ?? throw new Exception("Couldn't find \"NullableFlags\" property on NullableAttribute.")).GetValue(a)))
				.Map(v => (byte[])v)
				.Map(b => (int)b[0]);

		private static int GetNullableContext(this ParameterInfo parameter)
			=> parameter
				.Member
				.GetNullableContext();

		private static int GetNullableContext(this MemberInfo member)
			=> member
				.GetCustomAttributes()
				.GetNullableContext()
				.BindOnNone(() => Option
					.FromNullable(member.DeclaringType)
					.Bind(type => type
						.GetCustomAttributes()
						.GetNullableContext()
					)
				)
				.BindOnNone(() => Option
					.FromNullable(member.DeclaringType)
					.Bind(assembly => assembly
						.GetCustomAttributes()
						.GetNullableContext()
					)
				)
				.ValueOrDefault(0);

		private static Option<int> GetNullableContext(this IEnumerable<Attribute> attributes)
			=> attributes
				.TryFirst(a => a.GetType().FullName == "System.Runtime.CompilerServices.NullableContextAttribute")
				.Bind(a => Option.FromNullable((a.GetType().GetField("Flag") ?? throw new Exception("Couldn't find \"Flag\" property on NullableContextAttribute.")).GetValue(a)))
				.Map(v => (int)(byte)v);
	}
}
