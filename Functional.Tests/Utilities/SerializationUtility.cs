using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Functional
{
#pragma warning disable SYSLIB0011 // Type or member is obsolete
	public static class SerializationUtility
	{
		public static Stream Serialize<T>(T obj)
		{
			var formatter = new BinaryFormatter();
			var stream = new MemoryStream();

			formatter.Serialize(stream, obj);

			stream.Position = 0;

			return stream;
		}

		public static T Deserialize<T>(Stream stream)
		{
			var formatter = new BinaryFormatter();

			return (T)formatter.Deserialize(stream);
		}

		public static T CloneViaSerialization<T>(T obj)
		{
			using (var stream = Serialize(obj))
				return Deserialize<T>(stream);
		}
	}
#pragma warning restore SYSLIB0011 // Type or member is obsolete
}
