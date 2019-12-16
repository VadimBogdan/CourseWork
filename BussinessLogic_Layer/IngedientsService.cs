using DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLogic_Layer
{
    public class IngedientsService
    {
        private List<string> Ingredients { get; set; }
        private IngredientsDB IngredientsDB { get; set; }
        public IngedientsService(string DbfileName)
        {
            IngredientsDB = new IngredientsDB(DbfileName);
            Ingredients = IngredientsDB.Select();
        }
        public List<string> FindAllIngredientsByKeys(string[] keys)
        {
            List<string> values = Ingredients.Where((ingrName) => keys.Where(
                (key) => ingrName.ToLower().Contains(key) || ingrName.Contains(key))
            .Any())
                .ToList();
            
            return values;
        }
        public void AddIngredient(string ingredientName)
        {
            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                throw new ArgumentException("Помилка у назві інгредієнта.");
            }
            if (Ingredients.Contains(ingredientName))
            {
                throw new ArgumentException("Такий інгредієнт вже існує");
            }
            Ingredients.Add(ingredientName);
        }
        public void RemoveIngredient(string ingredientName)
        {
            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                throw new ArgumentException("Помилка у назві інгредієнта.");
            }
            int index = Ingredients.FindIndex((str) => str == ingredientName);
            if (index < 0)
            {
                throw new ArgumentException("Інгредіанта з такою назвою не має у базі.");
            }
            else
            {
                Ingredients.Remove(ingredientName);
            }
       
        }
        public void ChangeIngredient(string oldName, string newName)
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Помилка у назві інгредієнта.");
            }
            // List<string> changingValuesKeys = Mapping(oldName); // ключі змінюваного значення
            int index = Ingredients.FindIndex((str) => str == oldName);
            if (index < 0)
            {
                throw new ArgumentException("Спроба змінити неіснуючий інгредієнт.");
            }
            else
            {
                Ingredients[index] = newName;
            }
        }
        public bool ContainsIngredient(string item)
        {
            return Ingredients.Contains(item);
        }
        public IList<string> GetIngredientList()
        {
            return Ingredients;
        }
        public void Update()
        {
            IngredientsDB.Update(Ingredients);
        }
    }
}
