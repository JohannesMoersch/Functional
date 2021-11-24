using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public interface IOptionEnumerable<TValue> : IEnumerable<Option<TValue>>
		where TValue : notnull
	{
	}

	internal class OptionEnumerable<TValue> : IOptionEnumerable<TValue>
		where TValue : notnull
	{
		private readonly IEnumerable<Option<TValue>> _source;

		public OptionEnumerable(IEnumerable<Option<TValue>> source)
			=> _source = source ?? throw new ArgumentNullException(nameof(source));

		public IEnumerator<Option<TValue>> GetEnumerator()
			=> _source.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> _source.GetEnumerator();
	}

	internal static class OptionEnumerable
	{
		public static IOptionEnumerable<TValue> AsOptionEnumerable<TValue>(this IEnumerable<Option<TValue>> source)
			where TValue : notnull
			=> new OptionEnumerable<TValue>(source);
	}
}
