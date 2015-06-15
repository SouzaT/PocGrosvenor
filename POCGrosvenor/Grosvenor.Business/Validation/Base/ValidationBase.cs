using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Business.Interfaces.Validation;
using Grosvenor.Business.Enumerations;

namespace Grosvenor.Business.Validation.Base
{
    public abstract class ValidationBase : IEnumDayTimeValidation, IEnumDishValidation
    {
        public bool ValidateDayTime(string dayTime)
        {
            return EnumDayTime.IsDefined(typeof(EnumDayTime), dayTime);
        }

        public bool ValidateDish(string dish)
        {
            var returnBool = EnumDishes.IsDefined(typeof(EnumDishes), Convert.ToInt32(dish));
            return returnBool;
        }
    }
}
