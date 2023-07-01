namespace Functional.Unions;

public static class AnalyzerDiagnosticDescriptors
{
	public static DiagnosticDescriptor DuplicateTypeNameInDiscriminatedUnion { get; } = new DiagnosticDescriptor
	(
		id: "DU0001",
		title: "Duplicate Type Name",
		messageFormat: "Duplicate type name \"{0}\" in discriminated union.",
		category: "Generator",
		DiagnosticSeverity.Error,
		isEnabledByDefault: true
	);
}
