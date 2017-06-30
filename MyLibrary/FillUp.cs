using System;

namespace MyLibrary
{
    public class FillUp
    {
        public FillUp()
        {
           
        }

        public FillUp(int odometer, double litters, bool isFull = true)
        {
            Odometer = odometer;
            Litters = litters;
            IsFull = isFull;
        }

        public int Odometer { get; set; }
        public double Litters { get; set; }
        public bool IsFull { get; set; }
        public FillUp NextFillUp { get; set; }

        public double? Kml
        {
            get
            {
                if (NextFillUp != null)
                    return Math.Round(((NextFillUp.Odometer - Odometer) / NextFillUp.Litters), 2);
                else
                    return null;
            }
        }           
    }
}