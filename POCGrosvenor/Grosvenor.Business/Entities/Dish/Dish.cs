using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Business.Enumerations;

namespace Grosvenor.Business
{
    public class Dish
    {
        public Dish()
        {
            CanHaveMultipleOrders = false;
            HasError = false;
            QuantityDishes = 0;
        }

        public EnumDayTime DayTime { get; set; }
        public EnumDishes DishType { get; set; }
        public string DishDescription { get; set; }
        public bool CanHaveMultipleOrders { get; set; }
        public bool HasError { get; set; }
        public int QuantityDishes { get; set; }
    }
}
