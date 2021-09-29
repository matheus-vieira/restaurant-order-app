using System.Collections.Generic;

namespace Restaurant.Order.Domain
{
    public abstract class DishesBase : IDishes
    {
        protected abstract IList<int> GetAllowedMultiples();
        protected abstract IDictionary<int, string> DishDictionary1 { get; }

        public string[] GetDishes(int[] dishesTypes)
        {
            var dishes = LoadDishes(dishesTypes);

            var list = BuildDishes(dishes);

            return list;
        }

        private string[] BuildDishes(SortedDictionary<int, int> dishes)
        {
            List<string> list = new();
            var dishDictionary = DishDictionary1;
            foreach (var item in dishes)
            {
                dishDictionary.TryGetValue(item.Key, out var value);

                if (item.Value > 1 && !CanHaveMultiples(item.Key))
                    continue;

                var text = value ?? "error";

                if (item.Value > 1)
                    text += $"(x{item.Value})";
                list.Add(text);
            }

            return list.ToArray();
        }

        private bool CanHaveMultiples(int dishType)
        {
            return GetAllowedMultiples().Contains(dishType);
        }

        private static SortedDictionary<int, int> LoadDishes(int[] dishesTypes)
        {
            SortedDictionary<int, int> dishes = new();

            for (int i = 0; i < dishesTypes.Length; i++)
            {
                dishes.TryGetValue(dishesTypes[i], out var value);

                dishes[dishesTypes[i]] = ++value;
            }

            return dishes;
        }
    }
}
