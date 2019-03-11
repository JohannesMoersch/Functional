namespace Functional.Tests.Utilities.Assertions
{
	/// <summary>
	/// Defines additional fluent assertion gateways for types defined in Functional.Primitives namespace.
	/// </summary>
	public static class FunctionalPrimitiveAssertions
	{
		/// <summary>
		/// Returns a <see cref="Result{TSuccess,TFailure}"/> object that can be used to assert the current <see cref="Result{TSuccess, TFailure}"/>.
		/// </summary>
		/// <typeparam name="TSuccess">The success object type.</typeparam>
		/// <typeparam name="TFailure">The failure object type.</typeparam>
		/// <param name="result">The result.</param>
		/// <returns></returns>
		public static ResultTypeAssertions<TSuccess, TFailure> Should<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
		{
			return new ResultTypeAssertions<TSuccess, TFailure>(result);
		}

		/// <summary>
		/// Returns a <see cref="OptionTypeAssertions{T}"/> object that is used to assert the current <see cref="Option{T}"/>.
		/// </summary>
		/// <typeparam name="T">The option type.</typeparam>
		/// <param name="option">The option.</param>
		/// <returns></returns>
		public static OptionTypeAssertions<T> Should<T>(this Option<T> option)
		{
			return new OptionTypeAssertions<T>(option);
		}
	}
}
