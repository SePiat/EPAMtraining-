using AviaCompany.Core;
using AviaCompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviaCompany
{
    public class AviaPark
    {
        public string NameCompanyOwner { get; set; }
        public List<IPlane> planes=new List<IPlane>();
        public Flight flight;

        public AviaPark(string nameCompanyOwner)
        {
            NameCompanyOwner = nameCompanyOwner;
        }

        public Plane GetPlaneToFlying(Flight flight)
        {
            if (planes!=null)
            {
                Plane plane;

                var planeEnoughDistance = planes.Where(x => x.FlightRange > flight.Distance);
                if (planeEnoughDistance == null) 
                {
                    Console.WriteLine("Данная авиокампания не имеет самолетов для полетов на такие дистанции");
                    return null;

                }
                if (flight.NumberOfPassengrsBusinessClass>0||flight.NumberOfPassengrsEconomyClass>0)
                {
                    plane = planeEnoughDistance.
                        Where(x => x is PassengerPlane).
                        Select(x => (PassengerPlane)x).
                        Where(x=>x.businessClassSeats>flight.NumberOfPassengrsBusinessClass&&x.еconomyClassSeats>flight.NumberOfPassengrsEconomyClass).FirstOrDefault();
                    if (plane==null) Console.WriteLine("В данной авиакомпании не имеется самолета для перевозки такого колличества пассажиров");
                    return plane;
                }
                if (flight.WeightOfCargo>0)
                {
                    plane = planeEnoughDistance.
                        Where(x => x is CargoPlane).
                        Select(x => (CargoPlane)x).
                        Where(x => x.cargoWeight > flight.WeightOfCargo).FirstOrDefault();
                    if (plane == null) Console.WriteLine("В данной авиакомпании не имеется самолета для перевозки такого колличества груза");
                    return plane;
                }
                if (flight.NumberOfPassengrsBusinessClass > 0 || flight.NumberOfPassengrsEconomyClass > 0 && flight.WeightOfCargo > 0)
                {
                    Console.WriteLine("Данная авиокампания не занимается предоставленем услуг по одновеменному перевозу грузов и пассажиров");
                    return null;
                }
                else
                {
                    Console.WriteLine("Не имеется достаточной информации для подбора самолета или ни один самолет не подходит под заданные условия");
                    return null;
                } 
            }
            else
            {
                Console.WriteLine("В авифпарке данной компании отсутствуют самолеты");
                return null;
            }
        }
        
    }
}
