using DataAccess_Layer.DataProvider;
using System.Collections.Generic;
namespace DataAccess_Layer
{
    public class IngredientsDB : DataBase<List<string>>
    {
        public IngredientsDB(string fileName)
        {
            DataProvider = new JsonProvider<List<string>>();
            setFilePath(fileName);
        }
        public override List<string> Select()
        {
            return DataProvider.Deserialize(FilePath);
        }
        public override void Update(List<string> elem)
        {
            DataProvider.Serialize(elem, FilePath);
        }
    }
}
