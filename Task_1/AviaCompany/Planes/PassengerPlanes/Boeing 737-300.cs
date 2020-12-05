using AviaCompany.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.Planes
{
    public class Boeing_737_300:PassengerPlane 
    {
        public Boeing_737_300(string flightNumber, int yearProduction) : base(flightNumber, yearProduction) 
        {
            ModelName = "Boeing_737_300";            
            Manufacturer = "Boeing (США)";
            EngineType = "CFM International CFM56-3C-1";
            FlightRange = 4400;
            Speed = 910;
            MaxAltitude = 10200;
            FuelConsumption = 2600;
           
        }
    }
}
