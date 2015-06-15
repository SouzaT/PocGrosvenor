using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Business.Enumerations;
using Grosvenor.Business.Validation.Base;

namespace Grosvenor.Business.Validation.Enums
{
    public class InputedDayTimeContainsInEnum : ValidationBase
    {
        public bool isSatisfiedBy(string daytime)
        {
            return base.ValidateDayTime(daytime);
        }
    }
}
