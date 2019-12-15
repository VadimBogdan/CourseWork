namespace DataAccess_Layer.DataProvider
{
    public interface IDataProvider<T> where T : new()
    {
        void Serialize(T elem, string path);
        T Deserialize(string path);
    }
}
