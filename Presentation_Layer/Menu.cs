using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic_Layer;
using Restaurant;

namespace Presentation_Layer
{
    public enum CommandAppOut { Exit, ChangeRestaurant }
    public enum CommandAppIn { Add, Remove, Find, ChangeRestaurant, Exit, Continue }
    public enum CommandActivity { Ingredients, Dishes, Orders, Exit }
    public enum CommandActivityTask { Add, Remove, Change, DisplayExact, RemoveIngredient, 
        AddIngredient, ChangePrice, ChangeTime, DisplayAll,  
    }
    public class Menu
    {
        private IngedientsService IngedientsService { get; set; }
        private DishesService DishesService { get; set; }
        private OrdersService OrdersService { get; set; }
        private readonly PromptHandler Prompt = new PromptHandler();
        public void MainMenu()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

           CommandAppOut commandApp;
            do
            {
                string[] applicationFileNames = new string[3];

                try
                {
                    Prompt.RestaurantName(ref applicationFileNames);
                    commandApp = StartLoop(ref applicationFileNames);
                }
                catch (Exception exc)
                {
                    SendErrorMessage(exc.Message);
                    commandApp = CommandAppOut.Exit;
                    Console.ReadKey();
                }
            } while (commandApp == CommandAppOut.ChangeRestaurant);
        }
        private CommandAppOut StartLoop(ref string[] appFileNames)
        {
            try
            {
                InitializeComponents(ref appFileNames);  
            } catch(Exception e)
            {
                throw e;
            }
            SendProgressOrSuccessMessage("Успішне підключення до Бази Даних!");
            CommandAppIn answer = CommandAppIn.Continue;
            do
            {          
                try
                {
                    CommandActivity activity = Prompt.UserActivitySelect();
                    CommandActivityTask task;
                    Console.WriteLine();
                    switch (activity)
                    {
                        case CommandActivity.Exit:
                            {
                                    answer = CommandAppIn.Exit;
                                    break;
                            }
                        case CommandActivity.Ingredients:
                            {
                                task = Prompt.IngredientsActivity();
                                Console.WriteLine();
                                switch(task)
                                {
                                    case CommandActivityTask.Add:
                                        {
                                            string[] keys;
                                            string name;
                                            Prompt.NewIngredient(out keys, out name);
                                            IngedientsService.AddIngredient(name, keys);
                                            IngedientsService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.Remove:
                                        {
                                            string name;
                                            Prompt.GetIngredientName(out name);
                                            if (DishesService.IsIngredientUsed(name))
                                            {
                                                SendErrorMessage("Інгредієнт є у страві!");
                                                break;
                                            }
                                            IngedientsService.RemoveIngredient(name);
                                            IngedientsService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.Change:
                                        {
                                            string oldName, newName;
                                            Prompt.GetIngredientName(out oldName);
                                            Prompt.GetIngredientName(out newName);
                                            IngedientsService.ChangeIngredient(oldName, newName);
                                            IngedientsService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.DisplayAll:
                                        {
                                            Display("ingredients");
                                            break;
                                        }
                                }
                                break;
                            }
                        case CommandActivity.Dishes:
                            {
                                task = Prompt.DishesActivity();
                                Console.WriteLine();
                                switch (task)
                                {
                                    case CommandActivityTask.Add:
                                        {
                                            string[] keys;
                                            string[] ingredients;
                                            int dishCookTimeInMinutes;
                                            double dishPrice;
                                            string dishName;
                                            Prompt.NewDish(out keys, out dishName, out dishPrice, out dishCookTimeInMinutes);
                                            ingredients = IngedientsService.FindAllIngredientsByKeys(ref keys);
                                            DishesService.AddDish(new Dish(ingredients, dishName, dishPrice, dishCookTimeInMinutes));
                                            DishesService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.Remove:
                                        {
                                            string dishName;
                                            Prompt.GetDishName(out dishName);
                                            DishesService.RemoveDish(dishName);
                                            DishesService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.Change:
                                        {
                                            string oldName, newName;
                                            Prompt.GetDishName(out oldName);
                                            Prompt.GetDishName(out newName);
                                            DishesService.ChangeDishName(oldName, newName);
                                            DishesService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.DisplayExact:
                                        {
                                            break;
                                        }
                                    case CommandActivityTask.AddIngredient:
                                        {
                                            string dishName;
                                            string ingredientName;
                                            Prompt.GetDishName(out dishName);
                                            Prompt.GetIngredientName(out ingredientName);
                                            DishesService.AddDishIngredient(dishName, ingredientName);
                                            DishesService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.RemoveIngredient:
                                        {
                                            string dishName;
                                            string ingredientName;
                                            Prompt.GetDishName(out dishName);
                                            Prompt.GetIngredientName(out ingredientName);
                                            DishesService.RemoveDishIngredient(dishName, ingredientName);
                                            DishesService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.ChangePrice:
                                        {
                                            string dishName;
                                            double price;
                                            Prompt.GetDishName(out dishName);
                                            Prompt.GetDishPrice(out price);
                                            DishesService.ChangeDishPrice(dishName, price);
                                            DishesService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.ChangeTime:
                                        {
                                            string dishName;
                                            int cookTime;
                                            Prompt.GetDishName(out dishName);
                                            Prompt.GetDishCookTime(out cookTime);
                                            DishesService.ChangeDishCookTime(dishName, cookTime);
                                            DishesService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.DisplayAll:
                                        {
                                            Display("dishes");
                                            break;
                                        }
                                }

                                break;
                            }
                        case CommandActivity.Orders:
                            {
                                task = Prompt.OrdersActivity();
                                Console.WriteLine();
                                switch (task)
                                {
                                    case CommandActivityTask.Add:
                                        {
                                            string[] dishNames;
                                            List<Dish> dishes;
                                            int tableNumber;
                                            Prompt.NewOrder(out dishNames, out tableNumber);
                                            dishes = DishesService.FindAllDishesByNames(ref dishNames);
                                            OrdersService.AddOrder(new Order (dishes, tableNumber));
                                            DishesService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.Remove:
                                        {
                                            int orderId;
                                            Prompt.GetOrderId(out orderId);
                                            OrdersService.RemoveOrder(orderId);
                                            DishesService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.Change:
                                        {
                                            int orderId, tableNumber;
                                            Prompt.GetOrderId(out orderId);
                                            Prompt.GetOrderTableNumber(out tableNumber);
                                            OrdersService.ChangeOrderTableNumber(orderId, tableNumber);
                                            DishesService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.DisplayExact:
                                        {
                                            break;
                                        }
                                    case CommandActivityTask.AddIngredient:
                                        {
                                            string dishName;
                                            int orderId;
                                            Dish dish;
                                            Prompt.GetOrderId(out orderId);
                                            Prompt.GetDishName(out dishName);
                                            dish = DishesService.FindDishByName(dishName);
                                            OrdersService.AddOrderDish(orderId, dish);
                                            DishesService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.RemoveIngredient:
                                        {
                                            string dishName;
                                            int orderId;
                                            Dish dish;
                                            Prompt.GetOrderId(out orderId);
                                            Prompt.GetDishName(out dishName);
                                            dish = DishesService.FindDishByName(dishName);
                                            OrdersService.RemoveOrderDish(orderId, dish);
                                            DishesService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.ChangePrice:
                                        {
                                            double newPrice;
                                            int orderId;
                                            Prompt.GetOrderId(out orderId);
                                            Prompt.GetOrderPrice(out newPrice);
                                            OrdersService.ChangeOrderPrice(orderId, newPrice);
                                            DishesService.Update();
                                            break;
                                        }
                                    case CommandActivityTask.DisplayAll:
                                        {
                                            Display("orders");
                                            break;
                                        }
                                }
                                break;
                            }
                    }

                }
                catch (ArgumentOutOfRangeException e)
                {
                    SendErrorMessage(e.Message);
                }
                Console.ReadKey();
                Console.Clear();
            } while (answer != CommandAppIn.Exit && answer != CommandAppIn.ChangeRestaurant);
            if (answer == CommandAppIn.ChangeRestaurant)
            {
                return CommandAppOut.ChangeRestaurant;
            }
            return CommandAppOut.Exit;          
        }
        private void InitializeComponents(ref string[] appFileNames)
        {
            try
            {
                IngedientsService = new IngedientsService(appFileNames[0]);
                DishesService = new DishesService(appFileNames[1]);
                OrdersService = new OrdersService(appFileNames[2]);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void Display(string what)
        {
            int counter = 1;
            if (what == "ingredients")
            {
                Console.WriteLine("Доступні інгредієнти:");
                foreach (var val in IngedientsService.GetKeyValuePairs().Distinct())
                {
                    Console.WriteLine($"{counter}. {val}");
                }
            } else if (what == "dishes")
            {
                Console.WriteLine("Доступні страви:");
                foreach (var val in DishesService.GetListOfDishes())
                {
                    Console.WriteLine($"{counter}. {val.DishName} - {val.DishPrice} грн.");
                }
            } 
        }
        private void SendProgressOrSuccessMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        private void SendErrorMessage(string err)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(err);
            Console.ResetColor();
        }
    }
}
