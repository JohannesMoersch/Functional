// Polyfills required until UnionAttribute and IUnion are included in the .NET runtime.
// See https://github.com/dotnet/core/blob/main/release-notes/11.0/preview/preview3/csharp.md

namespace System.Runtime.CompilerServices
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
	public sealed class UnionAttribute : Attribute { }

	public interface IUnion
	{
		object? Value { get; }
	}
}
