using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;
namespace BusinessLogic_Layer_Tests.DishesService_Tests
{
    [TestClass]
    public class DishesService_RemoveDish_Tests
    {
        private DishesService DishesService = new DishesService("test");
        [TestMethod]
        public void RemoveDish_should_RemoveDish_after_passing_DishName()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            string name = dish.DishName;


            // act
            DishesService.AddDish(dish);
            DishesService.RemoveDish(name);

            // assert
            bool res = DishesService.GetListOfDishes().Contains(dish);

            Assert.IsFalse(res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveDish_should_throw_ArgumentException_when_passing_NonExistentDishName()
        {
            // arrange
            string name = "Mashed potatoes with mushrooms";

            // act
            DishesService.RemoveDish(name);

            // assert
        }
    }
}
