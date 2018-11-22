using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Functional
{
	internal static class UnionValueUtility
	{
		private static readonly MethodInfo[] _createUnionMethods;
		static UnionValueUtility()
		{
			var fromDefinition = typeof(UnionFactoryExtensions).GetMethod(nameof(UnionFactoryExtensions.CreateUnionFromDefinition), BindingFlags.NonPublic | BindingFlags.Static);

			var fromTypes = typeof(UnionFactoryExtensions)
				.GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
				.Where(method => method.Name == nameof(UnionFactoryExtensions.CreateUnionFromTypes))
				.OrderBy(method => method.ReturnType.GetGenericArguments().Length);

			_createUnionMethods = new[] { fromDefinition }.Concat(fromTypes).ToArray();
		}

		public static Func<IUnionValue<TUnionDefinition>, TUnionType> CreateUnionFactory<TUnionType, TUnionDefinition>()
			where TUnionType : struct
			where TUnionDefinition : IUnionDefinition
		{
			var genericArguments = typeof(TUnionType).GetGenericArguments();

			return (Func<IUnionValue<TUnionDefinition>, TUnionType>)_createUnionMethods[genericArguments.Length - 1]
				.MakeGenericMethod(genericArguments)
				.CreateDelegate(typeof(Func<IUnionValue<TUnionDefinition>, TUnionType>));
		}
	}
}
