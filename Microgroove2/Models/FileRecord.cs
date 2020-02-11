using MicroGroove.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroove
{
    public class FileRecord
    {
        public FileRecord() { }
        // Get or Set the date of the order
        public string date { get; set; }

        //Get or Set the type of the order
        public string type { get; set; }

        public List<OrderRecord> orders { get; set; }
        public Ender Ender { get; set; }
    }
}
