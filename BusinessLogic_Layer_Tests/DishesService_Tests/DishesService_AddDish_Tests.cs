using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;
namespace BusinessLogic_Layer_Tests.DishesService_Tests
{
    [TestClass]
    public class DishesService_AddDish_Tests
    {
        private DishesService DishesService = new DishesService("test");
        [TestMethod]
        public void AddDish_should_AddDish_when_passing_DishObject()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);


            // act
            DishesService.AddDish(dish);

            // assert
            bool res = DishesService.GetListOfDishes().Contains(dish);

            Assert.IsTrue(res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddDish_should_throw_ArgumentNullException_when_passing_NullDishRef()
        {
            // arrange
            Dish dish = null;

            // act
            DishesService.AddDish(dish);

            // assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDish_should_throw_ArgumentException_when_passing_DishWithNoName()
        {
            // arrange
            Dish dish = new Dish("");

            // act
            DishesService.AddDish(dish);

            // assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDish_should_throw_ArgumentException_when_passing_DishWithAlreadyExistingName()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);

            // act
            DishesService.AddDish(dish);
            DishesService.AddDish(dish);

            // assert
        }
    }
}
