using DataAccess_Layer.DataProvider;
using System.IO;
namespace DataAccess_Layer
{
    public abstract class DataBase<T> where T : new()
    {
        protected string FilePath { get; set; }
        protected IDataProvider<T> DataProvider { get; set; }
        public abstract void Update(T elem);
        public abstract T Select();
        protected void setFilePath(string fileName)
        {
            if (DataProvider is JsonProvider<T>)
            {
                FilePath = Path.Combine(Directory.GetCurrentDirectory(), fileName + ".json");
            }
        }
    }
}
