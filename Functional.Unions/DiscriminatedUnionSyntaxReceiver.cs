using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Functional.Unions;

public sealed class DiscriminatedUnionSyntaxReceiver : ISyntaxReceiver
{
	private readonly List<TypeDeclarationSyntax> _candidates = new List<TypeDeclarationSyntax>();
	public IReadOnlyList<TypeDeclarationSyntax> Candidates => _candidates;

	public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
	{
		if (syntaxNode is TypeDeclarationSyntax typeDeclarationSyntax && typeDeclarationSyntax.BaseList is not null)
		{
			var isCandidate = typeDeclarationSyntax
				.BaseList
				.Types
				.Select(syntax => syntax.Type.ToString())
				.Any(text => text.Contains(Code.DiscriminatedUnion.Name));

			if (isCandidate)
				_candidates.Add(typeDeclarationSyntax);
		}
	}
}
