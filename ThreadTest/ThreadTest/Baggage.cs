using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTest
{
    public class Baggage
    {
        public string Barcode { get; set; }
        public string Destination { get; set; }

        public Baggage(string barcode, string destination)
        {
            Barcode = barcode;
            Destination = destination;
        }
    }
}
