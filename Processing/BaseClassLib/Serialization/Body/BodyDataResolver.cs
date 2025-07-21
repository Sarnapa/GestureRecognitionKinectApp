using GestureRecognition.Processing.BaseClassLib.Structures.Body;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;

namespace GestureRecognition.Processing.BaseClassLib.Serialization.Body
{
	public class BodyDataResolver: IFormatterResolver
	{
		public static readonly IFormatterResolver Instance = new BodyDataResolver();

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			if (typeof(T) == typeof(BodyJointsColorSpacePointsDict))
			{
				return (IMessagePackFormatter<T>)new BodyJointsColorSpacePointsDictFormatter();
			}

			return StandardResolver.Instance.GetFormatter<T>();
		}
	}
}
