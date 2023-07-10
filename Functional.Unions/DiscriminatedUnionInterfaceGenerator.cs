namespace Functional.Unions;

[Generator]
public sealed class DiscriminatedUnionInterfaceGenerator : ISourceGenerator
{
	public void Initialize(GeneratorInitializationContext context) 
		=> context.RegisterForPostInitialization(c => c.AddSource("DiscriminatedUnionAttribute.g.cs", Code.DiscriminatedUnion.Interface.GetCode()));

	public void Execute(GeneratorExecutionContext context) { }
}
