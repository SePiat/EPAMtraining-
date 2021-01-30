using SalesReportConverter.BL.CSVHandler;
using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories;
using SalesReportConverter.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesReportConverter.BL
{
    public class TransactionManager
    {
        public ApplicationDbContext context;
        public IUnitOfWork unitOfWork;

        public TransactionManager()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(context);
        }

        public void CreateTransaction(ICollection<CSVModel> models)
        {
            lock (this)
            {
                foreach (var model in models)
                {
                    var manager = unitOfWork.Managers.FirstOrDefault(x => x.Name == model.Manager);
                    var client = unitOfWork.Buyers.FirstOrDefault(x => x.Name == model.Client);
                    var product = unitOfWork.Products.FirstOrDefault(x => x.Name == model.Product);
                    if (manager == null) unitOfWork.Managers.Add(new Model.Models.Manager() { Name = model.Manager });
                    if (client == null) unitOfWork.Buyers.Add(new Model.Models.Buyer() { Name = model.Client });
                    if (product == null) unitOfWork.Products.Add(new Model.Models.Product() { Name = model.Product, Cost=model.Cost });

                    var buying = unitOfWork.Buyings.FirstOrDefault(x => x.Manager.Name == model.Manager
                    && x.Buyer.Name == model.Client
                    && x.Product.Name == model.Product
                    && x.PurchaseDate == model.PurchaseDate);
                    if (buying == null)
                    {
                        unitOfWork.Buyings.Add(new Model.Models.Buying()
                        {
                            Manager = unitOfWork.Managers.FirstOrDefault(x => x.Name == model.Manager),
                            Buyer = unitOfWork.Buyers.FirstOrDefault(x => x.Name == model.Client),
                            Cost = model.Cost,
                            PurchaseDate = model.PurchaseDate,
                            Product = unitOfWork.Products.FirstOrDefault(x => x.Name == model.Product)
                        });
                    }

                   
                }
                unitOfWork.Save();
            }
        }
    }
}
