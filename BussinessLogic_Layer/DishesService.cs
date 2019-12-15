using DataAccess_Layer;
using Restaurant;
using System;
using System.Collections.Generic;
namespace BusinessLogic_Layer
{
    public class DishesService
    {
        private List<Dish> Dishes { get; set; }
        private DishesDB DishesDB { get; set; }
        public DishesService(string DbFileName)
        {
            DishesDB = new DishesDB(DbFileName);
            Dishes = DishesDB.Select();
        }
        public List<Dish> FindAllDishesByNames(ref string[] dishesNames)
        {
            List<Dish> specifiedDishes = new List<Dish>();
            foreach (var name in dishesNames)
            {
                specifiedDishes.Add(Dishes.Find((x) => x.DishName == name));
            }
            return specifiedDishes;
        }
        public Dish FindDishByName(string dishName)
        {
            Dish dish;
            dish = Dishes.Find((x) => x.DishName == dishName);
            return dish;
        }
        public bool IsIngredientUsed(string ingredient)
        {
            Dish dish = Dishes.Find((x) => x.Ingredients.Contains(ingredient));
            if (dish == null)
            {
                return false;
            }
            return true;
        }
        public void AddDish(Dish dish)
        {
            if (dish == null)
            {
                throw new ArgumentNullException("Посилання на null.");
            }
            if (string.IsNullOrEmpty(dish.DishName))
            {
                throw new ArgumentException("Страва без назви.");
            }
            if (Dishes.Contains(dish))
            {
                throw new ArgumentException("Страва з такою назвою вже існує.");
            }
            Dishes.Add(dish);
        }
        public void RemoveDish(string dishName)
        {
            Dish dish = new Dish(dishName);
            if (!Dishes.Contains(dish))
            {
                throw new ArgumentException("Страви з такою назвою не існує");
            }
            Dishes.Remove(dish);
        }
        public void ChangeDishName(string oldName, string newName)
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Помилка у назві страви.");
            }
            Dish dish = new Dish(oldName);
            if (!Dishes.Contains(dish))
            {
                throw new ArgumentException("Страви з такою назвою не існує.");
            }
            int index = Dishes.IndexOf(dish);
            Dishes[index].setDishName(newName);
        }
        public void RemoveDishIngredient(string dishName, string ingredientName)
        {
            if (string.IsNullOrWhiteSpace(dishName))
            {
                throw new ArgumentException("Помилка у назві страви.");
            }
            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                throw new ArgumentException("Помилка у назві інгредієнта.");
            }
            Dish dish = new Dish(dishName);
            if (!Dishes.Contains(dish))
            {
                throw new ArgumentException("Страви з такою назвою не існує.");
            }
            int index = Dishes.IndexOf(dish);
            Dishes[index].removeDishIngredient(ingredientName);
        }
        public void AddDishIngredient(string dishName, string ingredientName)
        {
            if (string.IsNullOrWhiteSpace(dishName))
            {
                throw new ArgumentException("Помилка у назві страви.");
            }
            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                throw new ArgumentException("Помилка у назві інгредієнта.");
            }
            Dish dish = new Dish(dishName);
            if (!Dishes.Contains(dish))
            {
                throw new ArgumentException("Страви з такою назвою не існує.");
            }
            int index = Dishes.IndexOf(dish);
            Dishes[index].addDishIngredient(ingredientName);
        }
        public void ChangeDishPrice(string dishName, double newPrice)
        {
            if (string.IsNullOrWhiteSpace(dishName))
            {
                throw new ArgumentException("Помилка у назві страви.");
            }
            if (newPrice < 0)
            {
                throw new ArgumentOutOfRangeException("Нова ціна не може бути негативним числом.");
            }
            Dish dish = new Dish(dishName);
            if (!Dishes.Contains(dish))
            {
                throw new ArgumentException("Страви з такою назвою не існує.");
            }
            int index = Dishes.IndexOf(dish);
            Dishes[index].setDishPrice(newPrice);
        }
        public void ChangeDishCookTime(string dishName, int newCookTimeInMinutes)
        {
            if (string.IsNullOrWhiteSpace(dishName))
            {
                throw new ArgumentException("Помилка у назві страви.");
            }
            if (newCookTimeInMinutes < 0)
            {
                throw new ArgumentOutOfRangeException("Новий час приготування не може бути негативним числом.");
            }
            Dish dish = new Dish(dishName);
            if (!Dishes.Contains(dish))
            {
                throw new ArgumentException("Страви з такою назвою не існує.");
            }
            int index = Dishes.IndexOf(dish);
            Dishes[index].setDishCookTimeInMinutes(newCookTimeInMinutes);
        }
        public IList<Dish> GetListOfDishes()
        {
            return Dishes;
        }
        public void Update()
        {
            DishesDB.Update(Dishes);
        }
    }
}
