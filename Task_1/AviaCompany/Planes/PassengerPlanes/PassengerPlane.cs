﻿using AviaCompany.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.Planes
{
    public class PassengerPlane : Plane, IStaff
    {
        public PassengerPlane(string flightNumber, int yearProduction):base(flightNumber,yearProduction) { }
        public override string ModelName { get; set; }
        public override string FlightNumber { get; set; }
        public override string Manufacturer { get; set; }
        public override string EngineType { get; set; }
        public override int FlightRange { get; set; }
        public override int Speed { get; set; }
        public override int MaxAltitude { get; set; }
        public override int FuelConsumption { get; set; }
        public override int YearProduction { get; set; }


        public int baggageWeight;
        public int businessClassSeats;
        public int еconomyClassSeats;
        public int requiredStewardesses;



        public override void Fly()
        {
            Console.WriteLine($"Пассажирский лайнер {ModelName} с боротовым номером {FlightNumber} отправился в полет с ");
        }
              

        public override int GetStaff()
        {            
            return requiredStewardesses;
        }
    }
}
