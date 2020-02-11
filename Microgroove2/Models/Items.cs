using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroove.Models
{
    public class Items
    {
        public Items() { }
        public Items(Items items) {
            this.itemList = new List<Items>(items.itemList);
        }

        public string sku { get; set; }
        public int qty { get; set; }

        public List<Items> itemList { get; set; }

    }
}
