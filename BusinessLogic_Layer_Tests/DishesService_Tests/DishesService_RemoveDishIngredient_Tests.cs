using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;
namespace BusinessLogic_Layer_Tests.DishesService_Tests
{
    [TestClass]
    public class DishesService_RemoveDishIngredient_Tests
    {
        private DishesService DishesService = new DishesService("test");
        [TestMethod]
        public void RemoveDishIngredient_should_RemoveDishIngredient_after_passing_IngredientName()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            string ingredient = dish.Ingredients[0];
            string dishName = dish.DishName;


            // act
            DishesService.AddDish(dish);
            DishesService.RemoveDishIngredient(dishName, ingredient);

            // assert
            bool res = DishesService.GetListOfDishes()[0].Ingredients.Contains(ingredient);

            Assert.IsFalse(res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveDishIngredient_should_throw_ArgumentException_when_passing_NonExistentDishName()
        {
            // arrange
            string dishName = "Mashed potatoes with mushrooms";
            string ingredient = "Mushroom";

            // act
            DishesService.RemoveDishIngredient(dishName, ingredient);

            // assert
        }
    }
}
