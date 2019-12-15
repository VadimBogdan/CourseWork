using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;
using System.Collections.Generic;
namespace BusinessLogic_Layer_Tests.OrderService_Tests
{
    [TestClass]
    public class OrderService_RemoveOrder_Tests
    {
        private OrdersService OrderService = new OrdersService("test");
        [TestMethod]
        public void RemoveOrder_should_RemoveOrder_after_passing_OrderId()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            Order order = new Order(new List<Dish> { dish }, 100);
            int id = order.OrderId;


            // act
            OrderService.AddOrder(order);
            OrderService.RemoveOrder(id);

            // assert
            bool res = OrderService.GetListOfOrders().Contains(order);

            Assert.IsFalse(res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveOrder_should_throw_ArgumentException_when_passing_NonExistentOrderId()
        {
            // arrange
            int id = 10015;

            // act
            OrderService.RemoveOrder(id);

            // assert
        }
    }
}
