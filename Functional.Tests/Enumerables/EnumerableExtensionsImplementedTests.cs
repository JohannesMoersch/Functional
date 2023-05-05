﻿using Functional.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests.Enumerables
{
	public partial class EnumerableExtensionsImplementedTests
	{
		[Fact]
		public void AllEnumerableExtensionsAreReimplementedAsTaskOfEnumerable()
		{
			var sdkExtensions = typeof(Enumerable)
				.GetMethods(BindingFlags.Public | BindingFlags.Static)
				.Where(m => m.GetCustomAttribute<ExtensionAttribute>() != null)
				.Select(m => m.ToMethodSignature())
				.ToHashSet();

			var functionalExtensions = typeof(EnumerableTypeExtensions)
				.GetMethods(BindingFlags.Public | BindingFlags.Static)
				.Where(m => m.GetCustomAttribute<ExtensionAttribute>() != null)
				.Where(m => 
					m.GetParameters().Length >= 1 && 
					m.GetParameters()[0].ParameterType.IsGenericType &&
					m.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(Task<>)
				)
				.Select(m => m.ToMethodSignature())
				.Select(m => new MethodSignature
				(
					m.MethodName,
					m.ReturnType.GenericTypeArguments.Count != 0 ? m.ReturnType.GenericTypeArguments[0] : new MethodSignature.TypeSignature((typeof(void), null)),
					m.GenericTypeArguments,
					new[] { m.ParameterTypes[0].GenericTypeArguments[0] }.Concat(m.ParameterTypes.Skip(1)).ToArray()
				))
				.ToHashSet();

			var missingMethods = sdkExtensions
				.Except(functionalExtensions)
				.Select(m => m.ToString())
				.OrderBy(_ => _)
				.ToArray();

			if (missingMethods.Any())
			{
				StringBuilder builder = new StringBuilder();

				builder.AppendLine($"{missingMethods.Length} enumerable extensions not reflected in Functional.");

				foreach (var method in missingMethods)
					builder.AppendLine(method);

				throw new Exception(builder.ToString());
			}
		}

		[Fact]
		public void AllEnumerableExtensionsHaveAllVariants()
		{
			var functionalExtensions = typeof(EnumerableTypeExtensions)
				.GetMethods(BindingFlags.Public | BindingFlags.Static)
				.Where(m => m.GetCustomAttribute<ExtensionAttribute>() != null)
				.Select(m => m.ToMethodSignature())
				.Select(m => m with { ReturnType = new MethodSignature.TypeSignature((typeof(void), null)) })
				.ToArray();

			var functionalExtensionTypes = functionalExtensions
				.Where(m => GetEnumerableType(m.ParameterTypes[0]) != EnumerableType.NotAnEnumerable)
				.Select(m => m with { ParameterTypes = new[] { GetInnerTypeFromEnumerable(m.ParameterTypes[0]) }.Concat(m.ParameterTypes.Skip(1)).ToEquatableList() })
				.Distinct()
				.ToArray();

			var expectedMethods = new[]
				{
					EnumerableType.IEnumerable,
					EnumerableType.TaskIEnumerable,
					EnumerableType.TaskIOrderedEnumerable,
					EnumerableType.IAsyncEnumerable
				}
				.SelectMany(enumerableType => functionalExtensionTypes
					.Select(m => m with { ParameterTypes = new[] { GetTypeAsEnumerable(enumerableType, m.ParameterTypes[0]) }.Concat(m.ParameterTypes.Skip(1)).ToEquatableList() })
				)
				.ToArray();

			var builtInExtensions = typeof(Enumerable)
				.GetMethods(BindingFlags.Public | BindingFlags.Static)
				.Where(m => m.GetCustomAttribute<ExtensionAttribute>() != null)
				.Select(m => m.ToMethodSignature())
				.Select(m => m with { ReturnType = new MethodSignature.TypeSignature((typeof(void), null)) })
				.Distinct()
				.ToArray();

			var missingMethods = expectedMethods
				.Except(functionalExtensions)
				.Except(builtInExtensions)
				.Select(m => m.ToString())
				.OrderBy(_ => _)
				.ToArray();

			if (missingMethods.Any())
			{
				StringBuilder builder = new StringBuilder();

				builder.AppendLine($"{missingMethods.Length} enumerable extension variants are missing.");

				foreach (var method in missingMethods)
					builder.AppendLine(method);

				throw new Exception(builder.ToString());
			}
		}

		public enum EnumerableType
		{
			NotAnEnumerable,
			IEnumerable,
			IOrderedEnumerable,
			TaskIEnumerable,
			TaskIOrderedEnumerable,
			IAsyncEnumerable
		}

		private EnumerableType GetEnumerableType(MethodSignature.TypeSignature type)
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

		private MethodSignature.TypeSignature GetInnerTypeFromEnumerable(MethodSignature.TypeSignature type)
			=> GetEnumerableType(type) switch
			{
				EnumerableType.IEnumerable or EnumerableType.IOrderedEnumerable or EnumerableType.IAsyncEnumerable => type.GenericTypeArguments[0],
				EnumerableType.TaskIEnumerable or EnumerableType.TaskIOrderedEnumerable => type.GenericTypeArguments[0].GenericTypeArguments[0],
				_ => throw new Exception()
			};

		private MethodSignature.TypeSignature GetTypeAsEnumerable(EnumerableType enumerableType, MethodSignature.TypeSignature innerType)
			=> enumerableType switch
			{
				EnumerableType.IEnumerable => new MethodSignature.TypeSignature(typeof(IEnumerable<>), new[] { innerType }),
				EnumerableType.IOrderedEnumerable => new MethodSignature.TypeSignature(typeof(IOrderedEnumerable<>), new[] { innerType }),
				EnumerableType.IAsyncEnumerable =>  new MethodSignature.TypeSignature(typeof(IAsyncEnumerable<>), new[] { innerType }),
				EnumerableType.TaskIEnumerable => new MethodSignature.TypeSignature(typeof(Task<>), new[] { new MethodSignature.TypeSignature(typeof(IEnumerable<>), new[] { innerType }) }),
				EnumerableType.TaskIOrderedEnumerable => new MethodSignature.TypeSignature(typeof(Task<>), new[] { new MethodSignature.TypeSignature(typeof(IOrderedEnumerable<>), new[] { innerType }) }),
				_ => throw new Exception()
			};
	}
}