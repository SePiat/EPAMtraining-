
using AviaCompany.AviaParkBuilder;
using AviaCompany.Core;
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
            AviaCompany Belavia = new AviaCompany("Belavia"); //создание авиокомпании

            AirParkBuilder builder = new BelAviaAirParkBuilder(); //создание объекта builder (Pattern Builder)
            AirParkForBelAviaCreator creator=new AirParkForBelAviaCreator(builder); 
            creator.Construct();
            Belavia.aviaPark= builder.GetResult();     //создание авиапарка  (Pattern Builder)       
            var listOfPlanes = Belavia.aviaPark.planes;  //список самолетов в авипарке 

            Console.WriteLine();
            Console.WriteLine($"Создана авиокампания {Belavia.Name} , содержащая парк самолетов:");
            Belavia.GetPlanes(Belavia.aviaPark); //получаем в консоль список самолетов сразу в консоль

            
            int totalNumberOfPassengers = Belavia.GetCommonCapacity(Belavia.aviaPark); ; // подсчет общей вместимости пассажиров (пассажирские самолеты)??????            
            int totalCapacity = Belavia.GetCommonCargoWeight(Belavia.aviaPark); ; // подсчет общей гзузоподъемности (грузовые самолеты)
            var sortOfDistance = listOfPlanes.OrderBy(x => x.FlightRange); // сортировка по дальности полета (от меньшего к большему)           

            
            Console.WriteLine();
            Console.WriteLine($"Общая вместимость пассажиров всех пассажирских самолетов: {totalNumberOfPassengers} человек");
            Console.WriteLine();
            Console.WriteLine($"Общая грузоподъемность всех грузовых самолетов: {totalCapacity} кг");
            Console.WriteLine();
            Console.WriteLine("Отсортированный список самолетов по дальности полета");
            sortOfDistance.ToList().ForEach(x => Console.WriteLine($"{x.ModelName}  {x.FlightRange} км"));
            Console.WriteLine();

            

            var plane = Belavia.GetPlaneByFuelConsumption(Belavia.aviaPark); // поиск самолета по заданному диапазону потребления горючего
            string message = plane == null? $"В заданном диапазоне потребления горючего самолетов не найдено или введено некорректное значение":
                $"Самолет соответствующий заданному диапазону параметров потребления горючего:  {plane.ModelName} {plane.FuelConsumption} л/ч";
            Console.WriteLine(message);


            Console.WriteLine();
            Belavia.aviaPark.flight = new Flight("Минск-Варшава", 3000, "аэропорт Варшавы «Фредерик Шопен»", 0, 0, 1000);// создание рейса с заданными параметрами
            Plane planeToFly = Belavia.aviaPark.GetPlaneToFlying(Belavia.aviaPark.flight);// подбор самолета из парка с подходящими параметрами
            Belavia.aviaPark.flight.Flying(planeToFly);//отправка самолета в рейс


            Console.ReadKey();
        
        }
    }
}
