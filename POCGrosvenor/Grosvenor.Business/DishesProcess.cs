using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Business.Enumerations;
using Grosvenor.Business.Interfaces.Validation;
using Grosvenor.Business.Validation.Enums;

namespace Grosvenor.Business
{
    public class DishesProcess
    {
        private IEnumDishValidation _enumDishValidation;

        public DishesProcess()
        {
            _enumDishValidation = new InputedDishContainsInEnum();
        }
        //private List<Dish> getMorningDish()
        private Dictionary<EnumDishes, Dish> getMorningDish()
        {
            Dictionary<EnumDishes, Dish> dishDictionary = new Dictionary<EnumDishes, Dish>();
            //List<Dish> dishOrder = new List<Dish>();

            dishDictionary.Add(EnumDishes.entree, new Dish() { DayTime = EnumDayTime.morning, DishType = EnumDishes.entree, DishDescription = "eggs" });
            dishDictionary.Add(EnumDishes.side, new Dish() { DayTime = EnumDayTime.morning, DishType = EnumDishes.side, DishDescription = "toast" });
            dishDictionary.Add(EnumDishes.drink, new Dish() { DayTime = EnumDayTime.morning, DishType = EnumDishes.drink, DishDescription = "coffee", CanHaveMultipleOrders = true });

            //dishOrder.Add(new Dish() { DayTime = EnumDayTime.morning, DishType = EnumDishes.entree, DishDescription = "eggs" });
            //dishOrder.Add(new Dish() { DayTime = EnumDayTime.morning, DishType = EnumDishes.side, DishDescription = "toast" });
            //dishOrder.Add(new Dish() { DayTime = EnumDayTime.morning, DishType = EnumDishes.drink, DishDescription = "coffee", CanHaveMultipleOrders = true });

            //return dishOrder;
            return dishDictionary;
        }

        //private List<Dish> getNightDish()
        private Dictionary<EnumDishes, Dish> getNightDish()
        {
            //List<Dish> dishOrder = new List<Dish>();
            Dictionary<EnumDishes, Dish> dishDictionary = new Dictionary<EnumDishes, Dish>();

            dishDictionary.Add(EnumDishes.entree, new Dish() { DayTime = EnumDayTime.night, DishType = EnumDishes.entree, DishDescription = "steak" });
            dishDictionary.Add(EnumDishes.side, new Dish() { DayTime = EnumDayTime.night, DishType = EnumDishes.side, DishDescription = "potato", CanHaveMultipleOrders = true });
            dishDictionary.Add(EnumDishes.drink, new Dish() { DayTime = EnumDayTime.night, DishType = EnumDishes.drink, DishDescription = "wine" });
            dishDictionary.Add(EnumDishes.dessert, new Dish() { DayTime = EnumDayTime.night, DishType = EnumDishes.dessert, DishDescription = "cake" });

            //dishOrder.Add(new Dish() { DayTime = EnumDayTime.night, DishType = EnumDishes.entree, DishDescription = "steak" });
            //dishOrder.Add(new Dish() { DayTime = EnumDayTime.night, DishType = EnumDishes.side, DishDescription = "potato", CanHaveMultipleOrders = true });
            //dishOrder.Add(new Dish() { DayTime = EnumDayTime.night, DishType = EnumDishes.drink, DishDescription = "wine" });
            //dishOrder.Add(new Dish() { DayTime = EnumDayTime.night, DishType = EnumDishes.dessert, DishDescription = "cake" });

            //return dishOrder;
            return dishDictionary;
        }

        //public List<Dish> getAllPossibleDishes(EnumDayTime dayTime)
        public Dictionary<EnumDishes, Dish> getAllPossibleDishes(EnumDayTime dayTime)
        {
            //List<Dish> listReturn = new List<Dish>();
            Dictionary<EnumDishes, Dish> dictReturn = new Dictionary<EnumDishes, Dish>();
            if (dayTime == EnumDayTime.morning)
            {
                //listReturn.AddRange(getMorningDish());
                dictReturn = getMorningDish();

            }
            if (dayTime == EnumDayTime.night)
            {
                //listReturn.AddRange(getNightDish());
                dictReturn = getNightDish();
            }
            return dictReturn;
        }

        public EnumDishes GetDish(string dishOption)
        {
            var itemToReturn = EnumDishes.entree;

            foreach (EnumDishes item in Enum.GetValues(typeof(EnumDishes)))
            {
                if (item.Equals(Enum.Parse(typeof(EnumDishes), dishOption)))
                {
                    itemToReturn = item;
                }
            }
            return itemToReturn;
        }

        public bool checkIfIsAValidDish(string dishOption)
        {
            return _enumDishValidation.ValidateDish(dishOption);
        }
    }
}
