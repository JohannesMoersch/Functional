namespace Functional.Unions;

public static class AnalyzerDiagnosticDescriptors
{
	public static string DiagnosticIdPrefix => "DU";

	public static string GetDiagnosticId(int number)
		=> $"{DiagnosticIdPrefix}{number:D4}";

	public static DiagnosticDescriptor DuplicateTypeInDiscriminatedUnion { get; } = new DiagnosticDescriptor
	(
		id: "DU0001",
		title: "Duplicate Type",
		messageFormat: "Duplicate type \"{0}\" in discriminated union.",
		category: "Generator",
		DiagnosticSeverity.Error,
		isEnabledByDefault: true
	);

	public static DiagnosticDescriptor DuplicateTypeNameInDiscriminatedUnion { get; } = new DiagnosticDescriptor
	(
		id: "DU0002",
		title: "Duplicate Type Name",
		messageFormat: "Duplicate type name \"{0}\" in discriminated union.",
		category: "Generator",
		DiagnosticSeverity.Error,
		isEnabledByDefault: true
	);
}
