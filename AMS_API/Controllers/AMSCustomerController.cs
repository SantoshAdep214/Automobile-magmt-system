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

    [Route("/api/AMSCustomer")]
    [EnableCors("AllowPolicy")]
    [ApiController]
    public class AMSCustomerController : ControllerBase
    {
        readonly AMSDBContext db;
        readonly ICustomer Icust;

        public AMSCustomerController(AMSDBContext db, ICustomer cust)
        {
            this.db = db;
            this.Icust = cust;
        }

        [HttpPost]
        [Route("/api/AMSCustomer/InsertCustomer")]  
        public bool InsertCustomer(Customer c)
        {
            return Icust.InsertCustomer(c);
        }

        [HttpPut]
        [Route("/api/AMSCustomer/UpdateCustomer/{custid}")]
        public bool UpdateCustomer(int custid,Customer c)
        {
            return Icust.EditCustomerDetails(custid,c);
        }

        [HttpPost]
        [Route("/api/AMSCustomer/Login")]
        /*    public bool Login(string email, string pass)
            {
                return Icust.login(email, pass);
            }*/
        public bool Login(Customer c)
        {
            return Icust.login(c);
        }


        [HttpPost]
        [Route("/api/AMSCustomer/ChangePassword")]
        public bool ChangePassword(string email, Customer c)
        {
            return Icust.ChangePassword(email, c);
        }
        [HttpPost]
        [Route("/api/AMSCustomer/ForgotPassword")]
        public bool ForgotPassword(string email, Customer c)
        {
            return Icust.ForgotPass(email, c);
        }
        [HttpPost]     
        [Route("/api/AMSCustomer/PlacingOrder/{email}/{prodname}")]      
        public bool PlacingOrder(Orderbook ord,string email,string prodname)
        {
            return Icust.PlacingOrder(ord,email,prodname);
        }
        [HttpGet]
        [Route("/api/AMSCustomer/OrderDetails/{id}")]
        public List<Orderbook> Orderdetails(int id)
        { 
            return Icust.Orderdetails(id);        
        }
        [HttpPost]
        [Route("/api/AMSCustomer/Service/{email}/{model}")] //book service......
        public bool Services([FromBody] Carservice cs,string email, string model) //service book

        {
            return Icust.Services(cs, email, model);
        }

        [HttpGet]
        [Route("/api/AMSCustomer/selectCarByCarno")]
        public List<Cardetail> selectCarByCarno()
        {
            return Icust.selectCarByCarno();
        }

        [HttpGet]
        [Route("/api/AMSCustomer/selectCarPriceByCarmodel/{carmodel}")]   
        public long selectCarPriceByCarmodel(string carmodel)   
        {
            return Icust.selectCarPriceByCarmodel(carmodel);     
        }


    }
}
