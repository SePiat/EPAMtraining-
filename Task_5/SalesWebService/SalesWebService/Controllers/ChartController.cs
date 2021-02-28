using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesWebService.Models.Chart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebService.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult ManagersChart()
        {
            IList<ChartViewModel> models = new List<ChartViewModel>();
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                var managers = unitOfWork.Managers.ToList();
                foreach (var manager in managers)
                {
                    int countBuyings = unitOfWork.Buyings.ToList().Where(x => x.Manager == manager).Count();
                    models.Add(new ChartViewModel(y: countBuyings, label:manager.Name + " " + manager.SecondName));
                }
            }
            ViewBag.NameChart = "Chart of the number of sales by managers";

            ViewBag.DataPoints = JsonConvert.SerializeObject(models);
			return View("Index");
		}

        public IActionResult BuyersChart()
        {
            IList<ChartViewModel> models = new List<ChartViewModel>();
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                var buyers = unitOfWork.Buyers.ToList();
                foreach (var buyer in buyers)
                {
                    int countBuyings = unitOfWork.Buyings.ToList().Where(x => x.Buyer == buyer).Count();
                    models.Add(new ChartViewModel(y: countBuyings, label: buyer.FullName));
                }
            }
            ViewBag.NameChart = "Chart of the number of sales by buyers";
            ViewBag.DataPoints = JsonConvert.SerializeObject(models);
            return View("Index");
        }
    }
}
