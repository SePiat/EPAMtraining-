
using AviaCompany.AviaParkBuilder;
using AviaCompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;



/*Реализовать консольное приложение, удовлетворяющее следующим требованиям:

Авиакомпания.Определить иерархию самолетов. Создать авиакомпанию. 
Посчитать общую вместимость и грузоподъемность. Провести сортировку самолетов компании по дальности полета. 
Найти самолет в компании, соответствующий заданному диапазону параметров потребления горючего.


1.	Выполнить анализ и декомпозицию предметной области.  30 %
2.	Использовать возможности ООП: наследование, полиморфизм, инкапсуляция.Отразить декомпозицию в структуре классов.  30 %
3.	Каждый класс должен иметь исчерпывающее смысл название и информативный состав.  15 %
4.	При кодировании следует придерживаться соглашения об оформлении кода codeconvention. (TODO, FAQ) 15 %
5.Файлы проекта должны быть разделены по папкам согласно доменной модели. 5 %
6.	Работа с консолью или консольное меню должно быть минимальным. 5 %*/


namespace AviaCompany
{
    class Program
    {
        
        static void Main(string[] args)
        {          


            AirParkBuilder builder = new BelAviaAirParkBuilder();
            AirParkCreator creator=new AirParkCreator(builder);
            creator.Construct();
            var AviaPark=builder.GetResult();

            int totalNumberOfPassengers = AviaPark.Where(x => x is PassengerPlane).
                Select(x => (PassengerPlane)x).Sum(x => x.еconomyClassSeats)+ 
                AviaPark.Where(x => x is PassengerPlane).
                Select(x => (PassengerPlane)x).Sum(x => x.businessClassSeats); // подсчет общей вместимости пассажиров (пассажирские самолеты)

            int totalCapacity = AviaPark.Where(x => x is CargoPlane).Select(x => (CargoPlane)x).Sum(x => x.cargoWeight); // подсчет общей гзузоподъемности (грузовые самолеты)

            var sortOfDistance = AviaPark.OrderBy(x => x.FlightRange); // сортировка по дальности полета (от меньшего к больщему)

            var plane = AviaPark.First(x => x.FuelConsumption > 2000||x.FuelConsumption<3000); // поиск самолета по заданному диапазону потребления горючего






            Console.WriteLine("Hello World!");
        }
    }
}
