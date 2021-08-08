using System;
using System.Collections.Generic;
using System.ComponentModel;
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

		[Obsolete("Please use .SomeAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Option<T>> Some<T>(Task<T> value)
			=> SomeAsync(value);

		public static async Task<Option<T>> SomeAsync<T>(Task<T> value)
			=> Some(await value);

		public static Option<T> None<T>()
#pragma warning disable CS8604 // Possible null reference argument.
			=> new Option<T>(false, default);
#pragma warning restore CS8604 // Possible null reference argument.

		public static Option<T> FromNullable<T>(T? value)
			where T : class
			=> value != null
				? Some(value)
				: None<T>();

		[Obsolete("Please use .FromNullableAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Option<T>> FromNullable<T>(Task<T?> value)
			where T : class
			=> FromNullableAsync(value);

		public static async Task<Option<T>> FromNullableAsync<T>(Task<T?> value)
			where T : class
			=> FromNullable(await value);

		public static Option<T> FromNullable<T>(T? value)
			where T : struct
			=> value.HasValue
				? Some(value.Value)
				: None<T>();

		[Obsolete("Please use .FromNullableAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Option<T>> FromNullable<T>(Task<T?> value)
			where T : struct
			=> FromNullableAsync(value);

		public static async Task<Option<T>> FromNullableAsync<T>(Task<T?> value)
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

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Option<T>> Create<T>(bool isSome, Func<Task<T>> valueFactory)
			=> CreateAsync(isSome, valueFactory);
		
		public static async Task<Option<T>> CreateAsync<T>(bool isSome, Func<Task<T>> valueFactory)
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
