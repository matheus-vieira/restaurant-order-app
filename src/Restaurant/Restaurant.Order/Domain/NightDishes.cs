using System.Collections.Generic;

namespace Restaurant.Order.Domain
{
    public class NightDishes : DishesBase
    {
        public const string Name = nameof(NightDishes);

        private static IList<int> AllowedMultiples => new List<int> { 2 };

        private static IDictionary<int, string> DishDictionary => new Dictionary<int, string>
        {
            [1] = "steak",
            [2] = "potato",
            [3] = "wine",
            [4] = "cake",
        };

        protected override IList<int> GetAllowedMultiples() => AllowedMultiples;

        protected override IDictionary<int, string> DishDictionary1 => DishDictionary;
    }
}
