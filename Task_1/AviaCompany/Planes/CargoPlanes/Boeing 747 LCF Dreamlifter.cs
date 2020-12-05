using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.Planes
{
    public class Boeing_747_LCF_Dreamlifter:CargoPlane
    {
        public Boeing_747_LCF_Dreamlifter(string flightNumber, int yearProduction) : base(flightNumber, yearProduction)
        {
            ModelName = "Boeing_747_LCF_Dreamlifter";
            Manufacturer = "Boeing (США)";
            EngineType = "Pratt & Whitney PW4000";
            FlightRange = 7800; //км/
            Speed = 878;  //  км/ч
            MaxAltitude = 13000;// м
            FuelConsumption = 2800;//  л/ч

        }
    }
}
