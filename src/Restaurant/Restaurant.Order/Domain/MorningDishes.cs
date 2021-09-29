using System.Collections.Generic;

namespace Restaurant.Order.Domain
{
    public class MorningDishes : DishesBase
    {
        public const string Name = nameof(MorningDishes);

        private static IDictionary<int, string> DishDictionary => new Dictionary<int, string>
        {
            [1] = "eggs",
            [2] = "toast",
            [3] = "coffee",
        };

        private static IList<int> AllowedMultiples => new List<int> { 3 };

        protected override IList<int> GetAllowedMultiples() => AllowedMultiples;

        protected override IDictionary<int, string> DishDictionary1 => DishDictionary;
    }
}
