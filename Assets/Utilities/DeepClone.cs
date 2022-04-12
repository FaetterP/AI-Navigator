using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Utilities
{
    static class DeepClone
    {
        public static MLP Clone(this MLP a)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (MLP)formatter.Deserialize(stream);
            }
        }
    }
}
