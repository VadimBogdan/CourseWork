using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;
using System.Collections.Generic;
namespace BusinessLogic_Layer_Tests.OrderService_Tests
{
    [TestClass]
    public class OrderService_AddOrder_Tests
    {
        private OrdersService OrderService = new OrdersService("test");
        [TestMethod]
        public void AddOrder_should_AddOrder_when_passing_OrderObject()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            Order order = new Order(new List<Dish> { dish }, 100);

            // act
            OrderService.AddOrder(order);

            // assert
            bool res = OrderService.GetListOfOrders().Contains(order);

            Assert.IsTrue(res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddOrder_should_throw_ArgumentNullException_when_passing_NullOrderRef()
        {
            // arrange
            Order order = null;

            // act
            OrderService.AddOrder(order);

            // assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddOrder_should_throw_ArgumentException_when_passing_OrderWithNoDishes()
        {
            // arrange
            Order order = new Order(new List<Dish>(), 100);

            // act
            OrderService.AddOrder(order);

            // assert
        }
    }
}
