using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Restaurant
{
    [DataContract]
    public class Dish : IComparable<Dish>, IEquatable<Dish>
    {
        [DataMember]
        public List<string> Ingredients { get; private set; }
        [DataMember]
        public string DishName { get; private set; }
        [DataMember]
        public double DishPrice { get; private set; }
        [DataMember]
        public int DishCookTimeInMinutes { get; private set; }
        public Dish(string[] ingredients, string dishName, double dishPrice, int dishCookTimeInMinutes)
        {
            this.Ingredients = new List<string>(ingredients);
            this.DishName = dishName;
            this.DishPrice = dishPrice;
            this.DishCookTimeInMinutes = dishCookTimeInMinutes;
        }
        public Dish(string dishName)
        {
            this.DishName = dishName;
            this.Ingredients = null;
            this.DishPrice = 0d;
            this.DishCookTimeInMinutes = 0;
        }
        public void setDishName(string newDishName)
        {
            this.DishName = newDishName;
        }
        public void setDishPrice(double newDishPrice)
        {
            this.DishPrice = newDishPrice;
        }
        public void setDishCookTimeInMinutes(int newDishCookTime)
        {
            this.DishCookTimeInMinutes = newDishCookTime;
        }
        public void removeDishIngredient(string ingredientName)
        {
            Ingredients.Remove(ingredientName);
        }
        public void addDishIngredient(string ingredientName)
        {
            Ingredients.Add(ingredientName);
        }
        public int CompareTo(Dish other)
        {
            if (other == null) return 1;

            return DishPrice.CompareTo(other.DishPrice);
        }

        public bool Equals(Dish other)
        {
            if (other == null)
                return false;

            if (this.DishName == other.DishName)
                return true;
            else
                return false;
        }
    }
}
