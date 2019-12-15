using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;
namespace BusinessLogic_Layer
{
    public class IngedientsService
    {
        private Dictionary<string, string> Ingredients { get; set; }
        private IngredientsDB IngredientsDB { get; set; }
        public IngedientsService(string DbfileName)
        {
            IngredientsDB = new IngredientsDB(DbfileName);
            Ingredients = IngredientsDB.Select();
        }
        public string[] FindAllIngredientsByKeys(ref string[] keys)
        {
            string[] values = new string[keys.Length];
            for(int i = 0; i < keys.Length; i++)
            {
                Ingredients.TryGetValue(keys[i], out values[i]);
            }
            return values;    
        }
        public void AddIngredient(string ingredientName, string[] keyWords)
        {
            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                throw new ArgumentException("Помилка у назві інгредієнта.");
            }
            if (keyWords.Length == 1)
            {
                if (string.IsNullOrWhiteSpace(keyWords[0]))
                {
                    throw new ArgumentException("Помилка у назві ключа інгредієнта.");
                }
            }
            foreach(string key in keyWords)
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    continue;
                }
                Ingredients.Add(key, ingredientName);
            }
        }
        public void RemoveIngredient(string ingredientName)
        {
            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                throw new ArgumentException("Помилка у назві інгредієнта.");
            }

            List<string> removingKeyValues = Mapping(ingredientName); // пари ключ-значення, що видаляються
            if (removingKeyValues.Count == 0)
            {
                throw new ArgumentException("Інгредіанта з такою назвою не має у базі.");
            }
            foreach (string key in removingKeyValues)
            {
                Ingredients.Remove(key);
            }
        }
        public void ChangeIngredient(string oldName, string newName)
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Помилка у назві інгредієнта.");
            }
            List<string> changingValuesKeys = Mapping(oldName); // ключі змінюваного значення
            if (changingValuesKeys.Count == 0)
            {
                throw new ArgumentException("Спроба змінити неіснуючий інгредієнт.");
            }
            foreach (string key in changingValuesKeys)
            {
                Ingredients[key] = newName;
            }
        }
        public List<string> Mapping(string ingredientName)
        {
            List<string> allKeys = new List<string>();
            foreach (var keyValue in Ingredients)
            {
                if (keyValue.Value == ingredientName)
                {
                    allKeys.Add(keyValue.Key);
                }
            }
            return allKeys;
        }
        public IDictionary<string, string> GetKeyValuePairs()
        {
            return Ingredients;
        }
        public void Update()
        {
            IngredientsDB.Update(Ingredients);
        }
/*        ~IngedientsService()
        {
            Update();
        }*/
    }
}
