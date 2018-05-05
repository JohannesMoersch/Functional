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

		public static Option<T> None<T>()
			=> new Option<T>(false, default(T));

		public static Option<T> FromNullable<T>(T value)
			where T : class
			=> value != null
				? Some(value)
				: None<T>();

		public static Option<T> FromNullable<T>(T? value)
			where T : struct
			=> value.HasValue
				? Some(value.Value)
				: None<T>();

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

		public static Option<T> Try<T>(Func<T> valueFactory)
		{
			if (valueFactory == null)
				throw new ArgumentNullException(nameof(valueFactory));

			try
			{
				return Some(valueFactory.Invoke());
			}
			catch
			{
				return None<T>();
			}
		}

		public static async Task<Option<T>> Try<T>(Func<Task<T>> valueFactory)
		{
			if (valueFactory == null)
				throw new ArgumentNullException(nameof(valueFactory));

			try
			{
				return Some(await valueFactory.Invoke());
			}
			catch
			{
				return None<T>();
			}
		}
	}
}
