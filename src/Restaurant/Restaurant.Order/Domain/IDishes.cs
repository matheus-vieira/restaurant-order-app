using System.Collections.Generic;

namespace Restaurant.Order.Domain
{
    public interface IDishes
    {
        string[] GetDishes(int[] dishesTypes);
    }
}
