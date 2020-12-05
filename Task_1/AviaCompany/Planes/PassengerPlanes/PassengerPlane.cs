using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.Planes
{
    public class PassengerPlane : Plane
    {
        public override string ModelName { get; set; }
        public override string FlightNumber { get; set; }
        public override string Manufacturer { get; set; }
        public override string EngineType { get; set; }
        public override int Speed { get; set; }
        public override int MaxAltitude { get; set; }
        public override int FuelConsumption { get; set; }

        public int businessClassSeats;
        public int еconomyClassSeats;
    }
}
