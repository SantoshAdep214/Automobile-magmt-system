using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.models
{
    public partial class Customer
    {
        public Customer()
        {
            Carservices = new HashSet<Carservice>();
            Orderbooks = new HashSet<Orderbook>();
        }

        public int Customerid { get; set; }
        public string Customername { get; set; }
        public string Customeraddress { get; set; }
        public string Customergender { get; set; }
        public long? Customermobno { get; set; }
        public string Customeremail { get; set; }
        public string Customerpass { get; set; }

        public virtual ICollection<Carservice> Carservices { get; set; }
        public virtual ICollection<Orderbook> Orderbooks { get; set; }
    }
}
