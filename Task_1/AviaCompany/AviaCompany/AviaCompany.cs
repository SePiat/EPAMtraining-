using AviaCompany.Core;
using AviaCompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviaCompany
{
    public class AviaCompany
    {
        public AviaCompany(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public AviaPark aviaPark;

        public void GetPlanes(AviaPark aviaPark)
        {
            if (aviaPark!=null)
            {
                aviaPark.planes.ForEach(x => Console.WriteLine($"{x.ModelName}, бортовой номер:{x.FlightNumber}"));
            }
            
        }

        public int GetCommonCapacity(AviaPark aviaPark)
        {
            if (aviaPark!=null)
            {
                /*int totalNumberOfPassengers = aviaPark.planes.Where(x => x is PassengerPlane).
               Select(x => (PassengerPlane)x).Sum(x => x.еconomyClassSeats) +
               aviaPark.planes.Where(x => x is PassengerPlane).
               Select(x => (PassengerPlane)x).Sum(x => x.businessClassSeats);*/ // подсчет общей вместимости пассажиров (пассажирские самолеты)??????

                int totalNumberOfPassengers = aviaPark.planes.Where(x => x is PassengerPlane).
               Select(x => (PassengerPlane)x).Sum(x => x.businessClassSeats + x.еconomyClassSeats);
                return totalNumberOfPassengers;
            }
            else return 0;
            
        }

        internal int GetCommonCargoWeight(AviaPark aviaPark)
        {
            if (aviaPark != null)
            {                
                return aviaPark.planes.Where(x => x is CargoPlane).Select(x => (CargoPlane)x).Sum(x => x.cargoWeight)+ aviaPark.planes.Where(x => x is PassengerPlane).
               Select(x => (PassengerPlane)x).Sum(x => x.baggageWeight);
            }
            else return 0;
        }

        internal IPlane GetPlaneByFuelConsumption(AviaPark aviaPark)
        {
            if (aviaPark != null)
            {
                Console.WriteLine("Для поиска самолета по заданному диапазону параметров потребления горючего введите максимальное значение диапазона");
                int maxValueRange;
                int minValueRange;
                bool isMaxValueRangeSuccess = int.TryParse(Console.ReadLine(),out maxValueRange);               
                
                Console.WriteLine("Введите минимальное значение диапазона");
                bool isMinValueRangeSuccess= int.TryParse(Console.ReadLine(), out minValueRange);

                if (isMaxValueRangeSuccess && isMinValueRangeSuccess)
                {
                    return aviaPark.planes.FirstOrDefault(x => x.FuelConsumption >= minValueRange && x.FuelConsumption < maxValueRange);
                }
                else Console.WriteLine("Некорректный ввод диапазона потребления топлива");
                return null;
            }
           else return null;
        }
    }
}
