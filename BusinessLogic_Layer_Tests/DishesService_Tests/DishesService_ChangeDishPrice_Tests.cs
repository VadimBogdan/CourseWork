using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;
namespace BusinessLogic_Layer_Tests.DishesService_Tests
{
    [TestClass]
    public class DishesService_ChangeDishPrice_Tests
    {
        private DishesService DishesService = new DishesService("test");
        [TestMethod]
        public void ChangeDishPrice_should_ChangeDishPrice_after_passing_DishNameDishNewPriceDouble()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            string name = dish.DishName;
            double newDishPrice = dish.DishPrice - 2.77;


            // act
            DishesService.AddDish(dish);
            DishesService.ChangeDishPrice(name, newDishPrice);

            // assert
            double res = DishesService.GetListOfDishes()[0].DishPrice;

            Assert.AreEqual(newDishPrice, res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChangeDishPrice_should_throw_ArgumentOutOfRangeException_when_passing_NegativeDouble()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            string name = dish.DishName;
            double newDishPrice = -10000000;

            // act
            DishesService.ChangeDishPrice(name, newDishPrice);

            // assert
        }
    }
}
