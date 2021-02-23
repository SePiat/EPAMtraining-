using Microsoft.AspNetCore.Mvc;
using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesWebService.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SalesWebService.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index(int? page)
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
            int pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfBuyers = model.ToPagedList(pageNumber, 5); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfBuyers = onePageOfBuyers;

            return View(model);
        }

    }
}
