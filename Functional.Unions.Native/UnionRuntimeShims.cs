// Shims required by the prototype Roslyn compiler that generates native union types.
// The compiler lowers union declarations to reference these BCL types, which do not yet
// exist in the official .NET 11 preview SDK, so we polyfill them here.

namespace System.Runtime.CompilerServices
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
	internal sealed class UnionAttribute : Attribute { }
}

namespace System.Runtime.CompilerServices
{
	internal interface IUnion { }
}
