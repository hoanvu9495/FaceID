using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using NFaceID.Entities;
namespace NFaceID.DAL
{
    public class DAL_EMPLOYEE
    {

        public static List<EMPLOYEE> SearchEmp(string key)
        {
            var lst = new List<EMPLOYEE>();
            try
            {
                var db = new DBEntities();
                lst = db.EMPLOYEEs.Where(x => x.NAME.Contains(key)).ToList();
            }
            catch (SqlException ex)
            {

                return null;
            }
            return lst;

        }
        public static EMPLOYEE getEmpByIDPER(int id)
        {
            var lst = new EMPLOYEE();
            try
            {
                var db = new DBEntities();
                lst = db.EMPLOYEEs.Where(x => x.ID_PS == id).SingleOrDefault();
            }
            catch (SqlException ex)
            {

                return null;
            }
            return lst;

        }
        public static EMPLOYEE SearchEmpByName(string key)
        {
            var lst = new EMPLOYEE();
            try
            {
                var db = new DBEntities();
                lst = db.EMPLOYEEs.Where(x => x.NAME== key).SingleOrDefault();
            }
            catch (SqlException ex)
            {

                return null;
            }
            return lst;

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
        public static string GetFullName(int id)
        {
            try
            {
                var db = new DBEntities();
                var name = db.EMPLOYEEs.Where(x => x.ID == id).SingleOrDefault();
                if (name != null)
                {
                    return name.NAME;
                }
                return "Không tìm thấy";
            }
            catch (SqlException ex)
            {

                return "Lỗi";

            }
        }

        public static List<EMPLOYEE> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                var lst = db.EMPLOYEEs.Where(x => x.ISDELETE == false).ToList();
                lst.AddRange(db.EMPLOYEEs.Where(x => x.ISDELETE == true).ToList());
                return lst;
            }
            catch (Exception)
            {

                return null;
            }

        }


        public static bool INSERT(EMPLOYEE obj)
        {
            try
            {
                DBEntities db = new DBEntities();
                db.EMPLOYEEs.Add(obj);
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
        public static bool CheckExist(string name)
        {
            var db = new DBEntities();
            var rs = db.EMPLOYEEs.Where(x => x.NAME == name).SingleOrDefault();
            if (rs != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///Lay ID moi
        /// </summary>
        /// <returns></returns>
        public static int getIDNew()
        {
            try
            {
                var db = new DBEntities();

                var newID = db.EMPLOYEEs.Take(1).OrderByDescending(x => x.ID).SingleOrDefault();

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
        public static bool UPDATE(EMPLOYEE obj)
        {
            try
            {
                var db = new DBEntities();
                var temp = db.EMPLOYEEs.Where(x => x.ID == obj.ID).SingleOrDefault();
                if (temp != null)
                {
                    temp.GHICHU = obj.GHICHU;
                    temp.NAME = obj.NAME;

                    temp.CMT = obj.CMT;
                    temp.PHONE = obj.PHONE;
                    temp.ADDRESS_EMP = obj.ADDRESS_EMP;
                    temp.EMAIL = obj.EMAIL;
                    temp.GENDER = obj.GENDER;
                    temp.IMG_FACE = obj.IMG_FACE;
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
