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
    [Route("/api/AMSEmployee")]
    [EnableCors("AllowPolicy")]
    [ApiController]
    public class AMSEmployeeController : ControllerBase
    {
        readonly AMSDBContext db;
        readonly IEmployee Iemp;

        public AMSEmployeeController(AMSDBContext db, IEmployee emp)
        {
            this.db = db;
            this.Iemp =emp ;
        }
        [HttpPost]
        [Route("/api/AMSEmployee/InsertEmployee")]
        public bool InsertEmployee(Employee emp)
        {
            return Iemp.InsertEmployee(emp);
        }

        [HttpPut]
        [Route("/api/AMSEmployee/UpdateEmployee/{id}")]
        public bool UpdateEmployee(int id, Employee e)
        {
            return Iemp.EditEmployeeDetails(id, e);
        }

        [HttpGet]
        [Route("/api/AMSEmployee/SelectServiceByCustomerId/{id}")]
        public List<Carservice> SelectServiceByCustomerId(int id)
        {
            return Iemp.SelectServiceByCustomerId(id);
        }

        [HttpGet]
        [Route("/api/AMSEmployee/SelectServiceByCustomerId/{id}")]
        public List<Orderbook> billGeneration(int id)
        {
            return Iemp.billGeneration(id); 
        }

        [HttpGet]
        [Route("/api/AMSEmployee/GetAllServices")]
        public List<Carservice> GetAllServices()
        {
            return Iemp.GetAllServices();  
        }

        [HttpGet]
        [Route("/api/AMSEmployee/Orderlist")]
        public List<Orderbook> OrderList()
        {
            return Iemp.OrderList();
        }

        [HttpGet]
        [Route("/api/AMSEmployee/GetAllCustomer")]   
        public List<Customer> GetAllCustomer()    
        {
            return Iemp.GetAllCustomer();
        }

        [HttpPost]
        [Route("/api/AMSEmployee/ChangePassword")]
        public bool ChangePassword(string email, Employee e)
        {
            return Iemp.ChangePassword(email,e);
        }
        [HttpPost]
        [Route("/api/AMSEmployee/ForgotPassword")]
        public bool ForgotPass(string email, Employee e)
        {
            return Iemp.ForgotPass(email, e);    
        }
        [HttpPost]
        [Route("/api/AMSEmployee/login")]
        /* public bool login(string email, string pass)
         {
             return Iemp.login(email, pass);   
         }
 */
        public bool login(Employee e)
        {
            return Iemp.login(e);
        }
    }
}
