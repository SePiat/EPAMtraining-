﻿using AviaCompany.Core;
using AviaCompany.Planes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany
{
    public class Flight
    {
        public string Name { get; set; }
        public IPlane Plane { get; set; }
        public int Distance { get; set; }
        public string Destination { get; set; }
        public int NumberOfPassengrsEconomyClass { get; set; }
        public int NumberOfPassengrsBusinessClass { get; set; }
        public int WeightOfCargo { get; set; }
        public Flight(string name, int distance, string destination, int numberOfPassengrsEconomyClass, int numberOfPassengrsBusinessClass, int weightOfCargo)
        {
            Name = name;            
            Distance = distance;
            Destination = destination;
            NumberOfPassengrsEconomyClass = numberOfPassengrsEconomyClass;
            NumberOfPassengrsBusinessClass = numberOfPassengrsBusinessClass;
            WeightOfCargo = weightOfCargo;
        }        

        public void Flying(IPlane plane)
        {
            if (plane!=null)
            {
               int staff= StaffedPlane((IStaff)plane);
                plane.Fly();
                string massage = plane is PassengerPlane ? $"{NumberOfPassengrsEconomyClass} пассажирами економ класса и {NumberOfPassengrsBusinessClass} пассажирами бизнесс класса, а так же {staff} стюардессами" :
                    $"{WeightOfCargo} кг груза, а так же {staff} грузчиками";
                Console.WriteLine(massage);
                Console.WriteLine($"в пункт назначения: {Destination}");
            }           
        }

        public int StaffedPlane(IStaff plane)
        {
            if (plane!=null)
            {
                return plane.GetStaff();
            }
            return 0;
           
        }
       
    }
}
