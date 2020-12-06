using AviaCompany.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.Planes
{
    public abstract class Plane : IPlane,IFly
    {
        protected Plane(string flightNumber, int yearProduction)
        {
            FlightNumber = flightNumber;
            YearProduction = yearProduction;
        }

        public abstract string FlightNumber { get; set; }
        public abstract int YearProduction { get; set; }

        public abstract string ModelName { get; set; }
        
        public abstract string Manufacturer { get; set; }
        public abstract string EngineType { get; set; }
        public abstract int Speed { get; set; }
        public abstract int MaxAltitude { get; set; }
        public abstract int FuelConsumption { get; set; }
        public abstract int FlightRange { get; set; }

        public abstract void Fly();
        
    }
}
