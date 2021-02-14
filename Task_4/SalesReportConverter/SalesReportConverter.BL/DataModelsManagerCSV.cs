using SalesReportConverter.BL.Abstractions;
using SalesReportConverter.BL.CSVHandler;
using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model_.Models;
using System;
using System.Collections.Generic;

namespace SalesReportConverter.BL
{
    public class DataModelsManagerCSV : IDataModelsManager<CSVModel>
    {
        private readonly ApplicationDbContext context;
        private readonly IUnitOfWork unitOfWork;

        public DataModelsManagerCSV()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }

        public void HandleDataModels(ICollection<CSVModel> models)
        {
            lock (this)
            {
                foreach (var model in models)
                {
                    try
                    {
                        var manager = unitOfWork.Managers.FirstOrDefault(x => x.SecondName == model.Manager);
                        var client = unitOfWork.Buyers.FirstOrDefault(x => x.FullName == model.Client);
                        var product = unitOfWork.Products.FirstOrDefault(x => x.Name == model.Product);
                        if (manager == null) unitOfWork.Managers.Add(new Manager() { SecondName = model.Manager });
                        if (client == null) unitOfWork.Buyers.Add(new Buyer() { FullName = model.Client });
                        if (product == null) unitOfWork.Products.Add(new Product() { Name = model.Product, Cost = model.Cost });
                        var buying = unitOfWork.Buyings.FirstOrDefault(x => x.Buyer.FullName == model.Client && x.PurchaseDate == model.PurchaseDate);

                        if (buying == null)
                        {
                            unitOfWork.Buyings.Add(new Buying()
                            {
                                Manager = unitOfWork.Managers.FirstOrDefault(x => x.SecondName == model.Manager),
                                Buyer = unitOfWork.Buyers.FirstOrDefault(x => x.FullName == model.Client),
                                Cost = model.Cost,
                                PurchaseDate = model.PurchaseDate,
                                Product = unitOfWork.Products.FirstOrDefault(x => x.Name == model.Product)
                            });
                        }
                        unitOfWork.Save();
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Ошибка в методе HandleDataModels, {e}");
                    }
                }
                unitOfWork.Dispose();
            }
        }
    }
}
