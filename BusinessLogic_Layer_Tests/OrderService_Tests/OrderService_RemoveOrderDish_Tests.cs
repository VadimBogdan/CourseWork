using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;
using System.Collections.Generic;
namespace BusinessLogic_Layer_Tests.OrderService_Tests
{
    [TestClass]
    public class OrderService_RemoveOrderDish_Tests
    {
        private OrdersService OrderService = new OrdersService("test");
        [TestMethod]
        public void RemoveOrderDish_should_RemoveOrderDish_after_passing_DishObject()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            Order order = new Order(new List<Dish> { dish }, 100);
            int orderId = order.OrderId;


            // act
            OrderService.AddOrder(order);
            OrderService.RemoveOrderDish(orderId, dish);

            // assert
            bool res = OrderService.GetListOfOrders()[0].GetListOfDishesInOrder().Contains(dish);

            Assert.IsFalse(res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveOrderDish_should_throw_ArgumentException_when_passing_NonExistentOrderId()
        {
            // arrange
            Dish dish = new Dish("Mashed potatoes with mushrooms");
            int orderId = 1005;

            // act
            OrderService.RemoveOrderDish(orderId, dish);

            // assert
        }
    }
}
