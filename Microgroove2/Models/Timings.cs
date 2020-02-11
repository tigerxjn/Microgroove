using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroove.Models
{
    public class Timings
    {
        public Timings() { }

        public Timings(Timings timings) {
            this.start = timings.start;
            this.pause = timings.pause;
            this.gap = timings.gap;
            this.stop = timings.stop;
            this.offset = timings.offset;
        }

        // Get or Set the start
        public int start { get; set; }

        // Get or Set the start
        public int stop { get; set; }

        // Get or Set the start
        public int gap { get; set; }

        // Get or Set the start
        public int offset { get; set; }

        // Get or Set the start
        public int pause { get; set; }

    }
}
