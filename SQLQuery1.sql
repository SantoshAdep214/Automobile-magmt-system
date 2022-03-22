create table Admin
(
   adminid int constraint pk_adminid  primary key identity,
   adminname varchar(30),
   adminpass varchar(30)
)

select * from Admin
insert into Admin values('admin','4214'); 


