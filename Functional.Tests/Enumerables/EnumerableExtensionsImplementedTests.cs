using Functional.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
				.Where(m => m.MethodName != nameof(Enumerable.AsEnumerable))
				.Where(m => m.MethodName != nameof(Enumerable.SelectMany))
				.Where(m => m.MethodName != nameof(Enumerable.TryGetNonEnumeratedCount))
				.Where(m => m.MethodName != nameof(Enumerable.Zip))
				.ToHashSet();

			var functionalExtensions = typeof(EnumerableExtensions)
				.GetMethods(BindingFlags.Public | BindingFlags.Static)
				.Where(m => m.GetCustomAttribute<ExtensionAttribute>() != null)
				.Where(m => 
					m.GetParameters().Length >= 1 && 
					m.GetParameters()[0].ParameterType.IsGenericType &&
					m.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(Task<>)
				)
				.Select(m => m.ToMethodSignature())
				.Select(m => m with
				{
					ReturnType = m.ReturnType.GenericTypeArguments.Count != 0 ? m.ReturnType.GenericTypeArguments[0] : new MethodSignature.TypeSignature((typeof(void), null), false),
					ParameterTypes = [ (m.ParameterTypes[0].TypeSignature.GenericTypeArguments[0], m.ParameterTypes[0].IsOut, m.ParameterTypes[0].IsNullable), .. m.ParameterTypes.Skip(1)]
				})
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
			var functionalExtensions = MethodSignature.GetAllFunctionalExtensions();
			var expectedMethods = MethodSignature.GetExpectedFunctionalEnumerableExtensions();

			var builtInExtensions = typeof(Enumerable)
				.GetMethods(BindingFlags.Public | BindingFlags.Static)
				.Where(m => m.GetCustomAttribute<ExtensionAttribute>() != null)
				.Select(m => m.ToMethodSignature())
				.Select(m => m with
				{
					ReturnType = new MethodSignature.TypeSignature((typeof(void), null), false)
				}
				)
				.Distinct()
				.ToArray();

			var missingMethods = expectedMethods
				.Except(functionalExtensions)
				.Except(builtInExtensions)
				.Select(m => m.ToString().Substring(6))
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
	}
}
