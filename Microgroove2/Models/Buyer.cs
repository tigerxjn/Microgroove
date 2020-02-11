using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroove.Models
{
    public class Buyer
    {
        public Buyer() { }

        public Buyer(Buyer buyer) {
            this.name = buyer.name;
            this.street = buyer.street;
            this.zip = buyer.zip;
        }
        // Get or set the name
        public string name { get; set; }
        // Get or set the street
        public string street { get; set; }
        // Get or set the zip
        public string zip { get; set; }
    }
}
