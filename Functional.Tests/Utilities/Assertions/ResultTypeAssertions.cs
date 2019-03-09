using System;
using FluentAssertions;
using FluentAssertions.Equivalency;
using FluentAssertions.Execution;

namespace Functional.Tests.Utilities.Assertions
{
	/// <summary>
	/// Defines assertions for <see cref="Result{TSuccess,TFailure}"/> type.
	/// </summary>
	/// <typeparam name="TSuccess">The success value type.</typeparam>
	/// <typeparam name="TFailure">The failure value type.</typeparam>
	public class ResultTypeAssertions<TSuccess, TFailure>
	{
		private readonly Result<TSuccess, TFailure> _subject;

		/// <summary>
		/// Initializes a new instance of the <see cref="ResultTypeAssertions{TSuccess, TFailure}"/> class.
		/// </summary>
		/// <param name="subject">The <see cref="Result{TSuccess, TFailure}"/> instance to verify.</param>
		public ResultTypeAssertions(Result<TSuccess, TFailure> subject)
		{
			_subject = subject;
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a successful result.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeSuccessful(string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.ForCondition(_subject.IsSuccess())
				.BecauseOf(because, becauseArgs)
				.FailWith($"Expected result to be successful, but received faulted result instead {{reason}}");
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a successful result.  If so, execute an action that can be used to perform additional assertions.
		/// </summary>
		/// <param name="additionalAssertionAction">The action used to perform additional assertions.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeSuccessful(Action<TSuccess> additionalAssertionAction, string because = "", params object[] becauseArgs)
		{
			if (additionalAssertionAction == null) throw new ArgumentNullException(nameof(additionalAssertionAction));

			BeSuccessful(because, becauseArgs);
			additionalAssertionAction(_subject.Success().ValueOrDefault());
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a specific successful result.  Useful error messages require <typeparamref name="TSuccess"/> to implement ToString().
		/// </summary>
		/// <param name="expectedValue">The expected successful value.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeSuccessfulWithExpectedValue(TSuccess expectedValue, string because = "", params object[] becauseArgs)
			=> BeSuccessfulWithExpectedValue(expectedValue, options => options, because, becauseArgs);

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a specific successful result.  Useful error messages require <typeparamref name="TSuccess"/> to implement ToString().
		/// </summary>
		/// <param name="expectedValue">The expected successful value.</param>
		/// <param name="config">A function to configure how objects are determined to be equivalent, to be used for this assertion only.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeSuccessfulWithExpectedValue(TSuccess expectedValue, Func<EquivalencyAssertionOptions<TSuccess>, EquivalencyAssertionOptions<TSuccess>> config, string because = "", params object[] becauseArgs)
		{
			BeSuccessful(because, becauseArgs);

			var value = _subject.Success().ValueOrDefault();
			value.Should().BeEquivalentTo(
				expectedValue,
				config,
				$"Expected result to be successful with value '{expectedValue}', but received successful result with value '{value}' instead.",
				becauseArgs);
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a faulted result.
		/// </summary>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeFaulted(string because = "", params object[] becauseArgs)
		{
			Execute.Assertion
				.ForCondition(!_subject.IsSuccess())
				.BecauseOf(because, becauseArgs)
				.FailWith($"Expected result to be faulted, but received successful result instead {{reason}}");
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a faulted result.  If so, execute an action that can be used to perform additional assertions.
		/// </summary>
		/// <param name="additionalAssertionAction">The action used to perform additional assertions.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeFaulted(Action<TFailure> additionalAssertionAction, string because = "", params object[] becauseArgs)
		{
			if (additionalAssertionAction == null) throw new ArgumentNullException(nameof(additionalAssertionAction));

			BeFaulted(because, becauseArgs);
			additionalAssertionAction(_subject.Failure().ValueOrDefault());
		}

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a specific faulted result.  Useful error messages require <typeparamref name="TFailure"/> to implement ToString().
		/// </summary>
		/// <param name="expectedValue">The expected faulted value.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeFaultedWithExpectedValue(TFailure expectedValue, string because = "", params object[] becauseArgs)
			=> BeFaultedWithExpectedValue(expectedValue, options => options, because, becauseArgs);

		/// <summary>
		/// Verifies that the subject <see cref="Result{TSuccess, TFailure}"/> holds a specific faulted result.  Useful error messages require <typeparamref name="TFailure"/> to implement ToString().
		/// </summary>
		/// <param name="expectedValue">The expected faulted value.</param>
		/// <param name="config">A function to configure how objects are determined to be equivalent, to be used for this assertion only.</param>
		/// <param name="because">Additional information for if the assertion fails.</param>
		/// <param name="becauseArgs">Zero or more objects to format using the placeholders in <paramref name="because"/>.</param>
		public void BeFaultedWithExpectedValue(TFailure expectedValue, Func<EquivalencyAssertionOptions<TFailure>, EquivalencyAssertionOptions<TFailure>> config, string because = "", params object[] becauseArgs)
		{
			BeFaulted(because, becauseArgs);

			var value = _subject.Failure().ValueOrDefault();
			value.Should().BeEquivalentTo(
				expectedValue,
				config,
				$"Expected result to be faulted with value '{expectedValue}', but received faulted result with value '{value}' instead.",
				becauseArgs);
		}
	}
}
