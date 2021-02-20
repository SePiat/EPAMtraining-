using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model_.Models;
using SalesWebService.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList.Mvc;
using PagedList;

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
            BuyersIndexViewModel model = new BuyersIndexViewModel();
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                var result = unitOfWork.Buyers.ToList();
                model.buyers.AddRange(result);
            }
            return PartialView("BuyersContainer", model);
        }
        // GET: BuyersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BuyersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuyersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BuyersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BuyersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BuyersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BuyersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
