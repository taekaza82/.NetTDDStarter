using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Facts
{
    public class FillUpData
    {
        public int No { get; set; }
        public DateTime Date { get; set; }
        public int Odometer { get; set; }
        public double Liters { get; set; }
        public bool IsFull { get; set; }
        public double? Kml { get; set; }
    }
}
