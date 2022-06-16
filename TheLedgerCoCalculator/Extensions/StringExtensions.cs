using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLedgerCoCalculator.Extensions
{
    public static class StringExtensions
    {
        public static decimal ToDecimal(this string value)
        {
            decimal number = 0;
            Decimal.TryParse(value, out number);
            return number;
        }

        public static int ToInt(this string value)
        {
            int number = 0;
            int.TryParse(value, out number);
            return number;
        }
    }
}
