using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using System.Text;
using Xunit;

namespace Functional.Tests
{
	public class NetStandard2EquivalenceTests
	{
		[Fact]
		public void AllAsyncEnumerableExtensionsHaveNetStandard2Equivalents()
		{
			var netstandard2_0 = GetExtensionMethods(GetNetStandard2_0Assembly("Functional.AsyncEnumerables"))
				.Select(method => new Signature(method));

			var netstandard2_1 = GetExtensionMethods(GetNetStandard2_1Assembly("Functional.AsyncEnumerables"))
				.Select(method => new Signature(method));

			var missingFromNetStandard2_0 = netstandard2_1.Except(netstandard2_0).ToArray();
			var missingFromNetStandard2_1 = netstandard2_0.Except(netstandard2_1).ToArray();

			if (missingFromNetStandard2_0.Any() || missingFromNetStandard2_1.Any())
			{
				var builder = new StringBuilder();

				if (missingFromNetStandard2_0.Any())
				{
					builder.AppendLine($"{missingFromNetStandard2_0.Length} methods are missing from NetStandard2:");
					foreach (var method in missingFromNetStandard2_0)
						builder.AppendLine(method.ToString());
					builder.AppendLine();
				}

				if (missingFromNetStandard2_1.Any())
				{
					builder.AppendLine($"{missingFromNetStandard2_1.Length} methods are extra in NetStandard2:");
					foreach (var method in missingFromNetStandard2_1)
						builder.AppendLine(method.ToString());
				}

				throw new Exception(builder.ToString());
			}
		}

		private static Assembly GetNetStandard2_0Assembly(string assemblyName)
			=> new AssemblyLoadContext("NetStandard2")
				.LoadFromAssemblyPath
				(
					Path
						.Combine
						(
							Path.Combine(Path.GetDirectoryName(typeof(NetStandard2EquivalenceTests).Assembly.Location), "..\\netstandard2_dlls\\"), 
							$"{assemblyName}.dll"
						)
				);
		private static Assembly GetNetStandard2_1Assembly(string assemblyName)
			=> Assembly.Load(assemblyName);

		private static MethodInfo[] GetExtensionMethods(Assembly assembly)
			=> assembly
				.GetTypes()
				.Where(t => t.IsPublic && t.IsAbstract && t.IsSealed)
				.SelectMany(t => t.GetMethods())
				.Where(m => m.IsPublic && m.IsStatic)
				.Where(m => m.IsDefined(typeof(ExtensionAttribute)))
				.ToArray();

		private class Signature : IEquatable<Signature>
		{
			public string ReturnType { get; }

			public string ClassName { get; }

			public string Name { get; }

			public string[] GenericParameters { get; }

			public string[] Parameters { get; }

			public Signature(MethodInfo method)
			{
				ReturnType = GetTypeName(method.ReturnType);
				ClassName = GetTypeName(method.DeclaringType);
				Name = method.Name;
				GenericParameters = method.GetGenericArguments().Select(GetTypeName).ToArray();
				Parameters = method.GetParameters().Select(m => $"{(m.IsOut ? "out " : (m.ParameterType.IsByRef ? "ref " : ""))}{GetTypeName(m.ParameterType)}").ToArray();
			}

			public override int GetHashCode() 
				=> HashCode
					.Combine
					(
						ReturnType, 
						ClassName,
						Name, 
						GenericParameters.Aggregate(0, (p1, p2) => HashCode.Combine(p1, p2.GetHashCode())),
						Parameters.Aggregate(0, (p1, p2) => HashCode.Combine(p1, p2.GetHashCode()))
					);

			public override bool Equals(object obj) 
				=> Equals(obj as Signature);

			public bool Equals(Signature other)
				=>
				other != null &&
				ReturnType == other.ReturnType &&
				ClassName == other.ClassName &&
				Name == other.Name && 
				GenericParameters.SequenceEqual(other.GenericParameters) && 
				Parameters.SequenceEqual(other.Parameters);

			public static bool operator ==(Signature left, Signature right)
				=> EqualityComparer<Signature>.Default.Equals(left, right);

			public static bool operator !=(Signature left, Signature right) 
				=> !(left == right);

			public override string ToString()
				=> $"{ReturnType} {ClassName}.{Name}{(GenericParameters.Any() ? "<" : "")}{String.Join(", ", GenericParameters)}{(GenericParameters.Any() ? ">" : "")}({String.Join(", ", Parameters)})";

			private static string GetTypeName(Type type)
			{
				if (type.IsByRef)
					type = type.GetElementType();

				return type
					  .Name == "IAsyncEnumerable`1"
					  ? $"IAsyncEnumerable<{GetTypeName(type.GetGenericArguments()[0])}>"
					  : type
						  .IsGenericType
						  ? $"{type.Namespace}.{type.Name.Split('`').First()}<{String.Join(", ", type.GetGenericArguments().Select(GetTypeName))}>"
						  : $"{type.Namespace}.{type.Name.Split('`').First()}";
			}
		}
	}
}
