using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLogic_Layer_Tests.IngredientsSerivce_Tests
{
    [TestClass]
    public class IngredientsSerivce_AddIngredient_Tests
    {
        private IngedientsService IngedientsService = new IngedientsService("test");
        [TestMethod]
        public void AddIngredient_should_AddIngredientAndOneKeyToList_after_passing_IngredientStringAndOneKeyString()
        {
            // arrange
            string ingredientName = "Onion";

            // act
            IngedientsService.AddIngredient(ingredientName);

            // assert
            bool res = IngedientsService.ContainsIngredient(ingredientName);

            Assert.IsTrue(res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddIngredient_should_throw_ArgumentException_when_passing_EmptyIngredientNameString()
        {
            // arrange
            string ingredientName = "";

            // act
            IngedientsService.AddIngredient(ingredientName);

            // assert
        }
    }
}
