


create table carservice 
(
   serviceid int constraint pk_serviceid primary key  identity,
   carmodel varchar(30),
   aptdate varchar(20),
   adddescription varchar(100),
   customerid int constraint fk_svccustid references customer(customerid)
 
  )

  select * from carservice  


create table billgenerate 


