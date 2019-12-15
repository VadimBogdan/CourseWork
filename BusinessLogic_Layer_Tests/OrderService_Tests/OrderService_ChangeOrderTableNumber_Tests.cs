using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;
using System.Collections.Generic;
namespace BusinessLogic_Layer_Tests.OrderService_Tests
{
    [TestClass]
    public class OrderService_ChangeOrderTableNumber_Tests
    {
        private OrdersService OrderService = new OrdersService("test");
        [TestMethod]
        public void ChangeOrderTableNumber_should_ChangeOrderTableNumber_after_passing_OrderIdAndNewTableNumber()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            Order order = new Order(new List<Dish> { dish }, 100);
            int newTableNumber = 150;
            int orderId = order.OrderId;


            // act
            OrderService.AddOrder(order);
            OrderService.ChangeOrderTableNumber(orderId, newTableNumber);

            // assert
            int res = OrderService.GetListOfOrders()[0].TableNumber;

            Assert.AreEqual(newTableNumber, res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeOrderTableNumber_should_throw_ArgumentException_when_trying_to_ChangeNonExistentOrder()
        {
            // arrange
            int orderId = 1000;
            int newTable = 200;

            // act
            OrderService.ChangeOrderTableNumber(orderId, newTable);

            // assert
        }
    }
}
