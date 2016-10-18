using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFaceID.Entities;
using System.Data.SqlClient;

namespace NFaceID.DAL
{
    public class DAL_PERSON
    {
        public static PERSONAL getPerByID(int id)
        {
            try
            {
                var db = new DBEntities();
                var per = db.PERSONALs.Where(x => x.ID == id).SingleOrDefault();
                return per;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static bool DELETE(int id)
        {
            try
            {
                var db = new DBEntities();
                var temp = db.EMPLOYEEs.Where(x => x.ID == id).SingleOrDefault();
                if (temp != null)
                {
                    temp.ISDELETE = true;
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

        public static List<PERSONAL> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                var lst = db.PERSONALs.ToList();
                return lst;
            }
            catch (Exception)
            {
                return null;
            }

        }


        public static bool INSERT(PERSONAL obj)
        {
            try
            {
                DBEntities db = new DBEntities();
                db.PERSONALs.Add(obj);
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

                var newID = db.PERSONALs.Take(1).OrderByDescending(x => x.ID).SingleOrDefault();

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





    }
}
