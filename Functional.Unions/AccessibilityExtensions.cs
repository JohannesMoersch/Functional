namespace Functional.Unions;

public static class AccessibilityExtensions
{
	public static bool IsAccessibleInternally(this Accessibility accessibility)
		=> accessibility == Accessibility.Public
			|| accessibility == Accessibility.Internal
			|| accessibility == Accessibility.ProtectedOrInternal;
}
