using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.models;
using System.Linq;   


namespace DataAccessLayer
{
    public class EmployeeUser : IEmployee
    {

        //AMSDBContext db = new AMSDBContext();
        readonly AMSDBContext db;
        public EmployeeUser(AMSDBContext db)
        {
            this.db = db;
        }



        // public bool login(string email, string pass)
        public bool login(Employee e)
        {
            try
            {
                var data = db.Employees.Where(x => x.Employeeemail == e.Employeeemail).SingleOrDefault();
                var pass1 = Decryptdata(data.Employeepass);
                if (data.Employeeemail == e.Employeeemail && pass1 == e.Employeepass)
                    return true;      
            }
            catch
            {
                Console.WriteLine("employee is not valid........");
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


        public bool ForgotPass(string email, Employee e)
        {
            try
            {
                var oldpwd = db.Employees.Where(x => x.Employeeemail == email).SingleOrDefault();
                oldpwd.Employeepass = e.Employeepass;
                var res = db.SaveChanges();
                if (res > 0)
                    return true;
            }
            catch
            {
                Console.WriteLine("you are not registered employee......");
            }
            return false;
        }


        public bool ChangePassword(string email, Employee e)
        {
            try
            {
                var oldpwd = db.Employees.Where(x => x.Employeeemail == email).SingleOrDefault();
                oldpwd.Employeepass = e.Employeepass;

                if (oldpwd.Employeeemail == e.Employeeemail)
                {
                    if (oldpwd.Employeepass == e.Employeepass)
                    {
                        oldpwd.Employeepass = e.Employeepass;

                        var res = db.SaveChanges();
                        if (res > 0)
                            return true;
                    }
                    else
                    {
                        Console.WriteLine("pass is not maatching....");
                    }
                }
                else
                {
                    Console.WriteLine("user is not valid......");
                }
               
            }
            catch
            {
                Console.WriteLine("you are not employee user......");

            }
            return false;
        }

        /*  public List<Customer> SelectById(int id)
          {

          }*/



        public bool InsertEmployee(Employee emp)
        {
            try
            {
                emp.Employeepass = encryptpassword(emp.Employeepass);
                db.Employees.Add(emp);
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


        public List<Customer> GetAllCustomer()
        {
            var res = db.Customers.ToList();
            //Console.WriteLine("res: "+res);
            return res;
        }

        public List<Orderbook> OrderList()
        {
            var res = db.Orderbooks.ToList();
            return res;
        }

        public bool EditEmployeeDetails(int id, Employee e)
        {
            try
            {
                var oldcust = db.Employees.Where(x => x.Employeeid == id).SingleOrDefault();

                oldcust.Employeename = e.Employeename;
                oldcust.Employeeaddress = e.Employeeaddress;
                oldcust.Employeemobno = e.Employeemobno;
                oldcust.Employeeemail = e.Employeeemail;
                oldcust.Employeepass = e.Employeepass;

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
        public List<Carservice> GetAllServices()
        {
            var res = db.Carservices.ToList();
            return res;
        }


      /*  public List<Cardetail>GetCarnobyCarmodel(string carmodel)
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
        }    */


       public List<Orderbook> billGeneration(int id  )
        {

            List<Orderbook> retList = new List<Orderbook>();

            try
            {
                var query = (from o in db.Orderbooks
                             join c in db.Customers
                             on o.Customerid equals c.Customerid
                             where c.Customerid == id
                             select new
                             {
                                 o.Orderid,
                                 o.Orderdate,
                                 c.Customerid,
                                 c.Customername,
                                 c.Customermobno,
                                 c.Customeraddress,
                                 c.Customeremail,
                                 o.Carno,
                                 o.Billamount,
                                 o.Productname,
                                 o.CarnoNavigation,
                                 o.Customer
                             });

               
                foreach (var per in query)
                {
                    Console.WriteLine("count");
                    Console.WriteLine();
                    Console.WriteLine("customer id :"+per.Customerid);
                    Console.WriteLine("customer name :" + per.Customername);
                    Console.WriteLine("customer address :" + per.Customeraddress);
                    Console.WriteLine("customer mobile no :" + per.Customermobno);
                    Console.WriteLine("customer email :"+per.Customeremail);
                    Console.WriteLine("order id :"+per.Orderid);
                    Console.WriteLine("orderdate:"+per.Orderdate);
                    Console.WriteLine("order bill amount :"+per.Billamount);
                    Console.WriteLine("car no:"+per.Carno);
                    Console.WriteLine("productname :"+per.Productname); 
                   /* Console.WriteLine("carnonavigation :" + per.CarnoNavigation);
                    Console.WriteLine("customer :" + per.Customer);*/

                    Console.WriteLine();

                    //retList.Add(per);
                }


                return retList;
                /* var query = (from o in db.Orderbooks
                                join c in db.Customers on o.Customerid equals c.Customerid
                              where c.Customerid == id
                              select new
                                {
                                    o.Orderid,
                                    o.Orderdate,
                                    c.Customerid,
                                    c.Customername,
                                    c.Customermobno,
                                    c.Customeraddress,
                                    c.Customeremail,
                                    o.Carno,
                                    o.Billamount

                                }).ToList();
  */


            }
            catch
            {
                throw;
            }
           

        }
    }
}
