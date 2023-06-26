namespace Functional.Unions
{
	public static class AttributeDataExtensions
	{
#pragma warning disable CS8600, CS8601 // Converting null literal or possible null value to non-nullable type. Possible null reference assignment.
		public static bool TryGetProperty<T>(this AttributeData attributeData, string propertyName, out T value)
		{
			foreach (var kvp in attributeData.NamedArguments)
			{
				if (kvp.Key == propertyName)
				{
					value = (T)kvp.Value.Value;
					return true;
				}
			}

			value = default;
			return false;
		}
#pragma warning restore CS8600, CS8601 // Converting null literal or possible null value to non-nullable type. Possible null reference assignment.
	}
}
