using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.models
{
    public partial class Orderbook
    {
        public int Orderid { get; set; }
        public string Orderdate { get; set; }
        public int? Customerid { get; set; }
        public long? Billamount { get; set; }
        public string Productname { get; set; }
        public int? Carno { get; set; }

        public virtual Cardetail CarnoNavigation { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
