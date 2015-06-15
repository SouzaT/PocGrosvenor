using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Business.Interfaces.Validation
{
    public interface IEnumDayTimeValidation
    {
        bool ValidateDayTime(string dayTime);
    }
}
