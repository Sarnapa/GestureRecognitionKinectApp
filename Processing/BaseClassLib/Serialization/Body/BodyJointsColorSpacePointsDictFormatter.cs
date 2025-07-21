using System.Numerics;
using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using MessagePack;
using MessagePack.Formatters;

namespace GestureRecognition.Processing.BaseClassLib.Serialization.Body
{
	public class BodyJointsColorSpacePointsDictFormatter: IMessagePackFormatter<BodyJointsColorSpacePointsDict>
	{
		public void Serialize(ref MessagePackWriter writer, BodyJointsColorSpacePointsDict value, MessagePackSerializerOptions options)
		{
			writer.WriteArrayHeader(value.Count);
			foreach (var kvp in value)
			{
				writer.Write((int)kvp.Key);
				writer.Write(kvp.Value.X);
				writer.Write(kvp.Value.Y);
			}
		}

		public BodyJointsColorSpacePointsDict Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			var dict = new BodyJointsColorSpacePointsDict();
			int count = reader.ReadArrayHeader();
			for (int i = 0; i < count; i++)
			{
				var key = (JointType)reader.ReadInt32();
				float x = reader.ReadSingle();
				float y = reader.ReadSingle();
				dict.Add(key, new Vector2(x, y));
			}
			return dict;
		}
	}
}
