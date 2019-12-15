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
            string ingredientKey = "oni";

            // act
            IngedientsService.AddIngredient(ingredientName, new string[] { ingredientKey });
            IngedientsService.RemoveIngredient(ingredientName);

            // assert
            string res = "";
            IngedientsService.GetKeyValuePairs().TryGetValue(ingredientKey, out res);
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
