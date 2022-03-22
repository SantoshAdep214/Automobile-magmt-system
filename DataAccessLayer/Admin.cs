using System;
using System.Collections.Generic;
using DataAccessLayer.models;
using System.Linq;

namespace DataAccessLayer
{
    public class Admin : IAdmin
    {

        //AMSDBContext db = new AMSDBContext();
        readonly AMSDBContext db;
        public Admin(AMSDBContext db)
        {
            this.db = db;
        }



        /*  public bool login(string name, string pass)*/
        public bool login(Carsadmin c)
        {
            try
            {
                var data = db.Carsadmins.Where(x => x.Adminname == c.Adminname).SingleOrDefault();
                if (data.Adminname == c.Adminname && data.Adminpass == c.Adminpass)
                    return true;

            }
            catch
            {
                Console.WriteLine("admin is not valid........");
            }
            return false;
        }



        public bool InsertCars(Cardetail car)
        {
            try
            {
                db.Cardetails.Add(car);
                var res = db.SaveChanges();
                if (res > 0)
                    return true;
            }
            catch
            {
                throw;
            }
            return false;

        }

        public bool UpdateCars(int carno, Cardetail c)
        {
            try
            {
                var update = db.Cardetails.Where(x => x.Carno == carno).SingleOrDefault();

                update.Carmodel = c.Carmodel;
                update.Carmileage = c.Carmileage;
                update.Carcolor = c.Carcolor;
                update.Cartopspeed = c.Cartopspeed;
                update.Carprice = c.Carprice;
                update.Carquantity = c.Carquantity;



                var res = db.SaveChanges();
                if (res > 0)
                    return true;
            }
            catch
            {
                Console.WriteLine("updated not successsfully......");
            }
            return false;
        }



        public bool DeleteEmployeeDetails(int id)
        {
            try
            {
                var del = db.Employees.Where(x => x.Employeeid == id).SingleOrDefault();
                db.Employees.Remove(del);
                var res = db.SaveChanges();
                if (res > 0)
                    return true;
            }
            catch
            {
                throw;
            }
            return false;
        }


        public List<Carservice> SelectServiceByCustomerId(int id)
        {
            try
            {
                var res = db.Carservices.Where(x => x.Customerid == id).ToList();
                if (res.Count == 0)
                    Console.WriteLine("No records found");

                return res;
            }
            catch
            {
                throw;
            }
            //throw new NotImplementedException();
        }



        public List<Employee> GetAllEmployees()
        {
           /* var res = db.Employees.Where(x => x.Employeeid > 8 && x.Employeeid < 15).ToList();
            return res;*/

       
             var res = db.Employees.ToList();
             return res;  
        }

      /*  public List<Employee> GetAllEmployees()
        {
            Response.Redirect("")


            *//* var res = db.Employees.ToList();*/
            /* return res;  *//*
        }*/


        public List<Customer> GetAllCustomers()
        {
            var res = db.Customers.ToList();
            return res;            
        }

        public List<Orderbook> OrdereList()
        {
            var res = db.Orderbooks.ToList();
            return res;     
        }

        public List<Carservice> GetAllServices()
        {
            var res = db.Carservices.ToList();
            return res; 
        }

       public List<Orderbook> SelectOrderByCustomerId(int id)
        {
            throw new NotImplementedException(); 
        }

        public List<Cardetail> GetAllCars()
        {
            var res = db.Cardetails.ToList();
            return res;
        }

       /* public List<Employee> GetAllEmployees()
        {
            var res = db.Employees.ToList();
            return res;
        }*/
    }
}
