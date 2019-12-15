using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Restaurant
{
    [DataContract]
    public class Order : IComparable<Order>, IEquatable<Order>
    {
        [DataMember]
        private static int _orderIdCurrent = 1000;
        public static int OrderIdCurrent { get => _orderIdCurrent++; }
        [DataMember]
        public List<Dish> Dishes { get; private set; }
        [DataMember]
        public int TableNumber { get; private set; }
        [DataMember]
        public double Price { get; private set; }
        [DataMember]
        public int OrderId { get; private set; }
        public Order(int orderId)
        {
            this.OrderId = orderId;
        }
        public Order(List<Dish> dishes, int tableNumber)
        {
            this.Dishes = dishes;
            this.TableNumber = tableNumber;
            this.OrderId = OrderIdCurrent;
            this.Price = CalculatePrice();
        }
        public void setOrderPrice(double newOrderPrice)
        {
            this.Price = newOrderPrice;
        }
        public void setTableNumber(int tableNumber)
        {
            this.TableNumber = tableNumber;
        }
        public void removeOrderDish(Dish dish)
        {
            Dishes.Remove(dish);
        }
        public void addOrderDish(Dish dish)
        {
            Dishes.Add(dish);
        }
        private double CalculatePrice()
        {
            double totalPrice = 0;
            foreach(Dish dish in Dishes)
            {
                totalPrice += dish.DishPrice;
            }
            return totalPrice;
        }
        public int CompareTo(Order other)
        {
            if (other == null) return 1;

            return OrderId.CompareTo(other.OrderId);
        }

        public bool Equals(Order other)
        {
            if (other == null)
                return false;

            if (this.OrderId == other.OrderId)
                return true;
            else
                return false;
        }
        public IList<Dish> GetListOfDishesInOrder()
        {
            return Dishes;
        }
    }
}
