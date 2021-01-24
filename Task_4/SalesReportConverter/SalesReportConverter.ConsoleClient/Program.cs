using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model.Models;
using System;

namespace SalesReportConverter.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

           
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                IUnitOfWork unit = new UnitOfWork(db);

                

                Buyer buyer = new Buyer() { Name="UnitOfWorkIsWorks", SecondName= "UnitOfWorkIsWorks" };
                unit.Buyers.Add(buyer);
                unit.Save();                
            }
           
            Console.WriteLine("Hello World!");
        }
            
    }
}
