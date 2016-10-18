using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NFaceID.BLL
{
    public class BLL_Validate
    {
        public static bool EmailValidate(string str)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(str);
            if (match.Success)
                return true;
            else
                return false;
        }

        public static bool PassWordValidate(string str)
        {
            Regex reg = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d!$%@#£€*?&]{8,}$");
            Match match = reg.Match(str);
            if (match.Success)
                return true;
            else
                return false;
        }

        public static bool NameValidate(string str)
        {
            Regex reg = new Regex(@"^[a-zA-Z0-9]{3,16}$");
            Match match = reg.Match(str);
            if (match.Success)
                return true;
            else

                return false;

        }

        public static bool PhoneValidate(string str)
        {
            Regex reg = new Regex(@"^[0-9]{10,20}$");
            Match match = reg.Match(str);
            if (match.Success)
                return true;
            else

                return false;
        }
        public static bool CMTValidate(string str)
        {
            Regex reg = new Regex(@"^[0-9]{9,12}$");
            Match match = reg.Match(str);
            if (match.Success)
                return true;
            else

                return false;
        }
        public static bool NumValidate(string str)
        {
            Regex reg = new Regex(@"^[0-9]{3,20}$");
            Match match = reg.Match(str);
            if (match.Success)
                return true;
            else

                return false;
        }
    }
}
