using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroove.Models
{
    public class OrderRecord
    {
        public OrderRecord()
        {

        }

        public OrderRecord(OrderRecord order)
        {
            this.date = order.date;
            this.buyer =new Buyer(order.buyer);
            this.code = order.code;
            this.Items = new List<Items>(order.Items);          
            this.number = order.number;
            this.timings = new Timings (order.timings);

        }

        // Get or Set the date of the order
        public string date { get; set; }

        // Get or Set the code of the order
        public string code { get; set; }

        // Get or Set the number of the order
        public string number { get; set; }

        // Get or Set the number of the buyer
        public Buyer buyer { get; set; }

        // Get or Set the number of the items
        public List<Items> Items { get; set; }

        // Get or Set the number of the timings
        public Timings timings { get; set; }
    }
}
