using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class CategoriesDAO
    {
        private MyDBContext db = new MyDBContext();
        public List<Categories> getList()
        {
            return db.Categories.ToList();
        }

        //Seclect * from cho index vs status 1,2
        public List<Categories> getList(string status = "ALL") //0,1,2
        {
            List<Categories> list = null;
            switch(status)
            {
                case "Index": //1,2
                    list = db.Categories.Where(m => m.Status != 0).ToList();
                    break;
                case "Trash":
                    list = db.Categories.Where(m => m.Status == 0).ToList();
                    break;
                default:
                    list = db.Categories.ToList();
                    break;
            }
            return list;
        }

        //details
        public Categories getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Categories.Find(id);
            }
        }

        public int Insert(Categories row)
        {
            db.Categories.Add(row);
            return db.SaveChanges();
        }

        public int Update(Categories row)
        {
            db.Entry(row).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(Categories row)
        {
            db.Categories.Remove(row);
            return db.SaveChanges();
        }
    }
}
