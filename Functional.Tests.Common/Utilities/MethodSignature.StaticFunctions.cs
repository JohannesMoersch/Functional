using Functional;
using Functional.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Functional;

public sealed partial record MethodSignature
{
	public static MethodSignature[] GetAllFunctionalExtensions()
		=> typeof(EnumerableExtensions)
				.GetMethods(BindingFlags.Public | BindingFlags.Static)
				.Where(m => m.GetCustomAttribute<ExtensionAttribute>() != null)
				.Select(m => m.ToMethodSignature())
				.Select(m => m with
					{
						ReturnType = new TypeSignature((typeof(void), null), false)
					}
				)
				.ToArray();

	public static MethodSignature[] GetExpectedFunctionalEnumerableExtensions()
	{
		var functionalExtensionTypes = GetAllFunctionalExtensions()
			.Where(m => GetEnumerableType(m.ParameterTypes[0].TypeSignature) != EnumerableType.NotAnEnumerable)
			.Where(m => m.MethodName != nameof(EnumerableExtensions.AsEnumerable))
			.Where(m => m.MethodName != nameof(EnumerableExtensions.Cast))
			.Where(m => m.MethodName != nameof(EnumerableExtensions.GetEnumerator))
			.Where(m => m.MethodName != nameof(EnumerableExtensions.OfType))
			.Where(m => m.MethodName != nameof(EnumerableExtensions.PickInto))
			.Where(m => m.MethodName != nameof(EnumerableExtensions.ThenBy))
			.Where(m => m.MethodName != nameof(EnumerableExtensions.ThenByDescending))
			.Where(m => m.MethodName != nameof(EnumerableExtensions.ToLookup))
			.Select(m => m
				.ParameterTypes
				.Select(type => Traverse
					(
						type.TypeSignature,
						t => !type.IsOut && (t.Parent?.Type.Type.type?.FullName?.Split('`')[0] != "System.Func" || t.GenericArgumentIndexOnParent == t.Parent.Type.GenericTypeArguments.Count - 1)
							? GetEnumerableType(t.Type) switch
							{
								EnumerableType.IEnumerable or EnumerableType.IOrderedEnumerable or EnumerableType.IAsyncEnumerable => new TypeSignature(typeof(EnumerablePlaceholder<>), GetInnerTypeFromEnumerable(t.Type)),
								EnumerableType.TaskIEnumerable or EnumerableType.TaskIOrderedEnumerable => new TypeSignature(typeof(TaskEnumerablePlaceholder<>), GetInnerTypeFromEnumerable(t.Type)),
								EnumerableType.NotAnEnumerable => t.Type,
								_ => throw new Exception()
							}
							: t.Type
					)
					.Map(t => (t, type.IsOut, type.IsNullable))
				)
				.TakeUntilNone()
				.Map(parameters => m with { ParameterTypes = parameters.ToEquatableList() })
			)
			.WhereSome()
			.Distinct()
			.ToArray();

		var enumerableTypes = new[]
		{
				EnumerableType.IEnumerable,
				EnumerableType.TaskIEnumerable,
				EnumerableType.TaskIOrderedEnumerable,
				EnumerableType.IAsyncEnumerable
			};

		var nonAsyncEnumerableTypes = new[]
		{
				EnumerableType.IEnumerable,
				EnumerableType.IAsyncEnumerable
			};

		var asyncEnumerableTypes = new[]
		{
				EnumerableType.TaskIEnumerable,
				EnumerableType.TaskIOrderedEnumerable
			};

		return functionalExtensionTypes
			.SelectMany(m => m
				.ParameterTypes
				.Select(type => enumerableTypes
					.Select(enumerableType => Traverse
						(
							type.TypeSignature,
							t => t.Type.Type.type == typeof(EnumerablePlaceholder<>)
								? t.Parent?.Type.Type.type?.FullName?.Split('`')[0] != "System.Func" || nonAsyncEnumerableTypes.Contains(enumerableType)
									? GetTypeAsEnumerable(enumerableType, t.Type.GenericTypeArguments[0])
									: Option.None()
								: t.Type.Type.type == typeof(TaskEnumerablePlaceholder<>)
									? t.Parent?.Type.Type.type?.FullName?.Split('`')[0] != "System.Func" || asyncEnumerableTypes.Contains(enumerableType)
										? GetTypeAsEnumerable(enumerableType, t.Type.GenericTypeArguments[0])
										: Option.None()
									: t.Type
						)
						.Map(t => (t, type.IsOut, type.IsNullable))
					)
					.WhereSome()
					.Distinct()
				)
				.Aggregate
				(
					new[] { Enumerable.Empty<(TypeSignature, bool, bool)>() }.AsEnumerable(),
					(current, next) => current.SelectMany(parameters => next.Select(t => parameters.Append(t)))
				)
				.Select(parameters => m with { ParameterTypes = parameters.ToEquatableList() })
			)
			.ToArray();	
	}



	private class EnumerablePlaceholder<T> { }
	private class TaskEnumerablePlaceholder<T> { }

	private record TypeSignatureSSS(TypeSignature Type, TypeSignatureSSS? Parent, int? GenericArgumentIndexOnParent);

	public enum EnumerableType
	{
		NotAnEnumerable,
		IEnumerable,
		IOrderedEnumerable,
		TaskIEnumerable,
		TaskIOrderedEnumerable,
		IAsyncEnumerable
	}

	private static EnumerableType GetEnumerableType(TypeSignature type)
	{
		if (type.Type.type is Type typeValue)
		{
			if (typeValue == typeof(IEnumerable<>))
				return EnumerableType.IEnumerable;

			if (typeValue == typeof(IOrderedEnumerable<>))
				return EnumerableType.IOrderedEnumerable;

			if (typeValue == typeof(IAsyncEnumerable<>))
				return EnumerableType.IAsyncEnumerable;

			if (typeValue == typeof(Task<>) && type.GenericTypeArguments[0].Type.type is Type innerTypeValue)
			{
				if (innerTypeValue == typeof(IEnumerable<>))
					return EnumerableType.TaskIEnumerable;

				if (innerTypeValue == typeof(IOrderedEnumerable<>))
					return EnumerableType.TaskIOrderedEnumerable;
			}
		}

		return EnumerableType.NotAnEnumerable;
	}

	private static TypeSignature GetInnerTypeFromEnumerable(TypeSignature type)
		=> GetEnumerableType(type) switch
		{
			EnumerableType.IEnumerable or EnumerableType.IOrderedEnumerable or EnumerableType.IAsyncEnumerable => type.GenericTypeArguments[0],
			EnumerableType.TaskIEnumerable or EnumerableType.TaskIOrderedEnumerable => type.GenericTypeArguments[0].GenericTypeArguments[0],
			_ => throw new Exception()
		};

	private static TypeSignature GetTypeAsEnumerable(EnumerableType enumerableType, TypeSignature innerType)
		=> enumerableType switch
		{
			EnumerableType.IEnumerable => new TypeSignature(typeof(IEnumerable<>), new[] { innerType }),
			EnumerableType.IOrderedEnumerable => new TypeSignature(typeof(IOrderedEnumerable<>), new[] { innerType }),
			EnumerableType.IAsyncEnumerable => new TypeSignature(typeof(IAsyncEnumerable<>), new[] { innerType }),
			EnumerableType.TaskIEnumerable => new TypeSignature(typeof(Task<>), new[] { new TypeSignature(typeof(IEnumerable<>), new[] { innerType }) }),
			EnumerableType.TaskIOrderedEnumerable => new TypeSignature(typeof(Task<>), new[] { new TypeSignature(typeof(IOrderedEnumerable<>), new[] { innerType }) }),
			_ => throw new Exception()
		};

	private static Option<TypeSignature> Traverse(TypeSignature typeSignature, Func<TypeSignatureSSS, Option<TypeSignature>> modifier)
		=> Traverse(new TypeSignatureSSS(typeSignature, null, null), modifier);

	private static Option<TypeSignature> Traverse(TypeSignatureSSS typeSignature, Func<TypeSignatureSSS, Option<TypeSignature>> modifier)
		=> modifier
			.Invoke(typeSignature)
			.Bind(t => t == typeSignature.Type
				? t.GenericTypeArguments
					.Select((o, i) => Traverse(new TypeSignatureSSS(o, typeSignature, i), modifier))
					.TakeUntilNone()
					.Map(a => t with { GenericTypeArguments = a.ToEquatableList() })
				: t
			);
}
