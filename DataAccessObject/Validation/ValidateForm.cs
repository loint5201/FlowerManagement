using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BuiKhoiNguyenRepo.Validation
{
    public static class ValidateForm
    {
        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Match match = Regex.Match(email, emailPattern);
            return match.Success;
        }
        public static bool ContaintOnlyChar(string msg)
        {
            string pattern = @"^[a-zA-Z]+$";
            Match match = Regex.Match(msg, pattern);
            return match.Success;
        }
        public static bool ContainOnlyOneAndZero(string msg)
        {
            string pattern = "^(1|0)$";
            Match match = Regex.Match(msg, pattern);
            return match.Success;
        }
        public static bool ContaintOnlyCharAndSpace(string msg)
        {
            string pattern = @"^[a-zA-Z\s]+$";
            Match match = Regex.Match(msg, pattern);
            return match.Success;
        }

        public static bool ContainOnlyNumber(string msg)
        {
            string pattern = @"^[0-9]+$";
            Match match = Regex.Match(msg, pattern);
            return match.Success;
        }

        public static bool StartWithANumber(string msg)
        {
            string pattern = @"^[0-9]$";
            Match match = Regex.Match(msg[0].ToString(), pattern);
            return match.Success;
        }

        public static bool checkDate(string date)
        {
            string[] formats = { "MM/dd/yyyy", "M/dd/yyyy" , "M/d/yyyy" , "MM/d/yyyy" };
            DateTime parsedDate;
            bool isValid = DateTime.TryParseExact(date, formats, null, System.Globalization.DateTimeStyles.None, out parsedDate);
            if(isValid)
            {
                return true;
            }
            return false;
        }
    }
}
