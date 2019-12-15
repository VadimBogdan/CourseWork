using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;
using System.Collections.Generic;
namespace BusinessLogic_Layer_Tests.OrderService_Tests
{
    [TestClass]
    public class OrderService_ChangeOrderPrice_Tests
    {
        private OrdersService OrderService = new OrdersService("test");
        [TestMethod]
        public void ChangeOrderPrice_should_ChangeOrderPrice_after_passing_OrderIdAndOrderNewPriceDouble()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            Order order = new Order(new List<Dish> { dish }, 100);
            int id = order.OrderId;
            double initialPrice = order.Price;


            // act
            OrderService.AddOrder(order);
            OrderService.ChangeOrderPrice(id, 500);

            // assert
            double res = OrderService.GetListOfOrders()[0].Price;

            Assert.AreNotEqual(initialPrice, res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChangeOrderPrice_should_throw_ArgumentOutOfRangeException_when_passing_NegativeDouble()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            Order order = new Order(new List<Dish> { dish }, 100);
            int id = order.OrderId;
            double newPrice = -800;

            // act
            OrderService.ChangeOrderPrice(id, newPrice);

            // assert
        }
    }
}
