using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.Planes
{
    public class Boeing_737_500 : PassengerPlane
    {
        public Boeing_737_500(string flightNumber, int yearProduction) : base(flightNumber, yearProduction)
        {
            ModelName = "Boeing_737_500";
            Manufacturer = "Boeing (США)";
            EngineType = "CFM International CFM56-3C-1";
            FlightRange = 4444; //км/
            Speed = 912;  //  км/ч
            MaxAltitude = 11300;// м
            FuelConsumption = 3000;//  л/ч
            еconomyClassSeats = 120;
            requiredStewardesses = 6;

        }
    }
}
