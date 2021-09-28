using System.Collections.Generic;

namespace Restaurant.Order.Domain
{
    public class MorningDishes : DishesBase
    {
        public const string Name = nameof(MorningDishes);

        protected override IDictionary<int, string> DishDictionary => new Dictionary<int, string>
        {
            [1] = "eggs",
            [2] = "toast",
            [3] = "coffee",
        };
    }
}
