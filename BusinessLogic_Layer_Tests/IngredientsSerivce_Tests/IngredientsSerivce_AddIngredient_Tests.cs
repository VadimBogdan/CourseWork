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
        public void AddIngredient_should_AddIngredientAndOneKeyToDictionary_after_passing_IngredientStringAndOneKeyString()
        {
            // arrange
            string ingredientName = "Onion";
            string ingredientKey = "Oni";

            // act
            IngedientsService.AddIngredient(ingredientName, new string[] { ingredientKey });

            // assert
            string res;
            IngedientsService.GetKeyValuePairs().TryGetValue(ingredientKey, out res);
            Assert.AreEqual(ingredientName, res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddIngredient_should_throw_ArgumentException_when_passing_EmptyKeyString()
        {
            // arrange
            string ingredientName = "Onion";
            string ingredientKey = "";

            // act
            IngedientsService.AddIngredient(ingredientName, new string[] { ingredientKey });

            // assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddIngredient_should_throw_ArgumentException_when_passing_EmptyIngredientString()
        {
            // arrange
            string ingredientName = "";
            string ingredientKey = "Oni";

            // act
            IngedientsService.AddIngredient(ingredientName, new string[] { ingredientKey });

            // assert
        }
    }
}
