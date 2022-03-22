using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.models
{
    public partial class Carservice
    {
        public int Serviceid { get; set; }
        public string Carmodel { get; set; }
        public string Aptdate { get; set; }
        public string Adddescription { get; set; }
        public int? Customerid { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
