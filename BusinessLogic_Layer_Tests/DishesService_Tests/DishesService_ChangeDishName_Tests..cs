using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;
namespace BusinessLogic_Layer_Tests.DishesService_Tests
{
    [TestClass]
    public class DishesService_ChangeDishName_Tests
    {
        private DishesService DishesService = new DishesService("test");
        [TestMethod]
        public void ChangeDishName_should_ChangeDishName_after_passing_OldDishNameAndNewDishName()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            string originalDishName = dish.DishName;
            string newDishName = dish.DishName.Substring(0, 15);


            // act
            DishesService.AddDish(dish);
            DishesService.ChangeDishName(originalDishName, newDishName);

            // assert
            string res = DishesService.GetListOfDishes()[0].DishName;

            Assert.AreEqual(newDishName, res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeDishName_should_throw_ArgumentException_when_trying_to_ChangeNonExistentDishName()
        {
            // arrange
            string name = "Mashed potatoes with mushrooms";
            string newDishName = name.Substring(0, 15);

            // act
            DishesService.ChangeDishName(name, newDishName);

            // assert
        }
    }
}
