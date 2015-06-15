using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grosvenor.Business.Enumerations;
using Grosvenor.Business.Validation.Base;

namespace Grosvenor.Business.Validation.Enums
{
    class InputedDishContainsInEnum : ValidationBase
    {
        public bool isSatisfiedBy(string daytime)
        {
            return base.ValidateDayTime(daytime);
        }
    }
}
