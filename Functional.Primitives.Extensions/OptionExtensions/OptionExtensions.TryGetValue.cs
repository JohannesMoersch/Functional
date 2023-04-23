namespace Functional;

public static partial class OptionExtensions
{
#pragma warning disable CS8603 // Possible null reference return.
	private static class DelegateCache<T>
	{
		public static readonly Func<T, T> Passthrough = _ => _;
		public static readonly Func<T> Default = () => default;
		public static readonly Func<T, bool> True = _ => true;
		public static readonly Func<bool> False = () => false;
	}
#pragma warning restore CS8603 // Possible null reference return.

	public static bool TryGetValue<TValue>(this Option<TValue> option, [MaybeNullWhen(false)] out TValue some)
		where TValue : notnull
	{
		some = option.Match(DelegateCache<TValue>.Passthrough, DelegateCache<TValue>.Default);

		return option.Match(DelegateCache<TValue>.True, DelegateCache<TValue>.False);
	}
}
