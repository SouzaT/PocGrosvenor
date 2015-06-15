using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Business.Enumerations;

namespace Grosvenor.Business
{
    public class ProcessOrder
    {
        private Dictionary<EnumDishes, Dish> _dishes;
        private DishesProcess _getDishes;
        private bool _HasSomeError;

        public ProcessOrder()
        {
            _getDishes = new DishesProcess();
            _HasSomeError = false;
            _dishes = new Dictionary<EnumDishes, Dish>();
        }

        public List<string> processDishOrder(List<string> dishesList, EnumDayTime dayTime)
        {
            _dishes = _getDishes.getAllPossibleDishes(dayTime);

            AddDishOrderForTimeDaySelection(dishesList);
            
            var returnValue = PrepareResult(_dishes);

            return returnValue;
        }

        private List<string> PrepareResult(Dictionary<EnumDishes, Dish> dishes)
        {
            List<string> returnList = new List<string>();
            foreach (var dish in dishes.Values)
            {
                if (dish.QuantityDishes == 1)
                {
                    returnList.Add(dish.DishDescription);
                }
                if (dish.QuantityDishes > 1)
                {
                    returnList.Add(dish.DishDescription + string.Format("(x{0})", dish.QuantityDishes));
                }

            }
            if (_HasSomeError)
                returnList.Add("error");
            return returnList;
        }

        private void AddDishOrderForTimeDaySelection(List<string> dishesList)
        {
            for (int i = 0; i < dishesList.Count; i++)
            {
                if (_getDishes.checkIfIsAValidDish(dishesList[i]))
                {
                    var dishOrdered = _getDishes.GetDish(dishesList[i]);
                    if (!_dishes.ContainsKey(dishOrdered))
                    {
                        _HasSomeError = true;
                        break;
                    }

                    if (checkIsOkToInsert(_dishes[dishOrdered]))
                    {
                        _dishes[dishOrdered].QuantityDishes++;
                    }
                    else
                    {
                        _HasSomeError = true;
                        break;
                    }
                }
                else
                {
                    _HasSomeError = true;
                    break;
                }
            }
        }

        private bool checkIsOkToInsert(Dish dishOrder)
        {
            return (!dishOrder.HasError &&(dishOrder.CanHaveMultipleOrders || dishOrder.QuantityDishes == 0));
        }
    }
}
