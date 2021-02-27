using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model_.Models;
using SalesWebService.Models.Buyings;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SalesWebService.Controllers
{
    public class BuyingsController : Controller
    {
        static int? globPage;
        [Authorize]
        public ActionResult Index(int? page)
        {
            globPage = page;
            return View();
        }

        public ActionResult ListOfBuyings()
        {
            IList<BuyingsViewModel> models = new List<BuyingsViewModel>();
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                var buyings = unitOfWork.Buyings.ToList();
                foreach (var buying in buyings)
                {                   
                    models.Add(new BuyingsViewModel { ManagerName = buying.Manager.Name,
                        ManagerSecondName=buying.Manager.SecondName,
                        Buyer=buying.Buyer.FullName, 
                        Product=buying.Product.Name, 
                        PurchaseDate=buying.PurchaseDate, 
                        Cost=buying.Cost, Buying=buying});
                }
            }
            int pageNumber = globPage ?? 1;
            var model = models.ToPagedList(pageNumber, 5);
            return PartialView("BuyingsContainer", model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Buying buying;
            BuyingsViewModel model = new BuyingsViewModel();

            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                buying = unitOfWork.Buyings.FirstOrDefault(x => x.Id == id);
                if (buying == null)
                {
                    return NotFound();
                }
                model.Buying = buying;
                model.ManagerName = buying.Manager.Name;
                model.ManagerSecondName = buying.Manager.SecondName;
                model.Buyer = buying.Buyer.FullName;
                model.Product = buying.Product.Name;
                model.PurchaseDate = buying.PurchaseDate;
                model.Cost = buying.Cost;
            } 
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Edit(BuyingsViewModel model)
        {
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                Buying buying = unitOfWork.Buyings.FirstOrDefault(x => x.Id == model.Buying.Id);
                if (buying == null)
                {
                    return NotFound();
                }
                Manager manager = unitOfWork.Managers.FirstOrDefault(x => x.Name == model.ManagerName && x.SecondName==model.ManagerSecondName);
                Buyer buyer = unitOfWork.Buyers.FirstOrDefault(x => x.FullName == model.Buyer);
                Product product = unitOfWork.Products.FirstOrDefault(x => x.Name == model.Product);
                if (manager == null)
                {
                    buying.Manager = new Manager() { Name = model.ManagerName, SecondName = model.ManagerSecondName };
                }
                else buying.Manager = manager;
                if (buyer == null)
                {
                    buying.Buyer = new Buyer() { FullName = model.Buyer };
                }
                else buying.Buyer = buyer;
                if (product == null)
                {
                    buying.Product = new Product() { Name = model.Product, Cost = model.Cost };
                }
                else buying.Product = product;
               
                buying.PurchaseDate = model.PurchaseDate;
                buying.Cost = model.Cost;
                try
                {
                    await unitOfWork.SaveAsync();
                }
                catch (Exception e)
                {
                    Log.Error($"ManagersController.Edit: Ошибка при попытке сохранения изменений покупки: {DateTime.Now}" +
                           $"{Environment.NewLine}{e}{Environment.NewLine}");
                    throw new Exception($"Ошибка при попытке сохранения изменений покупки: {e}");
                }
            }
            return View("Index");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int Id)
        {
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                Buying buying = unitOfWork.Buyings.FirstOrDefault(x => x.Id ==Id);
                if (buying == null)
                {
                    return NotFound();
                }
                try
                {
                    context.Buyings.Remove(buying);
                    await unitOfWork.SaveAsync();
                }
                catch (Exception e)
                {
                    Log.Error($"BuyingsController.Delete :Ошибка при удалении покупки: {DateTime.Now}" +
                           $"{Environment.NewLine}{e}{Environment.NewLine}");
                    throw new Exception($"Ошибка при удалении покупки: {e}");
                }
            }
            return View("Index");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> Create(BuyingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Buying buying = new Buying();
                using (var context = new ApplicationDbContext())
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    Buying existBuying = unitOfWork.Buyings.FirstOrDefault(x => x.Buyer.FullName==model.Buyer&&x.Product.Name==model.Product&&x.PurchaseDate==model.PurchaseDate);
                    if (existBuying == null)
                    {

                        Manager manager = unitOfWork.Managers.FirstOrDefault(x => x.Name == model.ManagerName && x.SecondName == model.ManagerSecondName);
                        Buyer buyer = unitOfWork.Buyers.FirstOrDefault(x => x.FullName == model.Buyer);
                        Product product = unitOfWork.Products.FirstOrDefault(x => x.Name == model.Product);
                        if (manager == null)
                        {
                            buying.Manager = new Manager() { Name = model.ManagerName, SecondName = model.ManagerSecondName };
                        }
                        else buying.Manager = manager;
                        if (buyer == null)
                        {
                            buying.Buyer = new Buyer() { FullName = model.Buyer };
                        }
                        else buying.Buyer = buyer;
                        if (product == null)
                        {
                            buying.Product = new Product() { Name = model.Product, Cost = model.Cost };
                        }
                        else buying.Product = product;

                        buying.PurchaseDate = model.PurchaseDate;
                        buying.Cost = model.Cost;
                        try
                        {
                            unitOfWork.Buyings.Add(buying);
                            await unitOfWork.SaveAsync();
                        }
                        catch (Exception e)
                        {
                            Log.Error($"BuyingsController.Create :Ошибка при создании покупки: {DateTime.Now}" +
                           $"{Environment.NewLine}{e}{Environment.NewLine}");
                            throw new Exception($"Ошибка при создании покупки: {e}");
                        }
                    }
                    else
                    {
                        Log.Error($"BuyingsController.Create :Данная покупка уже занесена в БД: {DateTime.Now}{Environment.NewLine}");
                        throw new Exception($"Данная покупка уже занесена в БД");
                    }
                }
            }
            return View("Index");
        }

        [Authorize]
        public ActionResult SearchBuyingByManager(string managerSecondName)
        {
            if (managerSecondName != null)
            {
                IList<BuyingsViewModel> model = new List<BuyingsViewModel>();
                using (var context = new ApplicationDbContext())
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    var buyings = unitOfWork.Buyings.ToList().Where(x => x.Manager.SecondName.Contains(managerSecondName));
                    foreach (var buying in buyings)
                    {                        
                        model.Add(new BuyingsViewModel()
                        {
                            ManagerName = buying.Manager.Name,
                            ManagerSecondName = buying.Manager.SecondName,
                            Buyer = buying.Buyer.FullName,
                            Product = buying.Product.Name,
                            PurchaseDate = buying.PurchaseDate,
                            Cost = buying.Cost,
                            Buying = buying
                        });
                    }
                }
                return PartialView("BuyingsContainer", model);
            }
            return RedirectToAction("ListOfBuyings");
        }

        [Authorize]
        public ActionResult SearchBuyingByBuyer(string buyerName)
        {
            if (buyerName != null)
            {
                IList<BuyingsViewModel> model = new List<BuyingsViewModel>();
                using (var context = new ApplicationDbContext())
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    var buyings = unitOfWork.Buyings.ToList().Where(x => x.Buyer.FullName.Contains(buyerName));
                    foreach (var buying in buyings)
                    {
                        model.Add(new BuyingsViewModel()
                        {
                            ManagerName = buying.Manager.Name,
                            ManagerSecondName = buying.Manager.SecondName,
                            Buyer = buying.Buyer.FullName,
                            Product = buying.Product.Name,
                            PurchaseDate = buying.PurchaseDate,
                            Cost = buying.Cost,
                            Buying = buying
                        });
                    }
                }
                return PartialView("BuyingsContainer", model);
            }
            return RedirectToAction("ListOfBuyings");
        }

        [Authorize]
        public ActionResult SearchBuyingByProduct(string productName)
        {
            if (productName != null)
            {
                IList<BuyingsViewModel> model = new List<BuyingsViewModel>();
                using (var context = new ApplicationDbContext())
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    var buyings = unitOfWork.Buyings.ToList().Where(x => x.Product.Name.Contains(productName));
                    foreach (var buying in buyings)
                    {
                        model.Add(new BuyingsViewModel()
                        {
                            ManagerName = buying.Manager.Name,
                            ManagerSecondName = buying.Manager.SecondName,
                            Buyer = buying.Buyer.FullName,
                            Product = buying.Product.Name,
                            PurchaseDate = buying.PurchaseDate,
                            Cost = buying.Cost,
                            Buying = buying
                        });
                    }
                }
                return PartialView("BuyingsContainer", model);
            }
            return RedirectToAction("ListOfBuyings");
        }

        [Authorize]
        public ActionResult SearchBuyingByDate(string date)
        {
            if (date != null)
            {
                bool isDateTime = DateTime.TryParse(date, out DateTime inpDate);
                if (isDateTime)
                {                   
                    IList<BuyingsViewModel> model = new List<BuyingsViewModel>();
                    using (var context = new ApplicationDbContext())
                    {                       
                        IUnitOfWork unitOfWork = new UnitOfWork(context);
                        var buyings = unitOfWork.Buyings.ToList().Where(x=>x.PurchaseDate.ToString("dd.MM.yyyy") == inpDate.ToString("dd.MM.yyyy"));                       
                        foreach (var buying in buyings)
                        {
                            model.Add(new BuyingsViewModel()
                            {
                                ManagerName = buying.Manager.Name,
                                ManagerSecondName = buying.Manager.SecondName,
                                Buyer = buying.Buyer.FullName,
                                Product = buying.Product.Name,
                                PurchaseDate = buying.PurchaseDate,
                                Cost = buying.Cost,
                                Buying = buying
                            });
                        }
                    }
                    return PartialView("BuyingsContainer", model);
                }
            }                
            return RedirectToAction("ListOfBuyings");
        }

        [Authorize]
        public ActionResult SearchBuyingByCost(string cost)
        {
            if (cost != null)
            {
                bool isCostDecimal = decimal.TryParse(cost, out decimal inpCost);
                if (isCostDecimal)
                {
                    IList<BuyingsViewModel> model = new List<BuyingsViewModel>();
                    using (var context = new ApplicationDbContext())
                    {
                        IUnitOfWork unitOfWork = new UnitOfWork(context);
                        var buyings = unitOfWork.Buyings.ToList().Where(x => x.Cost == inpCost);
                        foreach (var buying in buyings)
                        {
                            model.Add(new BuyingsViewModel()
                            {
                                ManagerName = buying.Manager.Name,
                                ManagerSecondName = buying.Manager.SecondName,
                                Buyer = buying.Buyer.FullName,
                                Product = buying.Product.Name,
                                PurchaseDate = buying.PurchaseDate,
                                Cost = buying.Cost,
                                Buying = buying
                            });
                        }
                    }
                    return PartialView("BuyingsContainer", model);
                }                    
            }
            return RedirectToAction("ListOfBuyings");
        }
    }
}
