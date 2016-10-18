using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFaceID.Entities;
using NFaceID.DAL;
using System.Data;

namespace NFaceID.BLL
{
    public class BLL_ATTENDANCE
    {
        public static DataTable getHisMonth(int id, int month, int year)
        {
            //EMPLOYEE emp = DAL_EMPLOYEE.SearchEmpByName(name);
            var lst = new List<ATTENDANCE>();
            var dt = new DataTable();
            //if (emp!=null)
            //{
            //int id = emp.ID;
            lst = DAL_ATTENDANCE.getByMonthEmp(month, year, id);
            if (lst.Count >0)
            {


                dt = BLL_ExtendList.ToDataTable(lst);
                DataColumn STT = new DataColumn();
                STT.ColumnName = "STT";
                dt.Columns.Add(STT);
                DataColumn NAME = new DataColumn();
                NAME.ColumnName = "NAME";
                dt.Columns.Add(NAME);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["STT"] = i + 1;
                    dt.Rows[i]["NAME"] = DAL_EMPLOYEE.GetFullName(int.Parse(dt.Rows[i]["ID_EMP"].ToString()));
                    var IN = (TimeSpan)dt.Rows[i]["TIME_IN"];
                    //string OUT = dt.Rows[i]["TIME_OUT"];
                    dt.Rows[i]["TIME_IN"] = IN.Hours + ":" + IN.Minutes + ":" + IN.Seconds;
                    try
                    {
                        var OUT = (TimeSpan)dt.Rows[i]["TIME_OUT"];
                        dt.Rows[i]["TIME_OUT"] = OUT.Hours + ":" + OUT.Minutes + ":" + OUT.Seconds;
                    }
                    catch (Exception ex) { }

                    //}
                }
                dt.Columns.Remove("EMPLOYEE");

            }
            return dt;
        }
        public static DataTable getAll()
        {
            var lst = DAL_ATTENDANCE.getAll();
            return BLL_ExtendList.ToDataTable(lst);
        }
        private static bool Check(List<ATTENDANCE> lst, int id, int day, int month, int year)
        {
            var t = new DateTime(year, month, day - 1).Date;
            if (lst.Where(x => x.ID_EMP == id && x.DATE_ATT == t.Date).SingleOrDefault() != null)
            {
                return true;
            }
            return false;
        }
        public static DataTable getByMonth(int month, int year)
        {
            var lst = DAL_ATTENDANCE.getByMonth(month, year);
            var lstName = DAL_EMPLOYEE.GetAll().Select(x => x.ID).Distinct().ToList();
            if (lst != null)
            {

                DataTable rs = new DataTable();
                DataColumn STT = new DataColumn();
                STT.ColumnName = "STT";
                rs.Columns.Add(STT);
                DataColumn ID = new DataColumn();
                ID.ColumnName = "ID";
                rs.Columns.Add(ID);
                DataColumn Name = new DataColumn();
                Name.ColumnName = "Name";
                rs.Columns.Add(Name);
                for (int i = 0; i < DateTime.DaysInMonth(year, month); i++)
                {
                    string name = (i + 1).ToString();
                    DataColumn cl = new DataColumn();
                    cl.ColumnName = name;
                    rs.Columns.Add(cl);
                }
                DataColumn Tong = new DataColumn();
                Tong.ColumnName = "Tong";
                rs.Columns.Add(Tong);
                for (int i = 0; i < lstName.Count; i++)
                {
                    DataRow row = rs.NewRow();
                    int tong = 0;
                    row[0] = i + 1;
                    row[1] = lstName[i];
                    row[2] = DAL_EMPLOYEE.GetFullName(int.Parse(lstName[i].ToString()));
                    for (int j = 2; j < DateTime.DaysInMonth(year, month) + 2; j++)
                    {
                        if (Check(lst, lstName[i], j, month, year))
                        {
                            row[j] = "x";
                            tong++;
                        }

                    }
                    row["Tong"] = tong.ToString();
                    rs.Rows.Add(row);

                }
                return rs;
            }
            return null;
        }

    }
}
