using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLogic_Layer_Tests.IngredientsSerivce_Tests
{
    [TestClass]
    public class IngredientsSerivce_RemoveIngredient_Tests
    {
        private IngedientsService IngedientsService = new IngedientsService("test");
        [TestMethod]
        public void RemoveIngredient_should_RemoveIngredient_when_passing_IngredientString()
        {
            // arrange
            string ingredientName = "Onion";

            // act
            IngedientsService.AddIngredient(ingredientName);
            IngedientsService.RemoveIngredient(ingredientName);

            // assert
            bool res = IngedientsService.ContainsIngredient(ingredientName);

            Assert.AreNotEqual(ingredientName, res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveIngredient_should_throw_ArgumentException_after_passing_EmptyIngredientString()
        {
            // arrange
            string ingredientName = "";

            // act
            IngedientsService.RemoveIngredient(ingredientName);

            // assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveIngredient_should_throw_ArgumentException_after_passing_NonExistentIngredientString()
        {
            // arrange
            string ingredientName = "Mushroom";

            // act
            IngedientsService.RemoveIngredient(ingredientName);

            // assert
        }
    }
}
