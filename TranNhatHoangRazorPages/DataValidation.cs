using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TranNhatHoangRazorPages
{
    public class DataValidation
    {
        public bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsNumber(String s)
        {
            int result;
            return int.TryParse(s, out result);
        }
        public bool IsDecimal(string str)
        {
            decimal result;
            return decimal.TryParse(str, out result);
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
