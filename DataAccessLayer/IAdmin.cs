using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.models;


namespace DataAccessLayer
{
    public interface IAdmin
    {
        // public bool login(string email, string pass);
        public bool login(Carsadmin c);
        public bool InsertCars(Cardetail car);

        public bool UpdateCars(int carno, Cardetail c);
              
        public List<Employee> GetAllEmployees();
        public List<Customer> GetAllCustomers();

        public List<Orderbook> OrdereList();

        public List<Carservice> GetAllServices();

        public List<Carservice> SelectServiceByCustomerId(int id);
        public List<Orderbook> SelectOrderByCustomerId(int id);
        public bool DeleteEmployeeDetails(int id);

        public List<Cardetail> GetAllCars();


    }
}
