﻿using Microsoft.AspNetCore.Http;
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


namespace SalesWebService.Controllers
{
    public class BuyersController : Controller
    {
        // GET: BuyersController
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult ListOfBuyers()
        {
            IList<BuyersIndexViewModel> model = new List<BuyersIndexViewModel>();
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                var result = unitOfWork.Buyers.ToList();
                foreach (var buyer in result)
                {
                    model.Add(new BuyersIndexViewModel { Buyer = buyer, CountBuyings = buyer.Buyings.Count() });
                }               
            }
            return PartialView("BuyersContainer", model);
        }
        

        // GET: BuyersController/Create
       

        // GET: BuyersController/Edit/5
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

        // POST: BuyersController/Edit/5
        [HttpPost]       
        public ActionResult Edit(Buyer model)
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
                    context.SaveChanges();
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

        

        // POST: BuyersController/Delete/5
        [HttpPost]       
        public ActionResult Delete(int Id)
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
                    context.SaveChanges();
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

        public ActionResult Create()
        {
            return View();
        }

        // POST: BuyersController/Create
        [HttpPost]       
        public ActionResult Create(Buyer model)
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
                            context.SaveChanges();
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
    }
}
