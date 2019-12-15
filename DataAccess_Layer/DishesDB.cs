using DataAccess_Layer.DataProvider;
using Restaurant;
using System.Collections.Generic;

namespace DataAccess_Layer
{
    public class DishesDB : DataBase<List<Dish>>
    {
        public DishesDB(string fileName)
        {
            DataProvider = new JsonProvider<List<Dish>>();
            setFilePath(fileName);
        }
        public override List<Dish> Select()
        {
            return DataProvider.Deserialize(FilePath);
        }
        public override void Update(List<Dish> elem)
        {
            DataProvider.Serialize(elem, FilePath);
        }
    }
}
