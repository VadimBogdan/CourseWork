using System;
using System.Text.RegularExpressions;

namespace Presentation_Layer
{
    public class PromptHandler
    {
        public CommandActivity UserActivitySelect()
        {
            int answer = 0;
            Console.WriteLine("1. Дії з інгредієнтами" +
                            "\n2. Дії з стравами" +
                            "\nЗ. Дії з замовленнями" +
                            "\n4. Вийти з програми");
            do
            {
                int.TryParse(Console.ReadKey().KeyChar.ToString(), out answer);
            } while (!(1 <= answer && answer <= 4));


            return ActivityCase(answer);
        }
        private CommandActivity ActivityCase(int answer)
        {
            switch (answer)
            {
                case 1:
                    {
                        return CommandActivity.Ingredients;
                    }
                case 2:
                    {
                        return CommandActivity.Dishes;
                    }
                case 3:
                    {
                        return CommandActivity.Orders;
                    }
                case 4:
                    {
                        return CommandActivity.Exit;
                    }
            }
            throw new ArgumentOutOfRangeException("Не відома команда");
        }
        private CommandActivityTask ActivityTaskCase(int answer)
        {
            switch (answer)
            {
                case 1:
                    {
                        return CommandActivityTask.Add;
                    }
                case 2:
                    {
                        return CommandActivityTask.Remove;
                    }
                case 3:
                    {
                        return CommandActivityTask.Change;
                    }
                case 4:
                    {
                        return CommandActivityTask.DisplayAll;
                    }
                case 5:
                    {
                        return CommandActivityTask.AddIngredient;
                    }
                case 6:
                    {
                        return CommandActivityTask.RemoveIngredient;
                    }
                case 7:
                    {
                        return CommandActivityTask.ChangePrice;
                    }
                case 8:
                    {
                        return CommandActivityTask.ChangeTime;
                    }
                case 9:
                    {
                        return CommandActivityTask.DisplayExact;
                    }
            }
            throw new ArgumentOutOfRangeException("Не відома команда");
        }
        private CommandActivityTask ActivityTaskCaseForOrders(int answer)
        {
            switch (answer)
            {
                case 1:
                    {
                        return CommandActivityTask.Add;
                    }
                case 2:
                    {
                        return CommandActivityTask.Remove;
                    }
                case 3:
                    {
                        return CommandActivityTask.Change;
                    }
                case 4:
                    {
                        return CommandActivityTask.DisplayAll;
                    }
                case 5:
                    {
                        return CommandActivityTask.AddIngredient;
                    }
                case 6:
                    {
                        return CommandActivityTask.RemoveIngredient;
                    }
                case 7:
                    {
                        return CommandActivityTask.ChangePrice;
                    }
                case 8:
                    {
                        return CommandActivityTask.DisplayExact;
                    }
            }
            throw new ArgumentOutOfRangeException("Не відома команда");
        }
        public CommandActivityTask IngredientsActivity()
        {
            int answer;
            Console.WriteLine("1. Додати новий інгредієнт" +
                            "\n2. Видалити інгредієнт" +
                            "\nЗ. Замінити інгредієнт" +
                            "\n4. Переглянути всі інгредієнти");
            do
            {
                int.TryParse(Console.ReadKey().KeyChar.ToString(), out answer);
            } while (!(1 <= answer && answer <= 4));

            return ActivityTaskCase(answer);
        }
        public CommandActivityTask DishesActivity()
        {
            int answer;
            Console.WriteLine("1. Додати нову страву" +
                            "\n2. Видалити страву" +
                            "\n3. Змінити назву страви" +
                            "\n4. Переглянути назви страв" +
                            "\n5. Додати інгредієнт" +
                            "\n6. Видалити інгредієнт" +
                            "\n7. Змінити вартість страви" +
                            "\n8. Змінити час приготування" +
                            "\n9. Переглянути конкретну ставу");
            do
            {
                int.TryParse(Console.ReadKey().KeyChar.ToString(), out answer);
            } while (!(1 <= answer && answer <= 9));

            return ActivityTaskCase(answer);
        }
        public CommandActivityTask OrdersActivity()
        {
            int answer;
            Console.WriteLine("1. Додати замовлення" +
                            "\n2. Видалити замовлення" +
                            "\n3. Змінити номер столика" +
                            "\n4. Переглянути всі замовлення" +
                            "\n5. Додати страву" +
                            "\n6. Видалити страву" +
                            "\n7. Змінити вартість замовлення" +
                            "\n8. Переглянути конкретне замовлення");
            do
            {
                int.TryParse(Console.ReadKey().KeyChar.ToString(), out answer);
            } while (!(1 <= answer && answer <= 8));

            return ActivityTaskCaseForOrders(answer);
        }
        public void RestaurantName(ref string[] appFileNames)
        {
            string resturantName;
            Console.WriteLine("Введіть назву ресторану: ");
            resturantName = Console.ReadLine();
            appFileNames[0] = resturantName + "__ingredients";
            appFileNames[1] = resturantName + "__dishes";
            appFileNames[2] = resturantName + "__orders";
        }
        public void NewIngredient(out string name)
        {
            GetIngredientName(out name);
        }
        public void GetIngredientName(out string name)
        {
            Console.WriteLine("\nВведіть назву інгредієнта:");
            do
            {
                name = Console.ReadLine();

            } while (!Regex.IsMatch(name, @"[А-ЯІЇҐ][а-яіїґ]+"));
        }
        public void NewDish(out string[] keys, out string dishName, out double price, out int time)
        {
            Console.WriteLine("\nВведіть назви або ключ. слова інгредієнтів в один рядок");
            var matches = Regex.Matches(Console.ReadLine(), @"(?=(,|\s)?)([А-ЯІЇ]|[а-яії])+");
            keys = new string[matches.Count];
            for(int i = 0; i < matches.Count; i++)
            {
                keys[i] = matches[i].Value;
            }
            GetDishName(out dishName);
            GetDishPrice(out price);
            GetDishCookTime(out time);
        }
        public void GetDishName(out string name)
        {
            Console.WriteLine("Введіть назву страви:");
            do
            {
                name = Console.ReadLine();

            } while (!Regex.IsMatch(name, @"[А-ЯІЇҐ][а-яіїґ]+"));
        }
        public void GetDishPrice(out double price)
        {
            string answ;
            Console.WriteLine("Введіть вартість страви:");
            do
            {
                answ = Console.ReadLine();

            } while (!double.TryParse(answ, out price) && 0 < price);
        }
        public void GetDishCookTime(out int cookTime)
        {
            string answ;
            Console.WriteLine("Введіть час приготування страви:");
            do
            {
                answ = Console.ReadLine();

            } while (!int.TryParse(answ, out cookTime) && 0 < cookTime);
        }
        public void NewOrder(out string[] dishNames, out int tableNumber)
        {
            Console.WriteLine("\nВведіть назви страв через кому:");
            dishNames = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            GetOrderTableNumber(out tableNumber);
        }
        public void GetOrderTableNumber(out int tableNumber)
        {
            string answ;
            Console.WriteLine("Введіть номер столика:");
            do
            {
                answ = Console.ReadLine();

            } while (!int.TryParse(answ, out tableNumber));
        }
        public void GetOrderId(out int orderId)
        {
            string answ;
            Console.WriteLine("Введіть номер замовлення:");
            do
            {
                answ = Console.ReadLine();

            } while (!int.TryParse(answ, out orderId));
        }
        public void GetOrderPrice(out double price)
        {
            string answ;
            Console.WriteLine("Введіть вартість замовлення:");
            do
            {
                answ = Console.ReadLine();

            } while (!double.TryParse(answ, out price) && 0 < price);
        }
    }
}
