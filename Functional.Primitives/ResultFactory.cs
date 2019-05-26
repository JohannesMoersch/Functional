using System;
using System.Collections.Generic;
using System.ComponentModel;
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

			return new Result<TSuccess, TFailure>(true, success, default);
		}

		[Obsolete("Please use .SuccessAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<TSuccess, TFailure>> Success<TSuccess, TFailure>(Task<TSuccess> success)
			=> SuccessAsync<TSuccess, TFailure>(success);
		
		public static async Task<Result<TSuccess, TFailure>> SuccessAsync<TSuccess, TFailure>(Task<TSuccess> success)
			=> Success<TSuccess, TFailure>(await success);

		public static Result<TSuccess, TFailure> Failure<TSuccess, TFailure>(TFailure failure)
		{
			if (failure == null)
				throw new ArgumentNullException(nameof(failure));

			return new Result<TSuccess, TFailure>(false, default, failure);
		}

		[Obsolete("Please use .FailureAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<TSuccess, TFailure>> Failure<TSuccess, TFailure>(Task<TFailure> failure)
			=> FailureAsync<TSuccess, TFailure>(failure);

		public static async Task<Result<TSuccess, TFailure>> FailureAsync<TSuccess, TFailure>(Task<TFailure> failure)
			=> Failure<TSuccess, TFailure>(await failure);

		public static Result<TSuccess, TFailure> Create<TSuccess, TFailure>(bool isSuccess, TSuccess success, TFailure failure)
			=> isSuccess
				? Success<TSuccess, TFailure>(success)
				: Failure<TSuccess, TFailure>(failure);

		public static Result<TSuccess, TFailure> Create<TSuccess, TFailure>(bool isSuccess, TSuccess success, Func<TFailure> failureFactory)
		{
			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return isSuccess
				? Success<TSuccess, TFailure>(success)
				: Failure<TSuccess, TFailure>(failureFactory.Invoke());
		}

		public static async Task<Result<TSuccess, TFailure>> CreateAsync<TSuccess, TFailure>(bool isSuccess, TSuccess success, Func<Task<TFailure>> failureFactory)
		{
			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return isSuccess
				? Success<TSuccess, TFailure>(success)
				: Failure<TSuccess, TFailure>(await failureFactory.Invoke());
		}

		public static Result<TSuccess, TFailure> Create<TSuccess, TFailure>(bool isSuccess, Func<TSuccess> successFactory, TFailure failure)
		{
			if (successFactory == null)
				throw new ArgumentNullException(nameof(successFactory));

			return isSuccess
				? Success<TSuccess, TFailure>(successFactory.Invoke())
				: Failure<TSuccess, TFailure>(failure);
		}

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

		public static async Task<Result<TSuccess, TFailure>> CreateAsync<TSuccess, TFailure>(bool isSuccess, Func<TSuccess> successFactory, Func<Task<TFailure>> failureFactory)
		{
			if (successFactory == null)
				throw new ArgumentNullException(nameof(successFactory));

			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return isSuccess
				? Success<TSuccess, TFailure>(successFactory.Invoke())
				: Failure<TSuccess, TFailure>(await failureFactory.Invoke());
		}

		public static async Task<Result<TSuccess, TFailure>> CreateAsync<TSuccess, TFailure>(bool isSuccess, Func<Task<TSuccess>> successFactory, TFailure failure)
		{
			if (successFactory == null)
				throw new ArgumentNullException(nameof(successFactory));

			return isSuccess
				? Success<TSuccess, TFailure>(await successFactory.Invoke())
				: Failure<TSuccess, TFailure>(failure);
		}

		public static async Task<Result<TSuccess, TFailure>> CreateAsync<TSuccess, TFailure>(bool isSuccess, Func<Task<TSuccess>> successFactory, Func<TFailure> failureFactory)
		{
			if (successFactory == null)
				throw new ArgumentNullException(nameof(successFactory));

			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return isSuccess
				? Success<TSuccess, TFailure>(await successFactory.Invoke())
				: Failure<TSuccess, TFailure>(failureFactory.Invoke());
		}

		public static async Task<Result<TSuccess, TFailure>> CreateAsync<TSuccess, TFailure>(bool isSuccess, Func<Task<TSuccess>> successFactory, Func<Task<TFailure>> failureFactory)
		{
			if (successFactory == null)
				throw new ArgumentNullException(nameof(successFactory));

			if (failureFactory == null)
				throw new ArgumentNullException(nameof(failureFactory));

			return isSuccess
				? Success<TSuccess, TFailure>(await successFactory.Invoke())
				: Failure<TSuccess, TFailure>(await failureFactory.Invoke());
		}

		[Obsolete("Please use .CreateAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<TSuccess, TFailure>> Create<TSuccess, TFailure>(bool isSuccess, Func<Task<TSuccess>> successFactory, Func<Task<TFailure>> failureFactory)
			=> CreateAsync(isSuccess, successFactory, failureFactory);

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

		public static Result<Unit, Exception> Try(Action successFactory)
			=> successFactory == null ? throw new ArgumentNullException(nameof(successFactory)) : Try(() => { successFactory.Invoke(); return Functional.Unit.Value; });

		[Obsolete("Please use .TryAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<TSuccess, Exception>> Try<TSuccess>(Func<Task<TSuccess>> successFactory)
			=> TryAsync(successFactory);

		public static async Task<Result<TSuccess, Exception>> TryAsync<TSuccess>(Func<Task<TSuccess>> successFactory)
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

		[Obsolete("Please use .TryAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<Unit, Exception>> Try(Func<Task> successFactory)
			=> TryAsync(successFactory);

		public static Task<Result<Unit, Exception>> TryAsync(Func<Task> successFactory)
			=> successFactory == null ? throw new ArgumentNullException(nameof(successFactory)) : TryAsync(async () => { await successFactory.Invoke(); return Functional.Unit.Value; });

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

		public static Result<Unit, TFailure> Try<TFailure>(Action successFactory, Func<Exception, TFailure> @catch)
			=> successFactory == null ? throw new ArgumentNullException(nameof(successFactory)) : Try(() => { successFactory.Invoke(); return Functional.Unit.Value; }, @catch);

		[Obsolete("Please use .TryAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<TSuccess, TFailure>> Try<TSuccess, TFailure>(Func<Task<TSuccess>> successFactory, Func<Exception, TFailure> @catch)
			=> TryAsync(successFactory, @catch);

		public static async Task<Result<TSuccess, TFailure>> TryAsync<TSuccess, TFailure>(Func<Task<TSuccess>> successFactory, Func<Exception, TFailure> @catch)
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

		[Obsolete("Please use .TryAsync() instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Task<Result<Unit, TFailure>> Try<TFailure>(Func<Task> successFactory, Func<Exception, TFailure> @catch)
			=> TryAsync(successFactory, @catch);

		public static Task<Result<Unit, TFailure>> TryAsync<TFailure>(Func<Task> successFactory, Func<Exception, TFailure> @catch)
			=> successFactory == null ? throw new ArgumentNullException(nameof(successFactory)) : TryAsync(async () => { await successFactory.Invoke(); return Functional.Unit.Value; }, @catch);

		public static Result<Unit, TFailure> Unit<TFailure>()
			=> Success<Unit, TFailure>(Functional.Unit.Value);

		public static Result<Unit, TFailure> Where<TFailure>(bool isSuccess, TFailure failure)
			=> Create(isSuccess, Functional.Unit.Value, failure);

		public static Result<Unit, TFailure> Where<TFailure>(bool isSuccess, Func<TFailure> failureFactory)
			=> Create(isSuccess, () => Functional.Unit.Value, failureFactory);
	}
}
