using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.Core
{
    public interface IPlane
    {

        public string ModelName { get; set; }
        public string FlightNumber { get; set; }
        public string Manufacturer { get; set; }
        public string EngineType { get; set; }
        public int Speed { get; set; }
        public int MaxAltitude { get; set; }
        public int FuelConsumption { get; set; }       
        

    }
}
