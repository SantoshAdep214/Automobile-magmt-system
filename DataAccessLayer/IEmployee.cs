using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.models;

namespace DataAccessLayer
{
    public interface IEmployee
    {
        // public bool login(string email, string pass);
       public bool login(Employee e);

        public bool ChangePassword(string email, Employee e);
        public bool ForgotPass(string email, Employee e);
        public bool InsertEmployee(Employee emp);
       // public bool SelectById(int id);
        public List<Customer> GetAllCustomer();
        public List<Orderbook> OrderList();
        public bool EditEmployeeDetails(int id, Employee e);
        public List<Carservice> GetAllServices();
        public List<Carservice> SelectServiceByCustomerId(int id);
        //public List<Cardetail> GetCarnobyCarmodel(string carmodel);
        public List<Orderbook> billGeneration(int id);


    }
}
