using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.models
{
    public partial class Cardetail
    {
        public Cardetail()
        {
            Orderbooks = new HashSet<Orderbook>();
        }

        public int Carno { get; set; }
        public string Carmodel { get; set; }
        public string Carmileage { get; set; }
        public string Carcolor { get; set; }
        public long? Cartopspeed { get; set; }
        public long? Carprice { get; set; }
        public int? Carquantity { get; set; }

        public virtual ICollection<Orderbook> Orderbooks { get; set; }
    }
}
