/*using DataAccessLayer.Models;*/
using System;
using DataAccessLayer;
using System.Linq;
using DataAccessLayer.models;

namespace ConsoleUI2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Customer cust = new Customer();
              Employee emp = new Employee();*/
            // EmployeeUser empuser = new EmployeeUser();     
            /*  Cardetail car = new Cardetail();*/
            //CustomerUser user = new CustomerUser();   
            //Admin ad = new Admin();          
            /*      Orderbook ord = new Orderbook(); 
                  AMSDBContext db = new AMSDBContext(); 
                  Carservice cs = new Carservice();*/


            /*
                        Console.WriteLine("*********************************************");
                        Console.WriteLine("Customers details........");
                        Console.WriteLine("*********************************************");


                        //   var key = "E546C8DF278CD5931069B522E695D4F2";

                        ////////////////////////////////////CUSTOMER INsert CUSTOMER ////////////////////////////////////////////////////
                        Console.WriteLine("this is insert customer method ");
                        Console.WriteLine("________________________________________");

                        Console.WriteLine("Enter Name");
                        cust.Customername = Console.ReadLine();
                        Console.WriteLine("Enter Address");
                        cust.Customeraddress = Console.ReadLine();
                        Console.WriteLine("Enter Gender");
                        cust.Customergender = Console.ReadLine();
                        Console.WriteLine("Enter MobNo");
                        cust.Customermobno = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter Email");
                        cust.Customeremail = Console.ReadLine();
                        Console.WriteLine("Enter password");

                        cust.Customerpass = user.encryptpassword(Console.ReadLine());
                        //var a= user.encryptpassword(Console.ReadLine());         
                        try
                        {
                            var result = user.InsertCustomer(cust);
                            if (result)
                                Console.WriteLine("New customer Registered......");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.WriteLine("----------------------------------------------");
                        ////////////////////////////////////ADMIN CAR DETAILS////////////////////////////////////////////////////
                        Console.WriteLine("this is car details method ");
                        Console.WriteLine("________________________________________");

                        Console.WriteLine("Enter car model");
                        car.Carmodel = Console.ReadLine();
                        Console.WriteLine("Enter car mileage");
                        car.Carmileage = Console.ReadLine();
                        Console.WriteLine("Enter car colour");
                        car.Carcolor = Console.ReadLine();
                        Console.WriteLine("Enter car top speed");
                        car.Cartopspeed = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter car price ");
                        car.Carprice = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter quanitity");
                        car.Carquantity = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            var result1 = ad.InsertCars(car);
                            if (result1)
                                Console.WriteLine("new car details added .....");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        ////////////////////////////////////CUSTOMER ORDER DETAILS////////////////////////////////////////////////////
                        Console.WriteLine("_________________________________________");
                        Console.WriteLine("this is orderdetails method ");
                        Console.WriteLine("________________________________________");

                        Console.WriteLine("enter customer id ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var data = user.Orderdetails(id);
                        foreach (var d in data)
                        {
                            Console.WriteLine(d.Orderdate + ":" + d.Billamount + "," + d.Productname);
                        }


                        var a = cust.Customerpass;
                        Console.WriteLine("____________________________________________");
                        ////////////////////////////////////CUSTOMER LOGIN ///////////////////////////////////////////////////
                        Console.WriteLine("this is login  method ");
                        Console.WriteLine("________________________________________");


                        Console.WriteLine("Enter email");
                        cust.Customeremail = Console.ReadLine();


                        Console.WriteLine("Enter Passwod");


                        cust.Customerpass = Console.ReadLine();


                        try
                        {

                //var result3 = user.login(cust.Customeremail, cust.Customerpass);
                var result3 = user.login(cust);
                if (result3)
                                Console.WriteLine("LoggedIn Successfully ");
                            else
                                Console.WriteLine("Try Again..");
                        }
                        catch
                        {
                            throw;
                        }




            /*            Console.WriteLine("______________________________");
                        ////////////////////////////////////CUSTOMER CHANGED PASS////////////////////////////////////////////////////
                        Console.WriteLine("changed password method ");


                        Console.WriteLine("enter email");
                        cust.Customeremail = Console.ReadLine();

                        Console.WriteLine("confirm yor old password");
                        cust.Customerpass = user.encryptpassword(Console.ReadLine());


                        try
                        {
                            var result4 = user.ChangePassword(cust.Customeremail, cust);
                            if (result4)
                                Console.WriteLine("Password Changed");
                        }
                        catch
                        {
                            throw;
                        }


                                          Console.WriteLine("______________________________");

                        ////////////////////////////////////CUSTOMER FORGOT PASS////////////////////////////////////////////////////
                        Console.WriteLine(" forgot password  method....... ");

                        Console.WriteLine("enter email");
                        cust.Customeremail = Console.ReadLine();
                        try
                        {
                            Console.WriteLine("enter  Password");
                            var x = Console.ReadLine();

                            Console.WriteLine(" Confirm your Password");
                            cust.Customerpass = Console.ReadLine();
                            if (x == cust.Customerpass)
                            {
                                Console.WriteLine("your password is matching .....");
                                var result5 = user.ForgotPass(cust.Customeremail, cust);
                                if (result5)
                                {
                                    Console.WriteLine("successfully changed your password....");
                                }
                            }
                            else
                            {
                                Console.WriteLine("password is not matching.....");

                            }

                        }
                        catch
                        {
                            Console.WriteLine("email not valid....");
                        }


                        Console.WriteLine("______________________________");

                        /////////////////////////////////////CUSTOMER EDIT DETAILS /////////////////////////////////////////////////////          
                        Console.WriteLine(" EditCustomerDetails....... ");


                        Console.WriteLine("customer id");
                        cust.Customerid = Convert.ToInt32(Console.ReadLine());




                        Console.WriteLine("customer name");
                        cust.Customername = Console.ReadLine();
                        Console.WriteLine("customer address");
                        cust.Customeraddress = Console.ReadLine();
                        Console.WriteLine("customer gender");
                        cust.Customergender = Console.ReadLine();
                        Console.WriteLine("custmoer moile no.");
                        cust.Customermobno = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("customer email");
                        cust.Customeremail = Console.ReadLine();

                        try
                        {
                            var result6 = user.EditCustomerDetails(cust.Customerid, cust);
                            if (result6)
                                Console.WriteLine("updated successfully.....");
                        }
                        catch
                        {
                            throw;
                        }


                        Console.WriteLine("*********************************************");
                        Console.WriteLine("EMPLOYEEES DETAILS.....");


                        ///////////////////////////////////EMPLOYEE INSERT METHOD//////////////////////////////////////////
                        Console.WriteLine("this is insert employee method ");
                        Console.WriteLine("________________________________________");

                        Console.WriteLine("Enter Name");
                        emp.Employeename = Console.ReadLine();
                        Console.WriteLine("Enter Address");
                        emp.Employeeaddress = Console.ReadLine();

                        Console.WriteLine("Enter MobNo");
                        emp.Employeemobno = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter Email");
                        emp.Employeeemail = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        emp.Employeepass = Console.ReadLine();

                        try
                        {
                            var result7 = empuser.InsertEmployee(emp);
                            if (result7)
                                Console.WriteLine("New Employee Registered......");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }


                    */    ///////////////////////////////////////  EMPLOYEE LOGIN  ////////////////////////////////////////////////////////////
            /*    Console.WriteLine("this is employee login  method ");
                Console.WriteLine("________________________________________");


                Console.WriteLine("Enter employeemail");
                emp.Employeeemail = Console.ReadLine();
                Console.WriteLine("Enter Passwod");
                emp.Employeepass = Console.ReadLine();
                try
                {*/
            //  var result8 = empuser.login(emp.Employeeemail, emp.Employeepass);
            //var result8 = empuser.login(emp);
            /*  if (result8)
                              Console.WriteLine("LoggedIn Successfully ");
                          else
                              Console.WriteLine("Try Again..");
                      }
                      catch
                      {
                          throw;
                      }
                   */
            ////////////////////////////////EMPLOYEE CHANGED PASSS///////////////////////////////////////////////////////////////////
            /*           Console.WriteLine("______________________________");
                       Console.WriteLine("changed password methoid ");


                       Console.WriteLine("enter email");
                       emp.Employeeemail = Console.ReadLine();
                       Console.WriteLine("enter New Password");
                       emp.Employeepass = Console.ReadLine();

                       try
                       {
                           var res1 = empuser.ChangePassword(emp.Employeeemail, emp);
                           if (res1)
                               Console.WriteLine("Password Changed");
                       }
                       catch
                       {
                           throw;
                       }

                       /////////////////////////////////////EMPLOYEEE FORGOT PASSS///////////////////////////////////////////////////////////////
                       Console.WriteLine("______________________________");
                       Console.WriteLine(" forgot password  method....... ");

                       Console.WriteLine("enter email");
                       emp.Employeeemail = Console.ReadLine();
                       try
                       {
                           Console.WriteLine("enter  Password");
                           var z = Console.ReadLine();

                           Console.WriteLine(" Confirm your Password");
                           emp.Employeepass = Console.ReadLine();
                           if (z == emp.Employeepass)
                           {
                               Console.WriteLine("your password is matching .....");
                               var res2 = empuser.ForgotPass(emp.Employeeemail, emp);
                               if (res2)
                               {
                                   Console.WriteLine("successfully changed your password....");
                               }
                           }
                           else
                           {
                               Console.WriteLine("password is not matching.....");

                           }
                       }
                       catch
                       {
                           Console.WriteLine("email not valid....");
                       }






                       ////////////////////////////////////EMPLOYEE GETALLCUSTOMER///////////////////////////////////////////////////////////////
                       Console.WriteLine("_____________________________________");
                       Console.WriteLine("GetAllCutomer method");




                       var res = empuser.GetAllCustomer();
                       foreach (var d in res)
                       {
                           Console.WriteLine("customer name " + d.Customername);
                           Console.WriteLine("customer address " + d.Customeraddress);
                           Console.WriteLine("customer gender" + d.Customergender);
                           Console.WriteLine("customer mobile " + d.Customermobno);
                           Console.WriteLine("customer email" + d.Customeremail);
                           Console.WriteLine();

                       }

                       ////////////////////////////////////////////EMPLOYEE ORDER LIST METHOD///////////////////////////////////////////////////////
                       Console.WriteLine("_____________________________________");
                       Console.WriteLine("OrderList method");
                       var custorder = empuser.OrderList();
                       foreach (var d in custorder)
                       {
                           Console.WriteLine("orderdate" + d.Orderdate);
                           Console.WriteLine("customer id " + d.Customerid);
                           Console.WriteLine("bill amount" + d.Billamount);
                           Console.WriteLine("car name " + d.Productname);

                           Console.WriteLine();

                       }


                       /////////////////////////////////////ADMIN GETALL CUSTOMER//////////////////////////////////////////////////////////////
                       Console.WriteLine("_______________________");
                       Console.WriteLine("ADMIN...");
                       Console.WriteLine("admin GETALLCUSTOMERS ");


                       var admingetallcust = ad.GetAllCustomers();
                       foreach (var d in admingetallcust)
                       {

                           Console.WriteLine("customer name " + d.Customername);
                           Console.WriteLine("customer address " + d.Customeraddress);
                           Console.WriteLine("customer gender" + d.Customergender);
                           Console.WriteLine("customer mobile " + d.Customermobno);
                           Console.WriteLine("customer email" + d.Customeremail);
                           Console.WriteLine();
                       }

           */


            ////////////////////////////////admin orderlist////////////////////////////
            ///
            /*            Console.WriteLine("_______________________");
                        Console.WriteLine("ADMIN...");
                        Console.WriteLine("admin GOrderlist");


                        var orderlist= ad.OrdereList();
                        foreach (var d in orderlist)
                        {

                            Console.WriteLine("customer name " + d.Carno);
                            Console.WriteLine("customer address " + d.Customerid);
                            Console.WriteLine("customer gender" + d.Billamount);
                            Console.WriteLine("customer mobile " + d.Productname);

                            Console.WriteLine();
                        }*/


            //////////////////////////Admin GETALLSERVICES//////////////////////
            /*  Console.WriteLine("_______________________");
              Console.WriteLine("ADMIN...");
              Console.WriteLine("admin Getallservices");


              var getallservices = ad.GetAllServices();
              foreach (var d in getallservices)
              {

                  Console.WriteLine("customer name " + d.Serviceid);
                  Console.WriteLine("customer address " + d.Carmodel);
                  Console.WriteLine("customer gender" + d.Aptdate);
                  Console.WriteLine("customer mobile " + d.Customerid);

                  Console.WriteLine();
              }
  */
            /* Console.WriteLine("admin getallcustp ");

                         ////////////////////////////////////ADMIN GETALLEMPLoyees////////////////////////////////////////////////////
                         var admingetallcust1 = ad.GetAllEmployees();
                         foreach (var d in admingetallcust1)
                         {
                             Console.WriteLine("customer name " + d.Employeename);
                             Console.WriteLine("customer address " + d.Employeeaddress);

                             Console.WriteLine("customer mobile " + d.Employeemobno);
                             Console.WriteLine("customer email" + d.Employeeemail);
                             Console.WriteLine();

                         }



                         //////////////////////////////// CUSTOMER GETCUSTOMEREMAILID////////////////////////////////////////////////////////////////  
                         Console.WriteLine("____________________________________________");
                         Console.WriteLine("Selected by email..");
                         // int id = Convert.ToInt32(Console.ReadLine());
                         string email = Console.ReadLine();
                         var data5 = user.Getcustomeridbyemail(email);
                         foreach (var d in data5)
                         {
                             Console.WriteLine(d.Customerid + ":" + d.Customername + "," + d.Customergender + "," +
                                 d.Customermobno + "," + d.Customeremail);

                             Console.WriteLine("plcing order..............");


                             Console.WriteLine("________________________________________");
                             var emailbyid = d.Customerid;

                             Console.WriteLine("successfully logged in....");

                             ord.Orderdate = DateTime.Now.ToString();
                             Console.WriteLine("Enter product name");
                             ord.Productname = Console.ReadLine();






                             //////////////////////////////////////////EMPLOYEE GET CARNO BY CARMODEL///////////////////////////////////////////////////////////////////
                             Console.WriteLine("  employee GetCarnobyCarmodel......");

                             Console.WriteLine("Selected by CarModel..");

                             // string carmodel = Console.ReadLine();
                             var data3 = empuser.GetCarnobyCarmodel(ord.Productname);
                             foreach (var c in data3)
                             {
                                 Console.WriteLine(c.Carno + ":" + c.Carmodel + "," + c.Carmileage + "," +
                                 c.Carcolor + "," + c.Cartopspeed + "," + c.Carprice + "," + c.Carquantity);



                                 var quantity = Convert.ToInt32(c.Carquantity);
                                 if (c.Carquantity == 0)
                                 {
                                     Console.WriteLine("car is not available");
                                     break;
                                 }
                                 else
                                 {
                                     Console.WriteLine("car is available... " + c.Carquantity + "car in stock");
                                     quantity--;
                                 }


                                 Console.WriteLine("quantity =" + quantity);
                                 Console.WriteLine("plcing order..............");
                                 ///////////////////////////////////////////////////////////////////////////////////////////////////////
                                 Console.WriteLine("this is Placing Ordere method ");
                                 Console.WriteLine("________________________________________");
                                 var carno = c.Carno;

                                 var quant = user.CarQuantity(quantity, carno, car);
                                 if (quant)
                                 {
                                     Console.WriteLine("car quantity updated......");
                                 }
                                 var carprice = c.Carprice;
                                 ord.Billamount = carprice;
                                 // car.Carquantity = quantity;

                                 //ord.Carno = carno;


                            */

            //////////////////////////placing order////////////////////////////////////////////////
            //Console.WriteLine("billamount " + ord.Billamount);
            /*   string email = Console.ReadLine();
               Console.WriteLine("Enter product name");
               var productname = Console.ReadLine();
               try
                                    {
                                        var res2 = user.PlacingOrder(ord, email, productname);

                                        if (res2)

                                            Console.WriteLine("New order placed......");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                            }
   */



            /*           Console.WriteLine("__________________________________");
                       ////////////////////////////////CUSTOMER  SERVICE METHOD///////////////////////////////////////////////////////////////////////
                       Console.WriteLine("SERVICE METHOD......");
                       Console.WriteLine("Selected by email..");

                       string email1 = Console.ReadLine();
                       var data1 = user.Getcustomeridbyemail(email1);
                       foreach (var d in data1)
                       {
                           Console.WriteLine(d.Customerid + ":" + d.Customername + "," + d.Customergender + "," +
                           d.Customermobno + "," + d.Customeremail);
                           var emailbyid = d.Customerid;

                           Console.WriteLine("successfully logged in....");

                           Console.WriteLine(" enter carmodel");
                           cs.Carmodel = Console.ReadLine();
                           Console.WriteLine("enter your appointment date");
                           cs.Aptdate = Console.ReadLine();
                           Console.WriteLine("enter description ");
                           cs.Adddescription = Console.ReadLine();


                           try
                           {
                               var res2 = user.Services(cs, emailbyid);
                               if (res2)

                                   Console.WriteLine("service is booked on ......" + cs.Aptdate);
                           }
                           catch (Exception ex)
                           {
                               Console.WriteLine(ex.Message);
                           }

                           /////////////////////////////////ADMIn/GETALL SERVC METHOD //////////////////////////////////////////////////////////////////////
                           Console.WriteLine("___________________________________________");
                           Console.WriteLine("admin getallservice method...");
                           Console.WriteLine();

                           var adminGetService = ad.GetAllServices();
                           foreach (var s in adminGetService)
                           {
                               Console.WriteLine("service id :" + s.Serviceid);
                               Console.WriteLine("car model :" + s.Carmodel);
                               Console.WriteLine("Appointments date : " + s.Aptdate);
                               Console.WriteLine("add description :" + s.Adddescription);
                               Console.WriteLine("customer id :" + s.Customerid);

                               Console.WriteLine();
                           }

                           /////////////////////////////////////////EMPLOYEE GET ALL SERVC /////////////////////////////////////////////////////////////
                           Console.WriteLine("___________________________________________");
                           Console.WriteLine(" employee getallService method...");
                           Console.WriteLine();

                           var employeeGetService = ad.GetAllServices();
                           foreach (var s in employeeGetService)
                           {
                               Console.WriteLine("service id :" + s.Serviceid);
                               Console.WriteLine("car model :" + s.Carmodel);
                               Console.WriteLine("Appointments date : " + s.Aptdate);
                               Console.WriteLine("add description :" + s.Adddescription);
                               Console.WriteLine("customer id :" + s.Customerid);

                               Console.WriteLine();
                           }

                           //////////////////////ADMIN SELECT SERVICE BY CUSTOMER ID ////////////////////////////////////////////////////////////////////////////////////

                           Console.WriteLine("_________________________________________");
                           Console.WriteLine("this is admin SelectBycustomerId method ");
                           Console.WriteLine("________________________________________");

                           Console.WriteLine("enter customer id ");
                           int id1 = Convert.ToInt32(Console.ReadLine());
                           var data6 = ad.SelectServiceByCustomerId(id);
                           foreach (var e in data6)
                           {
                               Console.WriteLine(e.Serviceid + "," + e.Carmodel + ":" + e.Aptdate + "," + e.Adddescription + "," + e.Customerid);
                           }
                           /////////////////////////////////////////Employee SELECT BY CUSTOMER ID//////////////////////////////////////////////////////////////
                           Console.WriteLine("_________________________________________");
                           Console.WriteLine("this is employee SelectBycustomerId method ");
                           Console.WriteLine("________________________________________");

                           Console.WriteLine("enter customer id ");
                           int id2 = Convert.ToInt32(Console.ReadLine());
                           var data2 = ad.SelectServiceByCustomerId(id1);
                           foreach (var f in data2)
                           {
                               Console.WriteLine(f.Serviceid + "," + f.Carmodel + ":" + f.Aptdate + "," + f.Adddescription + "," + f.Customerid);
                           }



                           ////////not required////////////////////////
                           *//*  Console.WriteLine("successfully logged in....");

                             Console.WriteLine(" enter ");
                             cs.Carmodel = Console.ReadLine();
                             Console.WriteLine("enter your appointment date");
                             cs.Aptdate = Console.ReadLine();
                             Console.WriteLine("enter description ");
                             cs.Adddescription = Console.ReadLine();


                             try
                             {
                                 var res2 = empuser.billAmount(cs,carNo);
                                 if (res2)

                                     Console.WriteLine("service is booked on ......" + cs.Aptdate);
                             }
                             catch (Exception ex)
                             {
                                 Console.WriteLine(ex.Message);
                             }*//*
                           ////////////////////////////////////////////////////////////////////////////////////

                           //////////////////////////////////////////BILL GENERATION METHOD ////////////////////////////////////////////////////////



                           Console.WriteLine("BILL GENERATION METHOD..........");
                              var custid = Convert.ToInt32(Console.ReadLine());

                             var billgen= empuser.billGeneration(custid);


                           /////////////////////////////CUSTOMER LOgout METHOD //////////////////////////////////
                           Console.WriteLine("LOGOUT METHOD");
                           Console.WriteLine("1) logout");


                           int b = Convert.ToInt32(Console.ReadLine());
                           switch (b)
                           {
                               case 1:
                                   Console.WriteLine("you successfully logged out.......");
                                   break;


                               default:
                                   Console.WriteLine("tu logout nhi hua,.....");
                                   break;
                           }*/
            ////////////////////////admin delete employee details///////////////////////////////////
            ///
            /*  Console.WriteLine("employee id..");
              emp.Employeeid = Convert.ToInt32(Console.ReadLine());
              try
              {
                  var res = ad.DeleteEmployeeDetails(emp.Employeeid);
                  if (res)
                      Console.WriteLine("employee has deleted");
              }
              catch
              {
                  throw;
              }*/

            ///////////////////////////Admin Delete cars//////////////////////////////
            ///


            //Console.WriteLine("****************************************");

            /* Console.WriteLine("carid");
             car.Carno = Convert.ToInt32(Console.ReadLine());
             try
             {
                 var res = ad.DeleteCars(car.Carno);
                 if (res)
                     Console.WriteLine("car has been deleted");
             }
             catch
             {
                 throw;
             }
 */

            /////////////////////////admin log in ///////////////////////////

            /*   Console.WriteLine("this is admin login  method ");
               Console.WriteLine("________________________________________");


               Console.WriteLine("Enter email");
               cust.Customeremail = Console.ReadLine();


               Console.WriteLine("Enter Passwod");


               cust.Customerpass = Console.ReadLine();


               try
               {

                   var result10 = ad.login(cust.Customeremail, cust.Customerpass);
                   if (result10)
                       Console.WriteLine("admin LoggedIn Successfully ");
                   else
                       Console.WriteLine("Try Again..");
               }
               catch
               {
                   throw;
               }


               ////////////////////////order cancellation////////////////////////////

                  Console.WriteLine("Select ur  email..");
                   // int id = Convert.ToInt32(Console.ReadLine());
                   string useremail= Console.ReadLine();
                   var data11 = user.Getcustomeridbyemail(useremail);
                   foreach (var p in data11)
                   {
                       Console.WriteLine(p.Customerid + "," + p.Customername);
                       Console.WriteLine("Enter order id");
                       var orderid= Convert.ToInt32(Console.ReadLine());
                       
                       try
                       {
                       Console.WriteLine("got in....");
                           var result1 = user.Cancellation(p.Customerid,orderid);
                       Console.WriteLine("result:"+result1);
                           if (result1)
                               Console.WriteLine("you cancelled your car successfully.....");
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine(ex.Message);
                       }
                   }

   


      */      ////////////////////////finish//////////////////////////////////////////////////////

            /*
                    }
                }} 
            */
        } }}
    


/*
 customer - 
    -register-log in-get orderedetails-placing order-edit the details
   -forgor the paassword
 employee -
    register-log in -getallcustomer- select placing orderlist-(join) - customerlist -forgot password
 admin
   -log in- carDetailsInsert (insert,update,delete)-listofemployee-customerlist-orderelist-  
 */



/*carservice 
 * 
 -customer service fill the form
'-employee and admin view 
 -admic can deleete employee details
-bill generator 
- login =  enyption , decryption
- logout             

- login otp , cancellation ----pending ......mai hai pending  
    
*/     











//*if(cust.Customeremail==Customer)*/
/* if (a == cust.Customerpass )
 {*/





/* }

 else
 {
     Console.WriteLine("your confirm password is not matching with password...");
 }*/
/* Console.WriteLine("--------------------------------");
 Console.WriteLine("Login page");
 cust.Customeremail = Console.ReadLine();
 Console.WriteLine("Enter password");
 cust.Customerpass = Console.ReadLine();

 if(cust.Customeremail==db.Customers.Where(x=>x.cust)
 Console.WriteLine("customer email:"+cust.Customeremail);*/





/*Console.WriteLine("Enter id");
  string id = Console.ReadLine();
  var data = user.SelectById(id);
  foreach (var d in data)
  {
      Console.WriteLine(d.RegId + ":" + d.Name + "," + d.Address + "," + d.Nationality + "," + d.Skills);
  }*/


