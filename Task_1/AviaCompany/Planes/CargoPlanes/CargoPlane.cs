using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.Planes
{
    public class CargoPlane : Plane
    {
        public CargoPlane(string flightNumber, int yearProduction) : base(flightNumber, yearProduction) { }
        public override string ModelName { get;  set;  }
        public override string FlightNumber { get; set; }
        public override string Manufacturer { get; set; }
        public override string EngineType { get; set; }
        public override int FlightRange { get; set; }
        public override int Speed { get; set; }
        public override int MaxAltitude { get; set; }
        public override int FuelConsumption { get; set; }
        public override int YearProduction { get; set; }
        public int cargoWeight { get; set; }
        public override void Fly()
        {
            Console.WriteLine($"Грузовой самолет {ModelName} с боротовым номером {FlightNumber} отправился в полет с ");
        }

    }
}
