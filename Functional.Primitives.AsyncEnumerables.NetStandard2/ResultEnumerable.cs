﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Functional
{
	public interface IResultEnumerable<TSuccess, TFailure> : IEnumerable<Result<TSuccess, TFailure>>
		where TSuccess : notnull
		where TFailure : notnull
	{
	}

	internal class ResultEnumerable<TSuccess, TFailure> : IResultEnumerable<TSuccess, TFailure>
		where TSuccess : notnull
		where TFailure : notnull
	{
		private readonly IEnumerable<Result<TSuccess, TFailure>> _source;

		public ResultEnumerable(IEnumerable<Result<TSuccess, TFailure>> source)
			=> _source = source ?? throw new ArgumentNullException(nameof(source));

		public IEnumerator<Result<TSuccess, TFailure>> GetEnumerator()
			=> _source.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> _source.GetEnumerator();
	}

	internal static class ResultEnumerable
	{
		public static IResultEnumerable<TSuccess, TFailure> AsResultEnumerable<TSuccess, TFailure>(this IEnumerable<Result<TSuccess, TFailure>> source)
			where TSuccess : notnull
			where TFailure : notnull
			=> new ResultEnumerable<TSuccess, TFailure>(source);
	}
}
