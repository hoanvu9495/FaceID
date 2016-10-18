using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFaceID.BLL
{
    public class CODE
    {
        public static string timeString(DateTime dt)
        {
            string t=dt.ToShortDateString();
            string rs="";
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i]!='/')
                {
                    rs += t[i].ToString();
                }
            }
            t = dt.ToShortTimeString();
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i]!=':')
                {
                    rs += t[i].ToString();
                }
            }
            return rs;
        }

        public static string TextDateString(string dt)
        {
            string rs = "";
            for (int i = 0; i < dt.Length; i++)
            {
                if (dt[i] != '/')
                {
                    rs += dt[i].ToString();
                }
            }

            return rs;
        }
    }
}
