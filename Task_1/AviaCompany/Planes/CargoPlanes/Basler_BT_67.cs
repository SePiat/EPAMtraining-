using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.Planes
{
    class Basler_BT_67:CargoPlane
    {
        public Basler_BT_67(string flightNumber, int yearProduction) : base(flightNumber, yearProduction)
        {
            ModelName = "Basler_BT_67";
            Manufacturer = "Basler Turbo Conversions (США)";
            EngineType = "Pratt & Whitney Canada PT6";
            FlightRange = 1759; //км/
            Speed = 380;  //  км/ч
            MaxAltitude = 7600;// м
            FuelConsumption = 1850;//  л/ч
            cargoWeight = 5897;
            requiredMovers = 6;
        }
    }
}
