using System.Collections.Generic;

namespace Restaurant.Order.Domain
{
    public abstract class DishesBase : IDishes
    {
        protected virtual IDictionary<int, string> DishDictionary { get; }

        public string[] GetDishes(int[] dishesTypes)
        {
            var dishes = LoadDishes(dishesTypes);

            var list = BuildDishes(dishes);

            return list;
        }

        private static string[] BuildDishes(IReadOnlyDictionary<string, int> dishes)
        {
            List<string> list = new();
            foreach (var item in dishes)
            {
                var text = item.Key;
                if (item.Value > 1)
                    text += $"(x{item.Value})";
                list.Add(text);
            }

            return list.ToArray();
        }

        private IReadOnlyDictionary<string, int> LoadDishes(int[] dishesTypes)
        {
            Dictionary<string, int> dishes = new();

            for (int i = 0; i < dishesTypes.Length; i++)
            {
                DishDictionary.TryGetValue(dishesTypes[i], out var dishName);

                var key = dishName ?? "error";
                dishes.TryGetValue(key, out int value);

                dishes[key] = ++value;
            }

            return dishes;
        }
    }
}
