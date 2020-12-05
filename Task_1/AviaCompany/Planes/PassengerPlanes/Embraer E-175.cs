using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.Planes
{
    public class Embraer_E_175 : PassengerPlane
    {
        public Embraer_E_175(string flightNumber, int yearProduction) : base(flightNumber, yearProduction)
        {
            ModelName = "Embraer_E_175";
            Manufacturer = "Embraer (Бразилия)";
            EngineType = "General Electric CF34-8E5";
            FlightRange = 3334; //км/
            Speed = 890;  //  км/ч
            MaxAltitude = 12500;// м
            FuelConsumption = 1800;//  л/ч
            еconomyClassSeats = 64;
            businessClassSeats = 12;
        }
    }
}
