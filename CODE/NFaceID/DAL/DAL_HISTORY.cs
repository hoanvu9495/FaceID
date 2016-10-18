using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFaceID.Entities;
using System.Data.SqlClient;

namespace NFaceID.DAL
{
    public class DAL_HISTORY
    {
        public static List<HISTORY> filterByPer(DateTime s, DateTime end, int id)
        {
            try
            {
                DBEntities db = new DBEntities();
                var lst = db.HISTORies.Where(x => x.TIME_UPDATE >= s && x.TIME_UPDATE <= end && x.ID_PER==id).OrderByDescending(x=>x.TIME_UPDATE).ToList();
                return lst;
            }
            catch (SqlException)
            {

                return null;
            }
        }
        public static int PageCount(DateTime s, DateTime e)
        {
            try
            {
                DBEntities db = new DBEntities();
                int lst = db.HISTORies.Where(x => x.TIME_UPDATE >= s && x.TIME_UPDATE <= e).ToList().Count;
                if (lst%5!=0)
                {
                    lst = lst / 5 + 1;

                }
                else
                {
                    lst = lst / 5;
                }
                return lst;
            }
            catch (SqlException)
            {

                return 0;
            }
        }
        public static List<HISTORY> filterPage(DateTime s, DateTime e,int num)
        {
            try
            {
                 DBEntities db = new DBEntities();
                 var lst = db.HISTORies.Where(x => x.TIME_UPDATE >= s && x.TIME_UPDATE <= e).OrderBy(x=>x.ID).Skip((num-1) * 5).Take(5).ToList();
                return lst;
            }
            catch (SqlException)
            {

                return null;
            }
        }
        public static bool DELETE(int id)
        {
            try
            {
                var db = new DBEntities();
                var temp = db.HISTORies.Where(x => x.ID == id).SingleOrDefault();
                if (temp != null)
                {
                   db.HISTORies.Remove(temp);
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

        public static List<HISTORY> getByEmp(int id)
        {
            try
            {
                DBEntities db = new DBEntities();
                var lst = db.HISTORies.Where(x=>x.ID_PER==id).OrderByDescending(x=>x.TIME_UPDATE).ToList();
                return lst;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public static List<HISTORY> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                var lst = db.HISTORies.ToList();
                return lst;
            }
            catch (Exception)
            {

                return null;
            }

        }


        public static bool INSERT(HISTORY obj)
        {
            try
            {
                DBEntities db = new DBEntities();
                db.HISTORies.Add(obj);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {

                return false;
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

                var newID = db.HISTORies.Take(1).OrderByDescending(x => x.ID).SingleOrDefault();

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
        public static bool UPDATE(HISTORY obj)
        {
            try
            {
                var db = new DBEntities();
                var temp = db.HISTORies.Where(x => x.ID == obj.ID).SingleOrDefault();
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
