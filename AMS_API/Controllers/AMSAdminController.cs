using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.models;
using DataAccessLayer;
using Microsoft.AspNetCore.Cors;

namespace AMS_API.Controllers
{
    [Route("/api/AMSAdmin")]
    [EnableCors("AllowPolicy")]  
    [ApiController]  
    public class AMSAdminController : ControllerBase
    {
        readonly AMSDBContext db;
        readonly IAdmin admin;

        public AMSAdminController(AMSDBContext db, IAdmin admin)
        {
            this.db = db;
            this.admin = admin;
        }

        [HttpPost]
        [Route("/api/AMSAdmin/login")]
        /* public bool login(string name, string pass)
         {
             return admin.login(name, pass);
         }*/
        public bool login(Carsadmin c)
        {
            return admin.login(c);
        }

        [HttpPost]
        [Route("/api/AMSAdmin/InsertCars")]
        public bool InsertCars(Cardetail car)
        {
            return admin.InsertCars(car);
        }

        [HttpPut]
        [Route("/api/AMSAdmin/UpdateCars")]
        public bool UpdateCars(int carno, Cardetail c)
        {
            return admin.UpdateCars(carno, c);
        }

        [HttpPut]
        [Route("/api/AMSAdmin/DeleteEmployeeDetails/{id}")]
        public bool DeleteEmployeeDetails(int id) 
        {

            return admin.DeleteEmployeeDetails(id);

        }

        [HttpGet]
        [Route("/api/AMSAdmin/SelectServiceByCustomerId/{id}")]
        public List<Carservice> SelectServiceByCustomerId(int id)
        {
            return admin.SelectServiceByCustomerId(id);
        }

        [HttpGet]
        [Route("/api/AMSAdmin/GetAllEmployees")]
        public List<Employee> GetAllEmployees() 
        {
            return admin.GetAllEmployees();
        }

        [HttpGet]
        [Route("/api/AMSAdmin/GetAllCustomers")]
        public List<Customer> GetAllCustomers() 
        {
            return admin.GetAllCustomers();
        }

        [HttpPost]
        [Route("/api/AMSAdmin/OrderList")]
        public List<Orderbook> OrdereList()
        {
            return admin.OrdereList();
        }

        [HttpGet]
        [Route("/api/AMSAdmin/GetAllServices")]
        public List<Carservice> GetAllServices()
        {
            return admin.GetAllServices();
        }

        [HttpGet]
        [Route("/api/AMSAdmin/SelectOrderByCustomerId/{id}")]
        public List<Orderbook> SelectOrderByCustomerId(int id)
        {
            return admin.SelectOrderByCustomerId(id);
        }

       
        [HttpGet]
        [Route("/api/AMSAdmin/GetAllCars")]
        public List<Cardetail> GetAllCars()
        {
            return admin.GetAllCars();
        }
    }
}
