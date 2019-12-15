using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System;
namespace BusinessLogic_Layer_Tests.DishesService_Tests
{
    [TestClass]
    public class DishesService_AddDishIngredient_Tests
    {
        private DishesService DishesService = new DishesService("test");
        [TestMethod]
        public void AddDishIngredient_should_AddDishIngredient_after_passing_IngredientName()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            string ingredient = "black pepper";
            string dishName = dish.DishName;


            // act
            DishesService.AddDish(dish);
            DishesService.AddDishIngredient(dishName, ingredient);

            // assert
            bool res = DishesService.GetListOfDishes()[0].Ingredients.Contains(ingredient);

            Assert.IsTrue(res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDishIngredient_should_throw_ArgumentException_when_passing_EmptyIngredient()
        {
            // arrange
            Dish dish = new Dish(new string[] { "Mushroom", "potato" }, "Mashed potatoes with mushrooms", 15, 35);
            string ingredient = "";
            string dishName = dish.DishName;

            // act
            DishesService.AddDish(dish);
            DishesService.AddDishIngredient(dishName, ingredient);

            // assert
        }
    }
}
