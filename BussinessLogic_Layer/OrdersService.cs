using System;
using System.Collections.Generic;
using DataAccess_Layer;
using Restaurant;
namespace BusinessLogic_Layer
{
    public class OrdersService
    {
        private List<Order> Orders { get; set; }
        private OrdersDB OrdersDB { get; set; }
        public OrdersService(string DbfileName)
        {
            OrdersDB = new OrdersDB(DbfileName);
            Orders = OrdersDB.Select();
        }
        public void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("Посилання на null.");
            }
            if (order.Dishes.Count == 0)
            {
                throw new ArgumentException("Замовлення без страв.");
            }
            Orders.Add(order);
        }
        public void RemoveOrder(int orderId)
        {
            Order order = new Order(orderId);
            if (!Orders.Contains(order))
            {
                throw new ArgumentException("Замовлення з таким номером не існує.");
            }
            Orders.Remove(order);
        }
        public void ChangeOrderPrice(int orderId, double newPrice)
        {
            if (newPrice < 0)
            {
                throw new ArgumentOutOfRangeException("Нова ціна не може бути негативним числом.");
            }
            Order order = new Order(orderId);
            if (!Orders.Contains(order))
            {
                throw new ArgumentException("Замовлення з таким номером не існує.");
            }
            int index = Orders.IndexOf(order);
            Orders[index].setOrderPrice(newPrice);
        }
        public void ChangeOrderTableNumber(int orderId, int newTableNumber)
        {
            Order order = new Order(orderId);
            if (!Orders.Contains(order))
            {
                throw new ArgumentException("Замовлення з таким номером не існує.");
            }
            int index = Orders.IndexOf(order);
            int oldTableNumber = Orders[index].TableNumber;
            if (oldTableNumber == newTableNumber)
            {
                throw new ArgumentException("Номер нового столика з попереднім співпадають.");
            }
            Orders[index].setTableNumber(newTableNumber);
        }
        public void RemoveOrderDish(int orderId, Dish dish)
        {    
            if (dish == null)
            {
                throw new ArgumentNullException("Поcилання на null.");
            }
            Order order = new Order(orderId);
            if (!Orders.Contains(order))
            {
                throw new ArgumentException("Замовлення з таким номером не існує.");
            }
            int index = Orders.IndexOf(order);
            Orders[index].removeOrderDish(dish);
        }
        public void AddOrderDish(int orderId, Dish dish)
        {
            if (dish == null)
            {
                throw new ArgumentNullException("Поcилання на null.");
            }
            Order order = new Order(orderId);
            if (!Orders.Contains(order))
            {
                throw new ArgumentException("Замовлення з таким номером не існує.");
            }
            int index = Orders.IndexOf(order);
            Orders[index].addOrderDish(dish);
        }
        public IList<Order> GetListOfOrders()
        {
            return Orders;
        }
        public void Update()
        {
            OrdersDB.Update(Orders);
        }
/*        ~OrdersService()
        {
            Update();
        }*/
    }
}
