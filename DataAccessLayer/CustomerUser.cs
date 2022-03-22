
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DataAccessLayer.models;
using System.IO;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class CustomerUser : ICustomer
    {

        //AMSDBContext db = new AMSDBContext();
        readonly AMSDBContext db;
        public CustomerUser(AMSDBContext db)
        {
            this.db = db;
        }
        // public bool login(string email, string pass)
        public bool login(Customer c)
        {
            try                                                         
            {
                var data = db.Customers.Where(x => x.Customeremail == c.Customeremail).SingleOrDefault();
                var pass1 = Decryptdata(data.Customerpass);
                //if (data.Customeremail == email && pass1 == pass)          
                // if (data.Customeremail == c.Customeremail &&  pass1 == c.Customerpass)  
                if (data.Customeremail == c.Customeremail)
                    if(pass1 == c.Customerpass)
                    return true;                   

            }
            catch
            {
                throw;
            }
            return false;
        }

        public string encryptpassword(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }

       
        public string Decryptdata(string encryptpwd)
         {
           
             string decryptpwd = "";
             UTF8Encoding encodepwd = new UTF8Encoding();
             Decoder Decode = encodepwd.GetDecoder();
             byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
             int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
             char[] decoded_char = new char[charCount];
             Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
             decryptpwd = new String(decoded_char);
           
             return decryptpwd;
        }
      



        public bool ChangePassword(string email, Customer c)
        {
            try
            {
                var oldpwd = db.Customers.Where(x => x.Customeremail == email).SingleOrDefault();

                if (oldpwd.Customeremail == c.Customeremail)
                {
                    if (oldpwd.Customerpass == c.Customerpass)

                        oldpwd.Customerpass = c.Customerpass;

                    var res = db.SaveChanges();
                    if (res > 0)
                        return true;
                }
                else
                {
                    Console.WriteLine("user is not valid......");
                }
            }
            catch
            {
                Console.WriteLine("something went wrong plz try again.....");

            }
            return false;
        }

        public bool ForgotPass(string email, Customer c)
        {
            var a = encryptpassword(c.Customerpass);  
             
            
            try          
            {
                var oldpwd = db.Customers.Where(x => x.Customeremail == email).SingleOrDefault();
               // oldpwd.Customerpass = c.Customerpass;
                oldpwd.Customerpass = a;
                var res = db.SaveChanges(); 
                if (res > 0)
                    return true;
            }
            catch
            {
                Console.WriteLine("you are not registered user......");
            }
            return false;
        }

       


        public bool InsertCustomer(Customer cust)
        {
            try
            {
                cust.Customerpass = encryptpassword(cust.Customerpass);
                db.Customers.Add(cust);
                var res = db.SaveChanges();
                if (res > 0)
                { return true; }
                else
                {
                    Console.WriteLine("not saved in database....");
                }   
            }
            catch
            {
                Console.WriteLine("error occured plx try again.....");
            }
            return false; 
        }    




        public bool EditCustomerDetails( int custid,Customer c)
        {

            try
            {    
                var oldcust = db.Customers.Where(x =>x.Customerid == custid).SingleOrDefault();
              //  oldcust.Customerid = c.Customerid;   
                oldcust.Customername = c.Customername;
                oldcust.Customeraddress = c.Customeraddress;
                oldcust.Customergender = c.Customergender;
                oldcust.Customermobno = c.Customermobno;
                oldcust.Customeremail = c.Customeremail;
                oldcust.Customerpass = encryptpassword(c.Customerpass);

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




        public List<Customer> Getcustomeridbyemail  (string email)
        {
            try
            {
                var res = db.Customers.Where(x => x.Customeremail == email).ToList();
                
                if (res.Count == 0)
                    throw new Exception("No records found");

                return res;

            }

            catch
            {
                throw;
            }
        }

        public List<Cardetail> selectCarByCarno()
        {
            var res = db.Cardetails.ToList();
            return res;
        }

        public bool PlacingOrder(Orderbook ord, string email, string prodname)
        {
            try
            {
                var result = db.Customers.Where(x => x.Customeremail == email).ToList();
                if (result.Count > 0)
                {
                    var emailbyid=0;
                    var carno = 0;
                    //string email = Console.ReadLine();
                    Console.WriteLine("email: " + email);
                    var data5 = Getcustomeridbyemail(email);
                    foreach (var d in data5)
                    {

                        emailbyid = d.Customerid;

                        //Console.WriteLine("successfully logged in....");

                        ord.Orderdate = DateTime.Now.ToString();

                        ord.Productname = prodname;
                        Console.WriteLine("prod name: " + ord.Productname);
                        var data3 = GetCarnobyCarmodel(ord.Productname);
                        foreach (var c in data3)
                        {

                            carno = c.Carno;

                            var quantity = Convert.ToInt32(c.Carquantity);
                            if (c.Carquantity == 0)
                            {

                                break;
                            }
                            else
                            {
                                Console.WriteLine("car is available... " + c.Carquantity + "car in stock");
                                quantity--;
                            }

                            Console.WriteLine("quantity =" + quantity);


                            var quant = CarQuantity(quantity, carno);
                            if (quant)
                            {
                                Console.WriteLine("car quantity updated......");
                            }
                            var carprice = c.Carprice;
                            ord.Billamount = carprice;

                            Console.WriteLine("billamount " + ord.Billamount);

                            var res = db.Customers.Where(x => x.Customerid == emailbyid).SingleOrDefault();
                            var res2 = db.Cardetails.Where(x => x.Carno == carno).SingleOrDefault();
                            // var res3 = db.Cardetails.Where(x => x.Carquantity>quantity).SingleOrDefault();

                            if (res.Customerid == emailbyid)
                            {
                                Console.WriteLine("you can book yor favourite car");



                                ord.Customerid = res.Customerid;
                                Console.WriteLine(ord.Customerid);
                                ord.Carno = res2.Carno;
                                Console.WriteLine(ord.Carno);
                                Console.WriteLine("ordid:" + ord.Orderid);
                                Console.WriteLine("orddate:" + ord.Orderdate);
                                Console.WriteLine("customerid:" + ord.Customerid);
                                Console.WriteLine("ordbill:" + ord.Billamount);
                                Console.WriteLine("ordprod:" + ord.Productname);
                                db.Orderbooks.Add(ord);



                                var res1 = db.SaveChanges();
                                if (res1 > 0)
                                {
                                    return true;
                                }
                                else
                                {
                                    Console.WriteLine("order wasnt placed......... ");
                                }
                            }
                        }
                    }
                }

            }
            catch
            {
                throw;
            }
            return false;
        }


        public List<Cardetail> GetCarnobyCarmodel(string carmodel)
        {
            try
            {
                var res = db.Cardetails.Where(x => x.Carmodel == carmodel).ToList();

                if (res.Count == 0)
                    throw new Exception("No records found");

                return res;
               
            }

            catch
            {
                throw;
            }
        }

        /*  public bool PlacingOrder(Orderbook ord, int id, int carno)
          {

              try
              {
                  var res = db.Customers.Where(x => x.Customerid == id).SingleOrDefault();
                  var res2 = db.Cardetails.Where(x => x.Carno ==carno).SingleOrDefault();
                 // var res3 = db.Cardetails.Where(x => x.Carquantity>quantity).SingleOrDefault();

                  if (res.Customerid == id)
                  { 
                      Console.WriteLine("you can book yor favourite car");
                      ord.Customerid = res.Customerid;

                          ord.Carno = res2.Carno;

                      db.Orderbooks.Add(ord);
                      var res1 = db.SaveChanges();
                      if (res1 > 0)
                      {
                          return true;
                      }
                      else
                      {
                          Console.WriteLine("no records found......... ");
                      }




                  }
              }
              catch
              {
                  throw;
              }
              return false;
          }
        */
        public bool CarQuantity(int quantity,int carno)   //Cardetail cd
        {

            try
            {
                var oldquantity = db.Cardetails.Where(x => x.Carno==carno ).SingleOrDefault();
                Console.WriteLine("car quantity :"+oldquantity.Carquantity);
                Console.WriteLine();
                Console.WriteLine("car new quantity :" + quantity);

                oldquantity.Carquantity = quantity;
         
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






        public List<Orderbook> Orderdetails(int id)  //this customerid,how many plced order
        {
            try
            {
                var res = db.Orderbooks.Where(x => x.Customerid == id).ToList();
                if (res.Count == 0)
                    throw new Exception("No records found");

                return res;

            }
            catch
            {
                throw;


            }


            //throw new NotImplementedException();
        }



        /* public bool Services(Carservice cs, int id)  //service book
         {
             try
             {
                 var res = db.Customers.Where(x => x.Customerid == id).SingleOrDefault();
                 if (res.Customerid == id)
                 {
                     Console.WriteLine("your bmw is ready for service ");
                     cs.Customerid = res.Customerid;
                     db.Carservices.Add(cs);

                     var res1 = db.SaveChanges();
                     if (res1 > 0)
                     {
                         return true;
                     }
                     else
                     {
                         Console.WriteLine(" no records found......... ");
                     }

                 }
             }    
             catch
             {
                 throw;
             }
             return false;     
         }
        */

        public bool Services(Carservice cs, string email,string model) //service book
        {
            try
            {
                var res2 = db.Customers.Where(x => x.Customeremail == email).ToList();
                /*if (res.Count == 0)
                    throw new Exception("No records found");

                return res;*/
                
                if (res2.Count > 0)
                {
                    var data1 = Getcustomeridbyemail(email);

                    foreach (var d in data1)
                    {
                        var emailbyid = d.Customerid;
                        // cs.Carmodel = carmodel;
                        cs.Carmodel = model;
                        /* cs.Aptdate = aptdate;
                         cs.Adddescription = addesc;*/


                        var res = db.Customers.Where(x => x.Customerid == emailbyid).SingleOrDefault();
                        if (res.Customerid == emailbyid)
                        {
                            cs.Customerid = res.Customerid;
                            db.Carservices.Add(cs);

                            var res1 = db.SaveChanges();
                            if (res1 > 0)
                            {
                                return true;
                            }
                            //else
                            //{

                            // Console.WriteLine(" no records found......... ");
                            //}

                        }
                    }
                }
               
            }
            catch
            {
                throw;
            }
            
                return false; 
        }

        /* public List<Customer> GetCustIdbyEmail(string email) //fetching order id and customer id by email...
         {
             try
             {
                 var res = db.Customers.Where(x => x.Customeremail == email).ToList();

                 if (res.Count == 0)
                     throw new Exception("No records found");

                 return res;

             }

             catch
             {
                 throw;
             }
         }*/

        public bool Cancellation(int customerid, int orderid)
        {
            try
            {
                var del = db.Orderbooks.Where(x => x.Customerid == customerid && x.Orderid == orderid).SingleOrDefault();
                Console.WriteLine("customer id:" + del.Customerid);
                Console.WriteLine("order id:" + del.Orderid);

                if (del.Customerid == customerid && del.Orderid == orderid)
                {
                    db.Orderbooks.Remove(del);
                    Console.WriteLine("del:" + del);
                    var res = db.SaveChanges();
                    if (res > 0)
                        return true;
                }
                else
                {
                    Console.WriteLine("not matching.....");
                }
            }
            catch
            {
                throw;
            }
            return false;
        }


        public long  selectCarPriceByCarmodel (string carmodel)
        {
            var res = db.Cardetails.Where(x => x.Carmodel == carmodel).SingleOrDefault();
             
            return (long)res.Carprice;  
        }



        /* public bool CancellationOrder(int customer, string model)
         {
             Console.WriteLine("car no :"+carid);

                 try
                 {

                     var del = db.Orderbooks.Where(x => x.Carno == carid && x.).SingleOrDefault;
                 foreach (var d in del)
                 {
                     db.Orderbooks.Remove(d);
                 }


     var res = db.SaveChanges();
                     if (res > 0)
                         return true;
                 }
                 catch
 {
     throw;
 }
 return false;
         }*/

    }
}








/**/