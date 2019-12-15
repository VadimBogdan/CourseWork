using System.IO;
using System.Runtime.Serialization.Json;
namespace DataAccess_Layer.DataProvider
{
    public class JsonProvider<T> : IDataProvider<T> where T : new()
    {
        public T Deserialize(string path)
        {
            using (Stream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (stream.Length == 0)
                {
                    return new T();
                }
                DataContractJsonSerializer sr = new DataContractJsonSerializer(typeof(T));
                return (T)sr.ReadObject(stream);
            }

        }

        public void Serialize(T elem, string path)
        {
            using (Stream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                DataContractJsonSerializer sr = new DataContractJsonSerializer(typeof(T));
                sr.WriteObject(stream, elem);
            }
        }
    }
}