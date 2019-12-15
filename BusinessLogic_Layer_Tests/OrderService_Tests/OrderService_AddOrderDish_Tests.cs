using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;
using System.Collections.Generic;
namespace BusinessLogic_Layer_Tests.OrderService_Tests
{
    [TestClass]
    public class OrderService_AddOrderDish_Tests
    {
        private OrdersService OrderService = new OrdersService("test");
        [TestMethod]
        public void AddOrderDish_should_AddOrderDish_after_passing_OrderIdAndDishObject()
        {
            // arrange
            Dish dish1 = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            Dish dish2 = new Dish(new string[] { "orange", }, "Orange juice", 5, 7);
            Order order = new Order(new List<Dish> { dish1 }, 100);
            int id = order.OrderId;


            // act
            OrderService.AddOrder(order);
            OrderService.AddOrderDish(id, dish2);

            // assert
            bool res = OrderService.GetListOfOrders()[0].GetListOfDishesInOrder().Contains(dish2);

            Assert.IsTrue(res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddOrderDish_should_throw_ArgumentNullException_when_passing_NullRefDishObject()
        {
            // arrange
            Dish dish1 = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            Dish dish2 = null;
            Order order = new Order(new List<Dish> { dish1 }, 100);
            int id = order.OrderId;

            // act
            OrderService.AddOrder(order);
            OrderService.AddOrderDish(id, dish2);

            // assert
        }
    }
}
