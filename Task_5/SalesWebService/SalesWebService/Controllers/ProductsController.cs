using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model_.Models;
using SalesWebService.Models.Products;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SalesWebService.Controllers
{
    public class ProductsController : Controller
    {
        static int? globPage;
        [Authorize]
        public ActionResult Index(int? page)
        {
            globPage = page;
            return View();
        }

        public ActionResult ListOfProducts()
        {
            IList<ProductsIndexViewModel> models = new List<ProductsIndexViewModel>();
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                var products = unitOfWork.Products.ToList();
                foreach (var product in products)
                {
                    int countBuyers = unitOfWork.Buyings.ToList().Where(x => x.Product == product).Select(x => x.Buyer).Distinct().Count();
                    models.Add(new ProductsIndexViewModel { Product = product, CountBuyers = countBuyers });
                }
            }
            int pageNumber = globPage ?? 1;
            var model = models.ToPagedList(pageNumber, 3);
            return PartialView("ProductsContainer", model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Product product;
            ProductsCreateEditViewModel model = new ProductsCreateEditViewModel();
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                product = unitOfWork.Products.FirstOrDefault(x => x.Id == id);
            }
            if (product == null)
            {
                return NotFound();
            }
            model.Id = id;
            model.Name = product.Name;
            model.Cost = product.Cost;

            return View(model);

        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Edit(ProductsCreateEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new ApplicationDbContext())
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    Product product = unitOfWork.Products.FirstOrDefault(x => x.Id == model.Id);
                    if (product == null)
                    {
                        return NotFound();
                    }
                    product.Name = model.Name;
                    product.Cost = model.Cost;
                    try
                    {
                        await unitOfWork.SaveAsync();
                    }
                    catch (Exception e)
                    {
                        Log.Error($"ProductsContainer.Edit: Ошибка при попытке сохранения продукта: {DateTime.Now}" +
                               $"{Environment.NewLine}{e}{Environment.NewLine}");
                        throw new Exception($"Ошибка при попытке сохранения продукта: {e}");
                    }
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
                Product product = unitOfWork.Products.FirstOrDefault(x => x.Id == Id);
                if (product == null)
                {
                    return NotFound();
                }
                try
                {
                    context.Products.Remove(product);
                    await unitOfWork.SaveAsync();
                }
                catch (Exception e)
                {
                    Log.Error($"ProductsContainer.Delete :Ошибка при удалении продукта: {DateTime.Now}" +
                           $"{Environment.NewLine}{e}{Environment.NewLine}");
                    throw new Exception($"Ошибка при удалении продукта: {e}");
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
        public async Task<ActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product { Name = model.Name, Cost = model.Cost };
                using (var context = new ApplicationDbContext())
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    Product existProduct = unitOfWork.Products.FirstOrDefault(x => x.Name == model.Name);
                    if (existProduct == null)
                    {
                        try
                        {
                            unitOfWork.Products.Add(product);
                            await unitOfWork.SaveAsync();
                        }
                        catch (Exception e)
                        {
                            Log.Error($"ProductsContainer.Create :Ошибка при создании продукта: {DateTime.Now}" +
                           $"{Environment.NewLine}{e}{Environment.NewLine}");
                            throw new Exception($"Ошибка при создании продукта: {e}");
                        }
                    }
                    else
                    {
                        Log.Error($"ProductsContainer.Create :Продукт с таким названием уже занесен в БД: {DateTime.Now}{Environment.NewLine}");
                        throw new Exception($"Продукт с таким названием уже занесен в БД");
                    }
                }
            }
            return View("Index");
        }

        [Authorize]
        public ActionResult SearchProductByName(string searchName)
        {
            if (searchName != null)
            {
                IList<ProductsIndexViewModel> model = new List<ProductsIndexViewModel>();
                using (var context = new ApplicationDbContext())
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    var products = unitOfWork.Products.ToList().Where(x => x.Name.Contains(searchName));
                    foreach (var product in products)
                    {
                        int countBuyers = unitOfWork.Buyings.ToList().Where(x => x.Product == product).Select(x => x.Buyer).Distinct().Count();
                        model.Add(new ProductsIndexViewModel { Product = product, CountBuyers = countBuyers });
                    }
                }
                return PartialView("ProductsContainer", model);
            }
            return RedirectToAction("ListOfProducts");
        }

        [Authorize]
        public ActionResult SearchProductByCost(string cost)
        {
            if (cost != null)
            {
                IList<ProductsIndexViewModel> model = new List<ProductsIndexViewModel>();
                bool isDecimalCost = decimal.TryParse(cost, out decimal _cost);
                if (isDecimalCost)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        IUnitOfWork unitOfWork = new UnitOfWork(context);
                        var products = unitOfWork.Products.ToList().Where(x => x.Cost == _cost);
                        foreach (var product in products)
                        {
                            int countBuyers = unitOfWork.Buyings.ToList().Where(x => x.Product == products).Select(x => x.Buyer).Distinct().Count();
                            model.Add(new ProductsIndexViewModel { Product = product, CountBuyers = countBuyers });
                        }
                    }
                    return PartialView("ProductsContainer", model);
                }                
            }
            return RedirectToAction("ListOfProducts");
        }

        [Authorize]
        public ActionResult ResetListOfProducts() => RedirectToAction("ListOfProducts");

        [Authorize]
        public ActionResult SearchProductByCountBuyers(string numberOfBuyers)
        {
            if (numberOfBuyers != null)
            {
                bool isIntSearchCountBuyers = int.TryParse(numberOfBuyers, out int count);
                if (isIntSearchCountBuyers)
                {
                    IList<ProductsIndexViewModel> model = new List<ProductsIndexViewModel>();
                    using (var context = new ApplicationDbContext())
                    {
                        IUnitOfWork unitOfWork = new UnitOfWork(context);
                        var products = unitOfWork.Products.ToList();
                        foreach (var product in products)
                        {
                            int countBuyers = unitOfWork.Buyings.ToList().Where(x => x.Product == product).Select(x => x.Buyer).Distinct().Count();
                            if (countBuyers == count)
                            {
                                model.Add(new ProductsIndexViewModel { Product = product, CountBuyers = countBuyers });
                            }
                        }
                    }
                    return PartialView("ProductsContainer", model);
                }
            }
            return RedirectToAction("ListOfProducts");
        }
    }
}
