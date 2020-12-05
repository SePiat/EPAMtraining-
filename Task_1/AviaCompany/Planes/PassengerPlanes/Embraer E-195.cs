using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.Planes
{
    public class Embraer_E_195 : PassengerPlane
    {
        public Embraer_E_195(string flightNumber, int yearProduction) : base(flightNumber, yearProduction)
        {
            ModelName = "Embraer_E_195";
            Manufacturer = "Embraer (Бразилия)";
            EngineType = "General Electric CF34-10E5";
            FlightRange = 3900; //км/
            Speed = 880;  //  км/ч
            MaxAltitude = 12500;// м
            FuelConsumption = 1850;//  л/ч
            еconomyClassSeats = 96;
            businessClassSeats = 11;
        }
    }
}
