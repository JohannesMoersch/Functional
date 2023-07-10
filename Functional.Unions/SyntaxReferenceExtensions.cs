namespace Functional.Unions;

public static class SyntaxReferenceExtensions
{
	public static Location GetLocation(this SyntaxReference syntaxReference)
		=> Location.Create(syntaxReference.SyntaxTree, syntaxReference.Span);
}
