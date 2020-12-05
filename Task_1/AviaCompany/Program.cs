﻿using AviaCompany.AviaParckBuilder;
using AviaCompany.Planes;
using System;
using System.Collections.Generic;



/*Реализовать консольное приложение, удовлетворяющее следующим требованиям:

Авиакомпания.Определить иерархию самолетов. Создать авиакомпанию. Посчитать общую вместимость и грузоподъемность. Провести сортировку самолетов компании по дальности полета. Найти самолет в компании, соответствующий заданному диапазону параметров потребления горючего.


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
        public class apple
        {
            public string brre = "abbp";
            public int part = 3;

        }
        static void Main(string[] args)
        {          


            AirParkBuilder builder = new BelAviaAirParkBuilder();
            AirParkCreator creator=new AirParkCreator(builder);
            creator.Construct();
            var park=builder.GetResult();


            Console.WriteLine("Hello World!");
        }
    }
}
