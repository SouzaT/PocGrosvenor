using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Business.Enumerations;

namespace Grosvenor.Business
{
    public class Restaurant
    {
        private DayTimeProcess getDayTime;
        private ProcessOrder processOrder;

        public Restaurant()
        {
            getDayTime = new DayTimeProcess();
            processOrder = new ProcessOrder();
        }

        public List<string> DishOrder(string input)
        {
            List<string> returnList = new List<string>();
            try
            {
                var inputSplited = breakAndRemoveSpaceFromInput(input);

                var dayTime = getDayTime.getDayTime(inputSplited[0]);

                var dishesOrdered = orderListDishOrders(inputSplited);

                if (CheckIfDishListHasAtLeastOneSelection(dishesOrdered))
                    throw new Exception("You must have at least one dish selection!");

                return processOrder.processDishOrder(dishesOrdered, dayTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return returnList;
        }

        private List<string> breakAndRemoveSpaceFromInput(string input)
        {
            var result = input.Split(',').ToList();
            for (int i = 0; i < result.Count(); i++)
            {
                result[i] = result[i].Trim().ToLowerInvariant();
            }
            return result;
        }

        private List<string> orderListDishOrders(List<string> listInputed)
        {
            return listInputed.GetRange(1, listInputed.Count - 1).OrderBy(x => x).ToList();
        }

        public bool CheckIfDishListHasAtLeastOneSelection(List<string> dishList)
        {
            return dishList.Count == 0;
        }
    }
}
