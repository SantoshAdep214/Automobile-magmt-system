using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.models;


namespace DataAccessLayer
{
    public interface ICustomer
    {
        //bool login(string email, string pass);
        public bool login(Customer c);
        public bool ChangePassword(string email, Customer cust);
        public bool ForgotPass(string email, Customer cust);
        public bool EditCustomerDetails(int custid,Customer c);
        public List<Orderbook> Orderdetails(int id);
        //public bool PlacingOrder(Orderbook ord, int id, int carno);
        public bool PlacingOrder(Orderbook ord, string email, string prodname);
        public bool InsertCustomer(Customer cust);
        public List<Customer> Getcustomeridbyemail(string email);
        // public bool Services(Carservice cs, int id);
        public bool Services(Carservice cs, string email, string model);//service book


        public bool CarQuantity(int quantity, int carno);
        public string encryptpassword(string password);
        public string Decryptdata(string encryptpwd);

        //public List<Customer> GetCustIdbyEmail(string email);
        public bool Cancellation(int customerid, int orderid);
        public List<Cardetail> GetCarnobyCarmodel(string carmodel);
        public List<Cardetail> selectCarByCarno();
        public long selectCarPriceByCarmodel(string carmodel);
       // public bool CancellationOrder(int carid, string carmodel);
       //  public void logout();    

    } }

