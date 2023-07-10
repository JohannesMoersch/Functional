using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace Functional.Unions;

public static class SemanticModelExtensions
{
	public record DerivedTypeMatch(INamedTypeSymbol DiscriminatedUnion, TypeDeclarationSyntax DiscriminatedUnionSyntaxNode, INamedTypeSymbol DiscriminatedUnionInterface, GenericNameSyntax DiscriminatedUnionInterfaceSyntaxNode, IReadOnlyList<DerivedTypeMatch.TypeArgument> DiscriminatedUnionInterfaceTypeArguments)
	{
		public record TypeArgument(ITypeSymbol? TypeSymbol, TypeSyntax SyntaxNode);
	}

	public static IEnumerable<DerivedTypeMatch> GetDiscriminatedUnionTypes(this SemanticModel semanticModel, SyntaxNode syntaxNode, IImmutableSet<INamedTypeSymbol> discriminatedUnionInterfaceTypes, CancellationToken cancellationToken)
	{
		var matches = new List<DerivedTypeMatch>();

		new NamedTypeSymbolFinder(semanticModel, discriminatedUnionInterfaceTypes, matches.Add, cancellationToken).Visit(syntaxNode);

		return matches;
	}

	private class NamedTypeSymbolFinder : CSharpSyntaxWalker
	{
		private readonly SemanticModel _semanticModel;
		private readonly IImmutableSet<INamedTypeSymbol> _discriminatedUnionInterfaceTypes;
		private readonly Action<DerivedTypeMatch> _handleDiscriminatedUnionType;
		private readonly CancellationToken _cancellationToken;

		public NamedTypeSymbolFinder(SemanticModel semanticModel, IImmutableSet<INamedTypeSymbol> discriminatedUnionInterfaceTypes, Action<DerivedTypeMatch> handleDiscriminatedUnionType, CancellationToken cancellationToken)
		{
			_semanticModel = semanticModel;
			_discriminatedUnionInterfaceTypes = discriminatedUnionInterfaceTypes;
			_handleDiscriminatedUnionType = handleDiscriminatedUnionType;
			_cancellationToken = cancellationToken;
		}

		public override void VisitBaseList(BaseListSyntax node)
		{
			if (node.Parent is not TypeDeclarationSyntax parentSyntaxNode || _semanticModel.GetDeclaredSymbol(parentSyntaxNode, _cancellationToken) is not INamedTypeSymbol parentTypeSymbol)
				return;

			var types = node
				.Types
				.Select(baseTypeSyntax => baseTypeSyntax.Type)
				.OfType<GenericNameSyntax>()
				.Select(baseTypeSyntax => _semanticModel.GetTypeInfo(baseTypeSyntax, _cancellationToken).Type is INamedTypeSymbol typeSymbol
					? new DerivedTypeMatch
					(
						parentTypeSymbol, 
						parentSyntaxNode, 
						typeSymbol, 
						baseTypeSyntax,
						GetTypeArguments(baseTypeSyntax)
					)
					: null
				)
				.OfType<DerivedTypeMatch>()
				.Where(type => _discriminatedUnionInterfaceTypes.Contains(type.DiscriminatedUnionInterface) || _discriminatedUnionInterfaceTypes.Contains(type.DiscriminatedUnionInterface.ConstructedFrom));

			foreach (var type in types)
				_handleDiscriminatedUnionType.Invoke(type);

			base.VisitBaseList(node);
		}

		private DerivedTypeMatch.TypeArgument[] GetTypeArguments(GenericNameSyntax baseTypeSyntax)
			=> baseTypeSyntax
				.TypeArgumentList
				.Arguments
				.Select(argumentSyntax => new DerivedTypeMatch.TypeArgument(_semanticModel.GetTypeInfo(argumentSyntax, _cancellationToken).Type, argumentSyntax))
				.ToArray();
	}
}
