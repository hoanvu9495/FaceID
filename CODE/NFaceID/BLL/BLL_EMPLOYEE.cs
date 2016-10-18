using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFaceID.Entities;
using NFaceID.DAL;
using System.Data;
using System.Drawing;
namespace NFaceID.BLL
{
    public class BLL_EMPLOYEE
    {
        public static DataTable getAll()
        {
            var lst = DAL_EMPLOYEE.GetAll();
            var dt = new DataTable();
            dt = BLL_ExtendList.ToDataTable(lst);
            DataColumn STT = new DataColumn();
            STT.ColumnName = "STT";
            dt.Columns.Add(STT);
          
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
            dt.Columns.Remove("ATTENDANCEs");
            dt.Columns.Remove("PERSONAL");
            dt.Columns.Remove("ISDELETE");
            return dt;


        }
        public static DataTable SearchEmp(string key)
        {
            var lst = DAL_EMPLOYEE.SearchEmp(key);
            var dt = new DataTable();
            dt = BLL_ExtendList.ToDataTable(lst);
            DataColumn STT = new DataColumn();
            STT.ColumnName = "STT";
            dt.Columns.Add(STT);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
            dt.Columns.Remove("ATTENDANCEs");
            dt.Columns.Remove("PERSONAL");
            dt.Columns.Remove("ISDELETE");
            return dt;

        }

    }
}
