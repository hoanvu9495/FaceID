using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFaceID.Entities;
using System.Data.SqlClient;

namespace NFaceID.DAL
{
    public class DAL_ATTENDANCE
    {

        public static List<ATTENDANCE> getAll()
        {
            try
            {
                var db = new DBEntities();
                var lst = db.ATTENDANCEs.ToList();
                return lst;
            }
            catch (SqlException r)
            {

                return null;
            }

        }
        public static bool Check(int id, DateTime dt)
        {
            var db = new DBEntities();
            string ti = dt.GetDateTimeFormats()[5];
          
            var rs = db.ATTENDANCEs.Where(x => x.ID_EMP == id && x.DATE_ATT==dt.Date).SingleOrDefault();
            if (rs == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DELETE(int id)
        {
            try
            {
                var db = new DBEntities();
                var temp = db.ATTENDANCEs.Where(x => x.ID == id).SingleOrDefault();
                if (temp != null)
                {
                    db.ATTENDANCEs.Remove(temp);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (SqlException ex)
            {

                return false;
            }

        }



        public static List<ATTENDANCE> getByMonthEmp(int month, int year,int id)
        {
            var dtE = new DateTime(year, month, DateTime.DaysInMonth(year, month)).Date;
            var dtS = new DateTime(year, month, 1).Date;
            try
            {
                var db = new DBEntities();
                var lst = db.ATTENDANCEs.Where(x => x.DATE_ATT >= dtS && x.DATE_ATT <= dtE&& x.ID_EMP==id).ToList();
                return lst;
            }
            catch (SqlException ex)
            {

                return null;
            }

        }
        public static List<ATTENDANCE> getByMonth(int month, int year)
        {
            var dtE= new DateTime(year,month,DateTime.DaysInMonth(year,month)).Date;
            var dtS = new DateTime(year, month, 1).Date;
            try
            {
                var db = new DBEntities();
                var lst = db.ATTENDANCEs.Where(x => x.DATE_ATT >= dtS && x.DATE_ATT <= dtE).ToList();
                return lst;
            }
            catch (SqlException ex)
            {
                
                return null;
            }

        }
        public static bool INSERT(ATTENDANCE obj)
        {
            try
            {
                DBEntities db = new DBEntities();
                db.ATTENDANCEs.Add(obj);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public static void updateTimeOut(int id,string img)
        {
            try
            {
                var db = new DBEntities();
                var d = DateTime.Now.Date;
                var rs = db.ATTENDANCEs.Where(x => x.ID_EMP == id && x.DATE_ATT == d).SingleOrDefault();
                if (rs!=null)
                {
                    rs.TIME_OUT = DateTime.Now.TimeOfDay;
                    rs.IMG_OUT = img;
                    db.SaveChanges();
                }
            }
            catch (SqlException rx)
            {

                
            }
        }
        /// <summary>
        /// Kiem tra user_name co ton tai khong
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        /// <summary>
        ///Lay ID moi
        /// </summary>
        /// <returns></returns>
        public static int getIDNew()
        {
            try
            {
                var db = new DBEntities();

                var newID = db.ATTENDANCEs.Take(1).OrderByDescending(x => x.ID).SingleOrDefault();

                if (newID == null)
                {
                    return 1;
                }
                return ++newID.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static bool UPDATE(ATTENDANCE obj)
        {
            try
            {
                var db = new DBEntities();
                var temp = db.ATTENDANCEs.Where(x => x.ID == obj.ID).SingleOrDefault();
                if (temp != null)
                {

                    db.SaveChanges();

                }
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }

        }



    }

}
