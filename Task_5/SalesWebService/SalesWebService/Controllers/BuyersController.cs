using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model_.Models;
using SalesWebService.Models.Buyers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList.Mvc.Core;
using X.PagedList;


namespace SalesWebService.Controllers
{
    public class BuyersController : Controller
    {
        static int? globPage;
        [Authorize]
        public ActionResult Index(int? page)
        {
            globPage = page;
            return View();
        }
        
        public ActionResult ListOfBuyers(int? page)
        {
            IList<BuyersIndexViewModel> models = new List<BuyersIndexViewModel>();
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                var result = unitOfWork.Buyers.ToList();
                foreach (var buyer in result)
                {
                    models.Add(new BuyersIndexViewModel { Buyer = buyer, CountBuyings = buyer.Buyings.Count() });
                }               
            }
            int pageNumber = globPage ?? 1; 
            var model = models.ToPagedList(pageNumber, 5);

          
            return PartialView("BuyersContainer", model);
        }
        
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Buyer buyer;
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                buyer = unitOfWork.Buyers.FirstOrDefault(x=>x.Id==id);               
            }
            if (buyer == null)
            {
                return NotFound();
            }            
            return View(buyer);
            
        }       

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Edit(Buyer model)
        {            
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                Buyer buyer = unitOfWork.Buyers.FirstOrDefault(x => x.Id == model.Id);
                if (buyer == null)
                {
                    return NotFound();
                }
                buyer.FullName = model.FullName;
                try
                {
                    await unitOfWork.SaveAsync();
                }
                catch (Exception e)
                {
                    Log.Error($"BuyersController.Edit: Ошибка при попытке сохранения нового имени покупателя: {DateTime.Now}" +
                           $"{Environment.NewLine}{e}{Environment.NewLine}");
                    throw new Exception($"Ошибка при попытке сохранения нового имени покупателя: {e}");
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
                Buyer buyer = unitOfWork.Buyers.FirstOrDefault(x => x.Id == Id);
                if (buyer == null)
                {
                    return NotFound();
                }
                try
                {
                    context.Buyers.Remove(buyer);
                    await unitOfWork.SaveAsync();
                }
                catch (Exception e)
                {
                    Log.Error($"BuyersController.Delete :Ошибка при удалении покупателя: {DateTime.Now}" +
                           $"{Environment.NewLine}{e}{Environment.NewLine}");
                    throw new Exception($"Ошибка при удалении покупателя: {e}");
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
        public async Task<ActionResult> Create(Buyer model)
        {
            if (ModelState.IsValid)
            {
                Buyer buyer = new Buyer { FullName = model.FullName};
                using (var context = new ApplicationDbContext())
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    Buyer existBuyer = unitOfWork.Buyers.FirstOrDefault(x => x.FullName == model.FullName);
                    if (existBuyer==null)
                    {
                        try
                        {
                            unitOfWork.Buyers.Add(buyer);
                            await unitOfWork.SaveAsync();                                                       
                        }
                        catch (Exception e)
                        {
                            Log.Error($"BuyersController.Create :Ошибка при создании покупателя: {DateTime.Now}" +
                           $"{Environment.NewLine}{e}{Environment.NewLine}");
                            throw new Exception($"Ошибка при создании покупателя: {e}");
                        }
                    }
                    else
                    {
                        Log.Error($"BuyersController.Create :Покупатель с таким именем уже занесен в БД: {DateTime.Now}{Environment.NewLine}");                           
                        throw new Exception($"Покупатель с таким именем уже занесен в БД");
                    }                                     
                }
            }
            return View("Index");
        }

        [Authorize]
        public ActionResult SearchByName(string searchName)
        {
            if (searchName != null)
            {
                IList<BuyersIndexViewModel> model = new List<BuyersIndexViewModel>();
                using (var context = new ApplicationDbContext())
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    var result = unitOfWork.Buyers.ToList().Where(x => x.FullName.Contains(searchName));
                    foreach (var buyer in result)
                    {
                        model.Add(new BuyersIndexViewModel { Buyer = buyer, CountBuyings = buyer.Buyings.Count() });
                    }
                }
                return PartialView("BuyersContainer", model);
            }
            return RedirectToAction("ListOfBuyers");
        }

        [Authorize]
        public ActionResult ResetListOfBuyers()=> RedirectToAction("ListOfBuyers");

        [Authorize]
        public ActionResult SearchByCountBuyings(string searchCountBuyings)
        {
            if (searchCountBuyings != null)
            {
                bool isIntSearchCountBuyings = int.TryParse(searchCountBuyings, out int count);
                if (isIntSearchCountBuyings)
                {
                    IList<BuyersIndexViewModel> model = new List<BuyersIndexViewModel>();
                    using (var context = new ApplicationDbContext())
                    {
                        IUnitOfWork unitOfWork = new UnitOfWork(context);
                        var result = unitOfWork.Buyers.ToList().Where(x => x.Buyings.Count==count);
                        foreach (var buyer in result)
                        {
                            model.Add(new BuyersIndexViewModel { Buyer = buyer, CountBuyings = buyer.Buyings.Count() });
                        }
                    }
                    return PartialView("BuyersContainer", model);
                }               
            }
            return RedirectToAction("ListOfBuyers");
        }
    }
}
