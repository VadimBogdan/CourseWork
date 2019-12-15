using System.Collections.Generic;
using DataAccess_Layer.DataProvider;
namespace DataAccess_Layer
{
    public class IngredientsDB : DataBase<Dictionary<string, string>>
    {
        public IngredientsDB(string fileName)
        {
            DataProvider = new JsonProvider<Dictionary<string, string>>();
            setFilePath(fileName);
        }
        public override Dictionary<string, string> Select()
        {
            return DataProvider.Deserialize(FilePath);
        }
        public override void Update(Dictionary<string, string> elem)
        {
            DataProvider.Serialize(elem, FilePath);
        }
    }
}
