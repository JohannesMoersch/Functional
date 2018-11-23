using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Functional
{
	internal class UnionSerializationHelpers
	{
		private const string StateName = "State";
		private const string ValueName = "Value";

		private static MethodInfo[] _createUnionValueFromDefinition
			=> new[]
			{
				typeof(UnionSerializationHelpers).GetMethod(nameof(CreateUnionValueOneFromDefinition), BindingFlags.NonPublic | BindingFlags.Static),
				typeof(UnionSerializationHelpers).GetMethod(nameof(CreateUnionValueTwoFromDefinition), BindingFlags.NonPublic | BindingFlags.Static),
				typeof(UnionSerializationHelpers).GetMethod(nameof(CreateUnionValueThreeFromDefinition), BindingFlags.NonPublic | BindingFlags.Static),
				typeof(UnionSerializationHelpers).GetMethod(nameof(CreateUnionValueFourFromDefinition), BindingFlags.NonPublic | BindingFlags.Static),
				typeof(UnionSerializationHelpers).GetMethod(nameof(CreateUnionValueFiveFromDefinition), BindingFlags.NonPublic | BindingFlags.Static),
				typeof(UnionSerializationHelpers).GetMethod(nameof(CreateUnionValueSixFromDefinition), BindingFlags.NonPublic | BindingFlags.Static),
				typeof(UnionSerializationHelpers).GetMethod(nameof(CreateUnionValueSevenFromDefinition), BindingFlags.NonPublic | BindingFlags.Static),
				typeof(UnionSerializationHelpers).GetMethod(nameof(CreateUnionValueEightFromDefinition), BindingFlags.NonPublic | BindingFlags.Static)
			};

		public static IUnionValue<TUnionDefinition> CreateUnionValue<TUnionDefinition>(SerializationInfo info)
			where TUnionDefinition : IUnionDefinition
		{
			var type = typeof(TUnionDefinition);
			while (type != null && !(type.IsConstructedGenericType && IsTypeAUnionDefinition(type.GetGenericTypeDefinition())))
				type = type.BaseType;

			if (type == null)
				throw new UnionSerializationException();

			var genericArguments = type.GetGenericArguments();

			return (IUnionValue<TUnionDefinition>)_createUnionValueFromDefinition[genericArguments.Length - 2]
				.MakeGenericMethod(genericArguments)
				.Invoke(null, new[] { info });
		}

		private static bool IsTypeAUnionDefinition(Type type)
			=>
			type == typeof(UnionDefinition<,>) ||
			type == typeof(UnionDefinition<,,>) ||
			type == typeof(UnionDefinition<,,,>) ||
			type == typeof(UnionDefinition<,,,,>) ||
			type == typeof(UnionDefinition<,,,,,>) ||
			type == typeof(UnionDefinition<,,,,,,>) ||
			type == typeof(UnionDefinition<,,,,,,,>) ||
			type == typeof(UnionDefinition<,,,,,,,,>);

		private static UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne> CreateUnionValueOneFromDefinition<TUnionDefinition, TOne>(SerializationInfo info)
			where TUnionDefinition : IUnionDefinition
			=> CreateUnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne>(info, UnionFactoryExtensions.CreateUnionFromDefinition);

		private static UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo> CreateUnionValueTwoFromDefinition<TUnionDefinition, TOne, TTwo>(SerializationInfo info)
			where TUnionDefinition : IUnionDefinition
			=> CreateUnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo>(info, UnionFactoryExtensions.CreateUnionFromDefinition);

		private static UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree> CreateUnionValueThreeFromDefinition<TUnionDefinition, TOne, TTwo, TThree>(SerializationInfo info)
			where TUnionDefinition : IUnionDefinition
			=> CreateUnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree>(info, UnionFactoryExtensions.CreateUnionFromDefinition);

		private static UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour> CreateUnionValueFourFromDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour>(SerializationInfo info)
			where TUnionDefinition : IUnionDefinition
			=> CreateUnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour>(info, UnionFactoryExtensions.CreateUnionFromDefinition);

		private static UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> CreateUnionValueFiveFromDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(SerializationInfo info)
			where TUnionDefinition : IUnionDefinition
			=> CreateUnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(info, UnionFactoryExtensions.CreateUnionFromDefinition);

		private static UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> CreateUnionValueSixFromDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(SerializationInfo info)
			where TUnionDefinition : IUnionDefinition
			=> CreateUnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(info, UnionFactoryExtensions.CreateUnionFromDefinition);

		private static UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> CreateUnionValueSevenFromDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(SerializationInfo info)
			where TUnionDefinition : IUnionDefinition
			=> CreateUnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(info, UnionFactoryExtensions.CreateUnionFromDefinition);

		private static UnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> CreateUnionValueEightFromDefinition<TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(SerializationInfo info)
			where TUnionDefinition : IUnionDefinition
			=> CreateUnionValue<Union<TUnionDefinition>, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(info, UnionFactoryExtensions.CreateUnionFromDefinition);

		public static UnionValue<TUnionType, TUnionDefinition, TOne> CreateUnionValue<TUnionType, TUnionDefinition, TOne>(SerializationInfo info, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			where TUnionType : struct
			where TUnionDefinition : IUnionDefinition
		{
			switch (info.GetByte(StateName))
			{
				case 0:
					return new UnionValue<TUnionType, TUnionDefinition, TOne>((TOne)info.GetValue(ValueName, typeof(TOne)), unionFactory);
			}

			throw new UnionSerializationException();
		}

		public static UnionValue<TUnionType, TUnionDefinition, TOne, TTwo> CreateUnionValue<TUnionType, TUnionDefinition, TOne, TTwo>(SerializationInfo info, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			where TUnionType : struct
			where TUnionDefinition : IUnionDefinition
		{
			switch (info.GetByte(StateName))
			{
				case 0:
					return new UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo>((TOne)info.GetValue(ValueName, typeof(TOne)), unionFactory);
				case 1:
					return new UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo>((TTwo)info.GetValue(ValueName, typeof(TTwo)), unionFactory);
			}

			throw new UnionSerializationException();
		}

		public static UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree> CreateUnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree>(SerializationInfo info, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			where TUnionType : struct
			where TUnionDefinition : IUnionDefinition
		{
			switch (info.GetByte(StateName))
			{
				case 0:
					return new UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree>((TOne)info.GetValue(ValueName, typeof(TOne)), unionFactory);
				case 1:
					return new UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree>((TTwo)info.GetValue(ValueName, typeof(TTwo)), unionFactory);
				case 2:
					return new UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree>((TThree)info.GetValue(ValueName, typeof(TThree)), unionFactory);
			}

			throw new UnionSerializationException();
		}

		public static UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour> CreateUnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>(SerializationInfo info, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			where TUnionType : struct
			where TUnionDefinition : IUnionDefinition
		{
			switch (info.GetByte(StateName))
			{
				case 0:
					return new UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>((TOne)info.GetValue(ValueName, typeof(TOne)), unionFactory);
				case 1:
					return new UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>((TTwo)info.GetValue(ValueName, typeof(TTwo)), unionFactory);
				case 2:
					return new UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>((TThree)info.GetValue(ValueName, typeof(TThree)), unionFactory);
				case 3:
					return new UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour>((TFour)info.GetValue(ValueName, typeof(TFour)), unionFactory);
			}

			throw new UnionSerializationException();
		}

		public static UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive> CreateUnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>(SerializationInfo info, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			where TUnionType : struct
			where TUnionDefinition : IUnionDefinition
		{
			switch (info.GetByte(StateName))
			{
				case 0:
					return new UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>((TOne)info.GetValue(ValueName, typeof(TOne)), unionFactory);
				case 1:
					return new UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>((TTwo)info.GetValue(ValueName, typeof(TTwo)), unionFactory);
				case 2:
					return new UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>((TThree)info.GetValue(ValueName, typeof(TThree)), unionFactory);
				case 3:
					return new UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>((TFour)info.GetValue(ValueName, typeof(TFour)), unionFactory);
				case 4:
					return new UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive>((TFive)info.GetValue(ValueName, typeof(TFive)), unionFactory);
			}

			throw new UnionSerializationException();
		}

		public static UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix> CreateUnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>(SerializationInfo info, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			where TUnionType : struct
			where TUnionDefinition : IUnionDefinition
		{
			switch (info.GetByte(StateName))
			{
				case 0:
					return new UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>((TOne)info.GetValue(ValueName, typeof(TOne)), unionFactory);
				case 1:
					return new UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>((TTwo)info.GetValue(ValueName, typeof(TTwo)), unionFactory);
				case 2:
					return new UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>((TThree)info.GetValue(ValueName, typeof(TThree)), unionFactory);
				case 3:
					return new UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>((TFour)info.GetValue(ValueName, typeof(TFour)), unionFactory);
				case 4:
					return new UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>((TFive)info.GetValue(ValueName, typeof(TFive)), unionFactory);
				case 5:
					return new UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix>((TSix)info.GetValue(ValueName, typeof(TSix)), unionFactory);
			}

			throw new UnionSerializationException();
		}

		public static UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven> CreateUnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>(SerializationInfo info, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			where TUnionType : struct
			where TUnionDefinition : IUnionDefinition
		{
			switch (info.GetByte(StateName))
			{
				case 0:
					return new UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>((TOne)info.GetValue(ValueName, typeof(TOne)), unionFactory);
				case 1:
					return new UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>((TTwo)info.GetValue(ValueName, typeof(TTwo)), unionFactory);
				case 2:
					return new UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>((TThree)info.GetValue(ValueName, typeof(TThree)), unionFactory);
				case 3:
					return new UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>((TFour)info.GetValue(ValueName, typeof(TFour)), unionFactory);
				case 4:
					return new UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>((TFive)info.GetValue(ValueName, typeof(TFive)), unionFactory);
				case 5:
					return new UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>((TSix)info.GetValue(ValueName, typeof(TSix)), unionFactory);
				case 6:
					return new UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven>((TSeven)info.GetValue(ValueName, typeof(TSeven)), unionFactory);
			}

			throw new UnionSerializationException();
		}

		public static UnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight> CreateUnionValue<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>(SerializationInfo info, Func<IUnionValue<TUnionDefinition>, TUnionType> unionFactory)
			where TUnionType : struct
			where TUnionDefinition : IUnionDefinition
		{
			switch (info.GetByte(StateName))
			{
				case 0:
					return new UnionValueOne<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>((TOne)info.GetValue(ValueName, typeof(TOne)), unionFactory);
				case 1:
					return new UnionValueTwo<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>((TTwo)info.GetValue(ValueName, typeof(TTwo)), unionFactory);
				case 2:
					return new UnionValueThree<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>((TThree)info.GetValue(ValueName, typeof(TThree)), unionFactory);
				case 3:
					return new UnionValueFour<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>((TFour)info.GetValue(ValueName, typeof(TFour)), unionFactory);
				case 4:
					return new UnionValueFive<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>((TFive)info.GetValue(ValueName, typeof(TFive)), unionFactory);
				case 5:
					return new UnionValueSix<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>((TSix)info.GetValue(ValueName, typeof(TSix)), unionFactory);
				case 6:
					return new UnionValueSeven<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>((TSeven)info.GetValue(ValueName, typeof(TSeven)), unionFactory);
				case 7:
					return new UnionValueEight<TUnionType, TUnionDefinition, TOne, TTwo, TThree, TFour, TFive, TSix, TSeven, TEight>((TEight)info.GetValue(ValueName, typeof(TEight)), unionFactory);
			}

			throw new UnionSerializationException();
		}

		public static void Serialize(SerializationInfo info, IUnionValue unionValue)
		{
			info.AddValue(StateName, (byte)unionValue.State);
			info.AddValue(ValueName, unionValue.Value);
		}
	}
}
