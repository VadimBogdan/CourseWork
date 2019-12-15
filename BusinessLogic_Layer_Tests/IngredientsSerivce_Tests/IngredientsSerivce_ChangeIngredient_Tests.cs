using BusinessLogic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLogic_Layer_Tests.IngredientsSerivce_Tests
{
    [TestClass]
    public class IngredientsSerivce_ChangeIngredient_Tests
    {
        private IngedientsService IngedientsService = new IngedientsService("test");
        [TestMethod]
        public void ChangeIngredient_should_ChangeFirstParameterIngredientToSecond_when_passing_TwoIngredients()
        {
            // arrange
            string ingredientName1 = "Onio";
            string ingredientKey1 = "oni";
            string ingredientName2 = "Onion";

            // act
            IngedientsService.AddIngredient(ingredientName1, new string[] { ingredientKey1 });
            IngedientsService.ChangeIngredient(ingredientName1, ingredientName2);

            // assert
            string res = "";
            IngedientsService.GetKeyValuePairs().TryGetValue("oni", out res);
            Assert.AreNotEqual(ingredientName1, res);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeIngredient_should_throw_ArgumentException_after_passing_NonExistentIngredientString()
        {
            // arrange
            string ingredientName1 = "Apple";
            string ingredientName2 = "Mushroom";

            // act
            IngedientsService.ChangeIngredient(ingredientName2, ingredientName1);

            // assert
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeIngredient_should_throw_ArgumentException_after_passing_EmptyIngredientString()
        {
            // arrange
            string ingredientName1 = "Apple";
            string ingredientName2 = "";

            // act
            IngedientsService.ChangeIngredient(ingredientName2, ingredientName1);

            // assert
        }
    }
}
