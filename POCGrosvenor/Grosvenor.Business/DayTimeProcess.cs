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
    public class DayTimeProcess
    {
        private IEnumDayTimeValidation _enumDayTimeValidation;

        public DayTimeProcess()
        {
            _enumDayTimeValidation = new InputedDayTimeContainsInEnum();
        }

        public EnumDayTime getDayTime(string daytime)
        {
            
            if (!_enumDayTimeValidation.ValidateDayTime(daytime))
                throw new Exception("Invalid Daytime Selection!");

            var itemToReturn = EnumDayTime.morning;

            foreach (EnumDayTime item in Enum.GetValues(typeof(EnumDayTime)))
            {
                if (item.Equals(Enum.Parse(typeof(EnumDayTime), daytime)))
                {
                    itemToReturn = item;
                }
            }
            return itemToReturn;
        }
    }
}
