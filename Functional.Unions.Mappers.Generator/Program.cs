using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Functional.Unions.Mappers.Generator
{
	class Program
	{
		static void Main(string[] args)
		{
			var outputPath = @"..\..\..\..\Functional.Unions.Mappers\Mappers.cs";

			var types = new[]
			{
				"One",
				"Two",
				"Three",
				//"Four",
				//"Five"
			};

			var mappers = Enumerable
				.Range(1, types.Length)
				.SelectMany(i => GenerateMappers(i, types))
				.ToArray();

			var builder = new StringBuilder();

			builder.AppendLine("using System;");
			builder.AppendLine("using System.ComponentModel;");
			builder.AppendLine("");
			builder.AppendLine("namespace Functional.Unions.Mappers");
			builder.AppendLine("{");
			builder.AppendLine(String.Join(Environment.NewLine, mappers));
			builder.AppendLine("}");

			File.WriteAllText(outputPath, builder.ToString());
		}

		private static string[] GenerateMappers(int typeCount, string[] types)
			=> Enumerable
				.Range(1, types.Length)
				.SelectMany(i => GenerateMappersForTypeCount(typeCount, i, types))
				.ToArray();

		private static string[] GenerateMappersForTypeCount(int sourceTypeCount, int targetTypeCount, string[] types)
			=> GenerateCombinations(Enumerable.Range(0, sourceTypeCount + targetTypeCount).ToArray(), targetTypeCount)
				.Select(arr => arr.Select(i => i < sourceTypeCount ? i : -1))
				.Select(arr => new ComparableArray(arr))
				.Distinct()
				.Select(set => GenerateMapper(sourceTypeCount, set, types))
				.ToArray();

		private static string GenerateMapper(int sourceTypeCount, IReadOnlyList<int> targetTypes, string[] types)
		{
			var name = String.Join("", targetTypes.Select(i => i == -1 ? "Other" : types[i]));
			var sourceTypeNames = Enumerable.Range(0, sourceTypeCount).Select(i => $", T{types[i]}").Aggregate(String.Empty, (s1, s2) => s1 + s2);
			var otherTypeNames = targetTypes.Where(i => i == -1).Select((_, i) => $", TOther{types[i]}").Aggregate(String.Empty, (s1, s2) => s1 + s2);
			var otherMap = targetTypes
				.Select((value, index) => (value, index))
				.Where(set => set.value == -1)
				.Select((set, index) => (originalIndex: set.index, index))
				.ToDictionary(set => set.originalIndex, set => set.index);
			var targetTypeNames = targetTypes.Select((i, index) => i == -1 ? $", TOther{types[otherMap[index]]}" : $", T{types[i]}").Aggregate(String.Empty, (s1, s2) => s1 + s2);

			var builder = new StringBuilder();

			builder.AppendLine($"	[EditorBrowsable(EditorBrowsableState.Never)]");
			builder.AppendLine($"	public struct UnionMapper{name}<TUnionType, TUnionDefinition{sourceTypeNames}, TTargetUnionDefinition{otherTypeNames}>");
			builder.AppendLine($"		where TUnionDefinition : UnionDefinitionBase<TUnionType, TUnionDefinition{sourceTypeNames}>");
			builder.AppendLine($"		where TTargetUnionDefinition : UnionDefinition<TTargetUnionDefinition{targetTypeNames}>");
			builder.AppendLine($"	{{");
			builder.AppendLine($"		private readonly IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition{sourceTypeNames}>> _union;");
			builder.AppendLine($"		private readonly IUnionFactory<UnionDefinition<TTargetUnionDefinition{targetTypeNames}>> _factory;");
			builder.AppendLine($"		");
			builder.AppendLine($"		public UnionMapper{name}(IUnionValue<UnionDefinitionBase<TUnionType, TUnionDefinition{sourceTypeNames}>> union, IUnionFactory<UnionDefinition<TTargetUnionDefinition{targetTypeNames}>> factory)");
			builder.AppendLine($"		{{");
			builder.AppendLine($"			_union = union;");
			builder.AppendLine($"			_factory = factory;");
			builder.AppendLine($"		}}");

			GenerateMapFunctions(builder, sourceTypeCount, targetTypes, types, otherMap);

			builder.AppendLine($"	}}");

			return builder.ToString();
		}

		private static string GenerateMapFunctions(StringBuilder builder, int sourceTypeCount, IReadOnlyList<int> targetTypes, string[] types, Dictionary<int, int> otherMap)
		{
			var typeSet = new HashSet<int>(targetTypes);

			var missingFromTarget = Enumerable.Range(0, sourceTypeCount).Where(i => !typeSet.Contains(i)).ToArray();

			if (missingFromTarget.Length == 0)
			{
				builder.AppendLine($"		");
				builder.AppendLine($"		public Union<TTargetUnionDefinition> Map()");
				builder.AppendLine($"			=> _union.Match({String.Join(", ", Enumerable.Range(0, sourceTypeCount).Select(_ => "_factory.Create"))});");
			}
			else
			{
				foreach (var targets in GetPermutations(targetTypes.Select((_, i) => i).ToArray(), missingFromTarget.Length))
				{
					var parameters = String.Join(", ", missingFromTarget.Select((i, index) => $"Func<T{types[i]}, T{(targetTypes[targets[index]] == -1 ? $"Other{types[otherMap[targets[index]]]}" : types[targetTypes[targets[index]]])}> mapper{types[index]}"));

					int typeIndex = 0;
					var arguments = String.Join(", ", Enumerable.Range(0, sourceTypeCount).Select(i => typeSet.Contains(i) ? "factory.Create" : $"value => factory.Create(mapper{types[typeIndex++]}.Invoke(value))"));

					builder.AppendLine($"		");
					builder.AppendLine($"		public Union<TTargetUnionDefinition> Map({parameters})");
					builder.AppendLine($"		{{");
					builder.AppendLine($"			var factory = _factory;");
					builder.AppendLine($"			return _union.Match({arguments});");
					builder.AppendLine($"		}}");
				}
			}

			return builder.ToString();
		}

		private static IEnumerable<int[]> GenerateCombinations(int[] options, int count)
		{
			if (count == 1)
			{
				var result = new int[1];
				foreach (var value in options)
				{
					result[0] = value;
					yield return result;
				}
			}
			else
			{
				var result = new int[count];
				var left = new int[options.Length - 1];

				for (int i = 0; i < options.Length; ++i)
				{
					result[0] = options[i];

					var index = 0;
					for (int j = 0; j < options.Length; ++j)
					{
						if (j != i)
							left[index++] = options[j];
					}

					foreach (var set in GenerateCombinations(left, count - 1))
					{
						for (int j = 0; j < set.Length; ++j)
							result[j + 1] = set[j];

						yield return result;
					}
				}
			}
		}

		private static IEnumerable<int[]> GetPermutations(int[] values, int count)
			=> GetPermutations(values, new int[count], 0);

		private static IEnumerable<int[]> GetPermutations(int[] values, int[] outputArray, int iteration)
		{
			if (iteration == outputArray.Length)
				yield return outputArray;
			else
			{
				foreach (var value in values)
				{
					outputArray[iteration] = value;
					foreach (var result in GetPermutations(values, outputArray, iteration + 1))
						yield return result;
				}
			}
		}
	}
}
