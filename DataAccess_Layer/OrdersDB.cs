using DataAccess_Layer.DataProvider;
using Restaurant;
using System.Collections.Generic;

namespace DataAccess_Layer
{
    public class OrdersDB : DataBase<List<Order>>
    {
        public OrdersDB(string fileName)
        {
            DataProvider = new JsonProvider<List<Order>>();
            setFilePath(fileName);
        }
        public override List<Order> Select()
        {
            return DataProvider.Deserialize(FilePath);
        }
        public override void Update(List<Order> elem)
        {
            DataProvider.Serialize(elem, FilePath);
        }
    }
}
