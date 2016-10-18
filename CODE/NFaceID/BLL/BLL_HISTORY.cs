
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
    public class BLL_HISTORY
    {

        public static DataTable filterByPer(DateTime s, DateTime end, int id)
        {
            var lst = DAL_HISTORY.filterByPer(s,end,id);
            var dt = new DataTable();
            dt = BLL_ExtendList.ToDataTable(lst);
            DataColumn STT = new DataColumn();
            STT.ColumnName = "STT";
            dt.Columns.Add(STT);
            DataColumn NV = new DataColumn();
            NV.ColumnName = "NV";
            dt.Columns.Add(NV);
            DataColumn NGAY = new DataColumn();
            NGAY.ColumnName = "NGAY";
            dt.Columns.Add(NGAY);
            DataColumn TG = new DataColumn();
            TG.ColumnName = "TG";
            dt.Columns.Add(TG);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
                //PERSONAL per = DAL_PERSON.getPerByID(int.Parse(dt.Rows[i]["ID_PER"].ToString()));
                //if (per.TYPE_PS == 1)
                {
                    dt.Rows[i]["NV"] = DAL_EMPLOYEE.GetFullName(int.Parse(dt.Rows[i]["ID_PER"].ToString()));
                }
                //else
                //{
                //    dt.Rows[i]["NV"] = "Khách";
                //}
                DateTime time = (DateTime)dt.Rows[i]["TIME_UPDATE"];
                dt.Rows[i]["NGAY"] = time.ToShortDateString();
                dt.Rows[i]["TG"] = time.ToShortTimeString();
            }
            dt.Columns.Remove("TIME_UPDATE");
            dt.Columns.Remove("IN_OUT");
            dt.Columns.Remove("PERSONAL");
            dt.Columns.Remove("ID");
            dt.Columns.Remove("ID_PER");
            dt.Columns.Remove("IMG");


            return dt;
        }
        public static DataTable getByEmp(int id)
        {
            var lst = DAL_HISTORY.getByEmp(id);
            var dt = new DataTable();
            dt = BLL_ExtendList.ToDataTable(lst);
            DataColumn STT = new DataColumn();
            STT.ColumnName = "STT";
            dt.Columns.Add(STT);
            DataColumn NV = new DataColumn();
            NV.ColumnName = "NV";
            dt.Columns.Add(NV);
            DataColumn NGAY = new DataColumn();
            NGAY.ColumnName = "NGAY";
            dt.Columns.Add(NGAY);
            DataColumn TG = new DataColumn();
            TG.ColumnName = "TG";
            dt.Columns.Add(TG);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
                //PERSONAL per = DAL_PERSON.getPerByID(int.Parse(dt.Rows[i]["ID_PER"].ToString()));
                //if (per.TYPE_PS == 1)
                {
                    dt.Rows[i]["NV"] = DAL_EMPLOYEE.GetFullName(int.Parse(dt.Rows[i]["ID_PER"].ToString()));
                }
                //else
                //{
                //    dt.Rows[i]["NV"] = "Khách";
                //}
                DateTime time = (DateTime)dt.Rows[i]["TIME_UPDATE"];
                dt.Rows[i]["NGAY"] = time.ToShortDateString();
                dt.Rows[i]["TG"] = time.ToShortTimeString();
            }
            dt.Columns.Remove("TIME_UPDATE");
            dt.Columns.Remove("IN_OUT");
            dt.Columns.Remove("PERSONAL");
            dt.Columns.Remove("ID");
            dt.Columns.Remove("ID_PER");
            dt.Columns.Remove("IMG");


            return dt;
        }
        public static DataTable getAll()
        {
            var lst = DAL_HISTORY.GetAll();
            var dt = new DataTable();
            dt = BLL_ExtendList.ToDataTable(lst);
            DataColumn STT = new DataColumn();
            STT.ColumnName = "STT";
            dt.Columns.Add(STT);
            DataColumn NV = new DataColumn();
            NV.ColumnName = "NV";
            dt.Columns.Add(NV);
            DataColumn NGAY = new DataColumn();
            NGAY.ColumnName = "NGAY";
            dt.Columns.Add(NGAY);
            DataColumn TG = new DataColumn();
            TG.ColumnName = "TG";
            dt.Columns.Add(TG);
            DataColumn STATUS = new DataColumn();
            STATUS.ColumnName = "STATUS";
            dt.Columns.Add(STATUS);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
                //PERSONAL per = DAL_PERSON.getPerByID(int.Parse(dt.Rows[i]["ID_PER"].ToString()));
                //if (per.TYPE_PS == 1)
                {
                    dt.Rows[i]["NV"] = DAL_EMPLOYEE.GetFullName(int.Parse(dt.Rows[i]["ID_PER"].ToString()));
                }
                //else
                //{
                //    dt.Rows[i]["NV"] = "Khách";
                //}
                DateTime time = (DateTime)dt.Rows[i]["TIME_UPDATE"];
                dt.Rows[i]["NGAY"] = time.ToShortDateString();
                dt.Rows[i]["TG"] = time.ToShortTimeString();
                if (dt.Rows[i]["IN_OUT"]=="False")
                {
                      dt.Rows[i]["STATUS"]="Ra";

                  }else{
                      dt.Rows[i]["STATUS"]="Ra";

                  }

            }
            dt.Columns.Remove("TIME_UPDATE");
            dt.Columns.Remove("IN_OUT");
            return dt;
        }
        public static DataTable filterPage(DateTime s, DateTime e,int num)
        {
            var lst = DAL_HISTORY.filterPage(s, e,num);
            var dt = new DataTable();
            dt = BLL_ExtendList.ToDataTable(lst);
            DataColumn STT = new DataColumn();
            STT.ColumnName = "STT";
            dt.Columns.Add(STT);
            DataColumn NV = new DataColumn();
            NV.ColumnName = "NV";
            dt.Columns.Add(NV);
            DataColumn NGAY = new DataColumn();
            NGAY.ColumnName = "NGAY";
            dt.Columns.Add(NGAY);
            DataColumn TG = new DataColumn();
            TG.ColumnName = "TG";
            dt.Columns.Add(TG);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = (num-1)*5+i + 1;
                //PERSONAL per = DAL_PERSON.getPerByID(int.Parse(dt.Rows[i]["ID_PER"].ToString()));
                //if (per.TYPE_PS == 1)
                {
                    dt.Rows[i]["NV"] = DAL_EMPLOYEE.GetFullName(int.Parse(dt.Rows[i]["ID_PER"].ToString()));
                }

                DateTime time = (DateTime)dt.Rows[i]["TIME_UPDATE"];
                dt.Rows[i]["NGAY"] = time.ToShortDateString();
                dt.Rows[i]["TG"] = time.ToShortTimeString();

            }
            dt.Columns.Remove("TIME_UPDATE");
            dt.Columns.Remove("IN_OUT");


            return dt;
        }
        //public static DataTable filter(DateTime s, DateTime e)
        //{
        //    var lst = DAL_HISTORY.filter(s,e);
        //    var dt = new DataTable();
        //    dt = BLL_ExtendList.ToDataTable(lst);
        //    DataColumn STT = new DataColumn();
        //    STT.ColumnName = "STT";
        //    dt.Columns.Add(STT);
        //    DataColumn NV = new DataColumn();
        //    NV.ColumnName = "NV";
        //    dt.Columns.Add(NV);
        //    DataColumn NGAY = new DataColumn();
        //    NGAY.ColumnName = "NGAY";
        //    dt.Columns.Add(NGAY);
        //    DataColumn TG = new DataColumn();
        //    TG.ColumnName = "TG";
        //    dt.Columns.Add(TG);
        //    if (dt.Rows.Count > 20)
        //    {
        //        rowCount = dt.Rows.Count / 20;
        //    }
        //    if (rowCount>1)
        //    {
                
        //    }
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        dt.Rows[i]["STT"] = i + 1;
        //        //PERSONAL per = DAL_PERSON.getPerByID(int.Parse(dt.Rows[i]["ID_PER"].ToString()));
        //        //if (per.TYPE_PS == 1)
        //        {
        //            dt.Rows[i]["NV"] = DAL_EMPLOYEE.GetFullName(int.Parse(dt.Rows[i]["ID_PER"].ToString()));
        //        }
                
        //        DateTime time = (DateTime)dt.Rows[i]["TIME_UPDATE"];
        //        dt.Rows[i]["NGAY"] = time.ToShortDateString();
        //        dt.Rows[i]["TG"] = time.ToShortTimeString();

        //    }
        //    dt.Columns.Remove("TIME_UPDATE");
        //    dt.Columns.Remove("IN_OUT");
          
            
        //    return dt;
        //}
    }
}
