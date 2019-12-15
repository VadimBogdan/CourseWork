using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;
namespace BusinessLogic_Layer_Tests.DishesService_Tests
{
    [TestClass]
    public class DishesService_ChangeDishCookTime_Tests
    {
        private DishesService DishesService = new DishesService("test");
        [TestMethod]
        public void ChangeDishCookTime_should_ChangeDishCookTime_after_passing_DishNameAndNewCookTimeInMinutesInt()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            string name = dish.DishName;
            int newDishCookTime = 10;


            // act
            DishesService.AddDish(dish);
            DishesService.ChangeDishCookTime(name, newDishCookTime);

            // assert
            int res = DishesService.GetListOfDishes()[0].DishCookTimeInMinutes;

            Assert.AreEqual(newDishCookTime, res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChangeDishCookTime_should_throw_ArgumentOutOfRangeException_when_passing_NegativeCookTimeInt()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            string name = dish.DishName;
            int newDishCookTime = -10;

            // act
            DishesService.ChangeDishCookTime(name, newDishCookTime);

            // assert
        }
    }
}
