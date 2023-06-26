using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Functional.Unions;

public sealed class DiscriminatedUnionSyntaxReceiver : ISyntaxReceiver
{
	private readonly List<TypeDeclarationSyntax> _candidates = new List<TypeDeclarationSyntax>();
	public IReadOnlyList<TypeDeclarationSyntax> Candidates => _candidates;

	public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
	{
		if (syntaxNode is TypeDeclarationSyntax typeDeclarationSyntax)
		{
			var typeAttributes = typeDeclarationSyntax
				.AttributeLists
				.SelectMany(list => list.Attributes);

			if (typeAttributes.Any(a => a.Name.ToString().Contains("DiscriminatedUnion")))
				_candidates.Add(typeDeclarationSyntax);
		}
	}
}
