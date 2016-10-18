using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFaceID.Entities;
using System.Data;

namespace NFaceID.BLL
{
    public class BLL_PERSON
    {
        public static DataTable getAll()
        {
            try
            {
                var db = new DBEntities();
                var lst = db.PERSONALs.ToList();
                DataTable dt = BLL_ExtendList.ToDataTable(lst);
                return dt;
            }
            catch (Exception exx)
            {
                return null;
            }
        }
    }
}
