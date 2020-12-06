﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.Planes
{
    public class PassengerPlane : Plane
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

        public int businessClassSeats;
        public int еconomyClassSeats;

        public override void Fly()
        {
            Console.WriteLine($"Пассажирский лайнер {ModelName} с боротовым номером {FlightNumber} отправился в полет с " +
                $"{businessClassSeats} пассажирами економкласса и {businessClassSeats} пассажирами бизнесс класса");
        }
    }
}