using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.DataAccessLayer;


namespace WebApplication1.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
            using (SalesERPDAL dal = new SalesERPDAL())
            {
              
                var list = dal.Employees.ToList();
                return list;
                
            }   
        }
        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
        public Employee Query(int id)
        {
            using (var db = new SalesERPDAL())
            {
                Employee emp = db.Employees.Find(id);
                return emp;
            }
        }
        public void Updele(Employee e)
        {
            using (var db = new SalesERPDAL())
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
       public IEnumerable <Employee >Search(string searchString)
        {
            using (var db = new SalesERPDAL())
            {
                return db.Employees.Where(e => e.Name.Contains(searchString)).ToList();
            }
        }
     
    }
}