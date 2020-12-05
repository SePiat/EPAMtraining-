
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
            AviaCompany Belavia = new AviaCompany("Belavia");
            AirParkBuilder builder = new BelAviaAirParkBuilder();
            AirParkCreator creator=new AirParkCreator(builder);
            creator.Construct();
            AviaPark aviaPark =builder.GetResult();
            var listOfPlanes = aviaPark.planes;



            Console.WriteLine($"Создана авиокампания {Belavia.Name} , содержащая парк самолетов:");
            listOfPlanes.ToList().ForEach(x => Console.WriteLine($"{x.ModelName}, бортовой номер:{x.FlightNumber}"));

            int totalNumberOfPassengers = listOfPlanes.Where(x => x is PassengerPlane).
                Select(x => (PassengerPlane)x).Sum(x => x.еconomyClassSeats)+
                listOfPlanes.Where(x => x is PassengerPlane).
                Select(x => (PassengerPlane)x).Sum(x => x.businessClassSeats); // подсчет общей вместимости пассажиров (пассажирские самолеты)

            int totalCapacity = listOfPlanes.Where(x => x is CargoPlane).Select(x => (CargoPlane)x).Sum(x => x.cargoWeight); // подсчет общей гзузоподъемности (грузовые самолеты)

            var sortOfDistance = listOfPlanes.OrderBy(x => x.FlightRange); // сортировка по дальности полета (от меньшего к больщему)

            

            
            Console.WriteLine();
            Console.WriteLine($"Общая вместимость пассажиров всех пассажирских самолетов: {totalNumberOfPassengers} человек");
            Console.WriteLine();
            Console.WriteLine($"Общая грузоподъемность всех грузовых самолетов: {totalCapacity} кг");
            Console.WriteLine();
            Console.WriteLine("Отсортированный список самолетов по дальности полета");
            sortOfDistance.ToList().ForEach(x => Console.WriteLine($"{x.ModelName}  {x.FlightRange} км"));
            Console.WriteLine();

            Console.WriteLine("Для поиска самолета по заданному диапазону параметров потребления горючего введите максимальное значение диапазона");
            int maxValueRange = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите минимальное значение диапазона");
            int minValueRange = Convert.ToInt32(Console.ReadLine()); 

            var plane = listOfPlanes.FirstOrDefault(x => x.FuelConsumption > minValueRange && x.FuelConsumption < maxValueRange); // поиск самолета по заданному диапазону потребления горючего
           string message= plane == null? $"В заданном диапазоне потребления горючего самолетов не найдено":$"Самолет соответствующий заданному диапазону параметров потребления горючего:  {plane.ModelName} {plane.FuelConsumption} л/ч";
            Console.WriteLine(message);
            
            
            Console.ReadKey();
        
        }
    }
}
