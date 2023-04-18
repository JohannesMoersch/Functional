namespace Functional;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
internal class AllowAllocationsAttribute : Attribute
{
	public readonly bool AllowBox;
	public readonly bool AllowNewArr;
	public readonly Type[] AllowNewObjTypes;

	public AllowAllocationsAttribute(bool allowBox = false, bool allowNewArr = false, params Type[] allowNewObjTypes)
	{
		AllowBox = allowBox;
		AllowNewArr = allowNewArr;
		AllowNewObjTypes = allowNewObjTypes;
	}
}
