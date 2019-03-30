using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class Option
	{
		public static Option<T> Some<T>(T value)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			return new Option<T>(true, value);
		}

		public static async Task<Option<T>> Some<T>(Task<T> value)
			=> Some(await value);

		public static Option<T> None<T>()
			=> new Option<T>(false, default);

		public static Option<T> FromNullable<T>(T value)
			where T : class
			=> value != null
				? Some(value)
				: None<T>();

		public static async Task<Option<T>> FromNullable<T>(Task<T> value)
			where T : class
			=> FromNullable(await value);

		public static Option<T> FromNullable<T>(T? value)
			where T : struct
			=> value.HasValue
				? Some(value.Value)
				: None<T>();

		public static async Task<Option<T>> FromNullable<T>(Task<T?> value)
			where T : struct
			=> FromNullable(await value);

		public static Option<T> Create<T>(bool isSome, T value)
			=> isSome
				? Some(value)
				: None<T>();

		public static Option<T> Create<T>(bool isSome, Func<T> valueFactory)
		{
			if (valueFactory == null)
				throw new ArgumentNullException(nameof(valueFactory));

			return isSome
				? Some(valueFactory.Invoke())
				: None<T>();
		}

		public static async Task<Option<T>> Create<T>(bool isSome, Func<Task<T>> valueFactory)
		{
			if (valueFactory == null)
				throw new ArgumentNullException(nameof(valueFactory));

			return isSome
				? Some(await valueFactory.Invoke())
				: None<T>();
		}

		public static Option<Unit> Unit()
			=> Some(Functional.Unit.Value);

		public static Option<Unit> Where(bool isSuccess)
			=> Create(isSuccess, Functional.Unit.Value);
	}
}
