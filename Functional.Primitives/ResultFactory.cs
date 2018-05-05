using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
	public static class Result
	{
		public static Result<TSuccess, TFailure> Success<TSuccess, TFailure>(TSuccess success)
		{
			if (success == null)
				throw new ArgumentNullException(nameof(success));

			return new Result<TSuccess, TFailure>(true, success, default(TFailure));
		}

		public static Result<TSuccess, TFailure> Failure<TSuccess, TFailure>(TFailure failure)
		{
			if (failure == null)
				throw new ArgumentNullException(nameof(failure));

			return new Result<TSuccess, TFailure>(false, default(TSuccess), failure);
		}

		public static Result<TSuccess, TFailure> Create<TSuccess, TFailure>(bool isSuccess, TSuccess success, TFailure failure)
			=> isSuccess
				? Success<TSuccess, TFailure>(success)
				: Failure<TSuccess, TFailure>(failure);

		public static Result<TSuccess, TFailure> Create<TSuccess, TFailure>(bool isSuccess, Func<TSuccess> successFactory, Func<TFailure> failureFactory)
		{
			if (successFactory == null)
				throw new ArgumentNullException(nameof(successFactory));

			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return isSuccess
				? Success<TSuccess, TFailure>(successFactory.Invoke())
				: Failure<TSuccess, TFailure>(failureFactory.Invoke());
		}

		public static async Task<Result<TSuccess, TFailure>> Create<TSuccess, TFailure>(bool isSuccess, Func<Task<TSuccess>> successFactory, Func<Task<TFailure>> failureFactory)
		{
			if (successFactory == null)
				throw new ArgumentNullException(nameof(successFactory));

			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return isSuccess
				? Success<TSuccess, TFailure>(await successFactory.Invoke())
				: Failure<TSuccess, TFailure>(await failureFactory.Invoke());
		}

		public static Result<TSuccess, Exception> Try<TSuccess>(Func<TSuccess> successFactory)
		{
			if (successFactory == null)
				throw new ArgumentNullException(nameof(successFactory));

			try
			{
				return Success<TSuccess, Exception>(successFactory.Invoke());
			}
			catch (Exception ex)
			{
				return Failure<TSuccess, Exception>(ex);
			}
		}

		public static async Task<Result<TSuccess, Exception>> Try<TSuccess>(Func<Task<TSuccess>> successFactory)
		{
			if (successFactory == null)
				throw new ArgumentNullException(nameof(successFactory));

			try
			{
				return Success<TSuccess, Exception>(await successFactory.Invoke());
			}
			catch (Exception ex)
			{
				return Failure<TSuccess, Exception>(ex);
			}
		}

		public static Result<TSuccess, TFailure> Try<TSuccess, TFailure>(Func<TSuccess> successFactory, Func<Exception, TFailure> @catch)
		{
			if (successFactory == null)
				throw new ArgumentNullException(nameof(successFactory));

			if (@catch == null)
				throw new ArgumentNullException(nameof(@catch));

			try
			{
				return Success<TSuccess, TFailure>(successFactory.Invoke());
			}
			catch (Exception ex)
			{
				return Failure<TSuccess, TFailure>(@catch.Invoke(ex));
			}
		}

		public static async Task<Result<TSuccess, TFailure>> Try<TSuccess, TFailure>(Func<Task<TSuccess>> successFactory, Func<Exception, TFailure> @catch)
		{
			if (successFactory == null)
				throw new ArgumentNullException(nameof(successFactory));

			if (@catch == null)
				throw new ArgumentNullException(nameof(@catch));

			try
			{
				return Success<TSuccess, TFailure>(await successFactory.Invoke());
			}
			catch (Exception ex)
			{
				return Failure<TSuccess, TFailure>(@catch.Invoke(ex));
			}
		}
	}
}
