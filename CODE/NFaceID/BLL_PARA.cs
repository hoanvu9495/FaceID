using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFaceID
{
    public class BLL_PARA
    {
        private static string _PathFace = "history/Face/";
        private static string _PathHistory = "history/History/";
        private static string _PathExcel = "history/Report/";
        public BLL_PARA()
        {
            string[] lines = System.IO.File.ReadAllLines(@"folder.txt");
            _PathFace = lines[2];
            _PathHistory = lines[3];
            _PathExcel = lines[3];
        }

        public static string PathExcel
        {
            get { return BLL_PARA._PathExcel; }
            set { BLL_PARA._PathExcel = value; }
        }

        public static string PathHistory
        {
            get { return BLL_PARA._PathHistory; }
            set { BLL_PARA._PathHistory = value; }
        }

        public static string PathFace
        {
            get { return _PathFace; }
            set { _PathFace = value; }
        }


    }
}
