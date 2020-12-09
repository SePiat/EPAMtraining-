using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.Planes
{
    public class Boeing_737_800 : PassengerPlane
    {
        public Boeing_737_800(string flightNumber, int yearProduction) : base(flightNumber, yearProduction)
        {
            ModelName = "Boeing_737_800";
            Manufacturer = "Boeing (США)";
            EngineType = "CFM International CFM56-7B26E";
            FlightRange = 5425; //км/
            Speed = 853;  //  км/ч
            MaxAltitude = 12500;// м
            FuelConsumption = 2526;//  л/ч
            еconomyClassSeats = 189;
            baggageWeight = 1800;
        }
    }
}
