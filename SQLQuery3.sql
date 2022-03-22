

  alter table cardetails
  add constraint uk_carmodel unique(carmodel) 

 
  alter table orderbook
  add  carno int constraint fk_carno references cardetails(carno)


  select * from orderbook


