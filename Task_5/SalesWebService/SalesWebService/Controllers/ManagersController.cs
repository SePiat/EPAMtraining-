using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesReportConverter.DAL.Context;
using SalesReportConverter.DAL.Repositories;
using SalesReportConverter.DAL.Repositories.Abstractions;
using SalesReportConverter.Model_.Models;
using SalesWebService.Models.Managers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SalesWebService.Controllers
{
    public class ManagersController : Controller
    {
        static int? globPage;
        [Authorize]
        public ActionResult Index(int? page)
        {
            globPage = page;
            return View();
        }

        public ActionResult ListOfManagers()
        {
            IList<ManagersIndexViewModel> models = new List<ManagersIndexViewModel>();
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                var managers = unitOfWork.Managers.ToList();
                foreach (var manager in managers)
                {
                    int countBuyers = unitOfWork.Buyings.ToList().Where(x => x.Manager == manager).Select(x => x.Buyer).Distinct().Count();
                    models.Add(new ManagersIndexViewModel { Manager = manager, CountBuyers = countBuyers});
                }
            }
            int pageNumber = globPage ?? 1;
            var model = models.ToPagedList(pageNumber, 3);
            return PartialView("ManagersContainer", model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            Manager manager;
            ManagersCreateEditViewModel model = new ManagersCreateEditViewModel();
            using (var context = new ApplicationDbContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(context);
                manager = unitOfWork.Managers.FirstOrDefault(x => x.Id == id);
            }
            if (manager == null)
            {
                return NotFound();
            }
            model.Id = id;
            model.Name = manager.Name;
            model.SecondName = manager.SecondName;
            return View(model);

        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Edit(ManagersCreateEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new ApplicationDbContext())
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    Manager manager = unitOfWork.Managers.FirstOrDefault(x => x.Id == model.Id);
                    if (manager == null)
                    {
                        return NotFound();
                    }
                    manager.Name = model.Name;
                    manager.SecondName = model.SecondName;
                    try
                    {
                        await unitOfWork.SaveAsync();
                    }
                    catch (Exception e)
                    {
                        Log.Error($"ManagersController.Edit: Ошибка при попытке сохранения изменений менеджера: {DateTime.Now}" +
                               $"{Environment.NewLine}{e}{Environment.NewLine}");
                        throw new Exception($"Ошибка при попытке сохранения изменений менеджера: {e}");
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
                Manager manager = unitOfWork.Managers.FirstOrDefault(x => x.Id == Id);
                if (manager == null)
                {
                    return NotFound();
                }
                try
                {
                    context.Managers.Remove(manager);
                    await unitOfWork.SaveAsync();
                }
                catch (Exception e)
                {
                    Log.Error($"ManagersController.Delete :Ошибка при удалении покупателя: {DateTime.Now}" +
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
        public async Task<ActionResult> Create(Manager model)
        {
            if (ModelState.IsValid)
            {
                Manager manager = new Manager { Name = model.Name, SecondName=model.SecondName };
                using (var context = new ApplicationDbContext())
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    Manager existManager = unitOfWork.Managers.FirstOrDefault(x => x.Name == model.Name&& x.SecondName==model.SecondName);
                    if (existManager == null)
                    {
                        try
                        {
                            unitOfWork.Managers.Add(manager);
                            await unitOfWork.SaveAsync();
                        }
                        catch (Exception e)
                        {
                            Log.Error($"ManagersController.Create :Ошибка при создании менеджера: {DateTime.Now}" +
                           $"{Environment.NewLine}{e}{Environment.NewLine}");
                            throw new Exception($"Ошибка при создании менеджера: {e}");
                        }
                    }
                    else
                    {
                        Log.Error($"ManagersController.Create :Менеджер с таким именем уже занесен в БД: {DateTime.Now}{Environment.NewLine}");
                        throw new Exception($"Менеджер с таким именем уже занесен в БД");
                    }
                }
            }
            return View("Index");
        }

        [Authorize]
        public ActionResult SearchManagerByName(string searchName)
        {
            if (searchName != null)
            {
                IList<ManagersIndexViewModel> model = new List<ManagersIndexViewModel>();
                using (var context = new ApplicationDbContext())
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    var result = unitOfWork.Managers.ToList().Where(x => x.Name.Contains(searchName));
                    foreach (var manager in result)
                    {
                        int countBuyers = unitOfWork.Buyings.ToList().Where(x => x.Manager == manager).Select(x => x.Buyer).Distinct().Count();
                        model.Add(new ManagersIndexViewModel { Manager = manager, CountBuyers = countBuyers });
                    }
                }
                return PartialView("ManagersContainer", model);
            }
            return RedirectToAction("ListOfManagers");
        }

        [Authorize]
        public ActionResult SearchManagerBySecondName(string secondName)
        {
            if (secondName != null)
            {
                IList<ManagersIndexViewModel> model = new List<ManagersIndexViewModel>();
                using (var context = new ApplicationDbContext())
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    var result = unitOfWork.Managers.ToList().Where(x => x.SecondName.Contains(secondName));
                    foreach (var manager in result)
                    {
                        int countBuyers = unitOfWork.Buyings.ToList().Where(x => x.Manager == manager).Select(x => x.Buyer).Distinct().Count();
                        model.Add(new ManagersIndexViewModel { Manager = manager, CountBuyers = countBuyers});
                    }
                }
                return PartialView("ManagersContainer", model);
            }
            return RedirectToAction("ListOfManagers");
        }

        [Authorize]
        public ActionResult ResetListOfBuyers() => RedirectToAction("ListOfBuyers");

        [Authorize]
        public ActionResult SearchByCountBuyers(string numberOfBuyers)
        {
            if (numberOfBuyers != null)
            {
                bool isIntSearchCountBuyers = int.TryParse(numberOfBuyers, out int count);
                if (isIntSearchCountBuyers)
                {
                    IList<ManagersIndexViewModel> model = new List<ManagersIndexViewModel>();
                    using (var context = new ApplicationDbContext())
                    {
                        IUnitOfWork unitOfWork = new UnitOfWork(context);
                        var managers = unitOfWork.Managers.ToList();
                        foreach (var manager in managers)
                        {
                            int countBuyers = unitOfWork.Buyings.ToList().Where(x => x.Manager == manager).Select(x => x.Buyer).Distinct().Count();
                            if (countBuyers== count)
                            {
                                model.Add(new ManagersIndexViewModel { Manager = manager, CountBuyers = countBuyers });
                            }
                        }                       
                    }
                    return PartialView("ManagersContainer", model);
                }
            }
            return RedirectToAction("ListOfManagers");
        }
    }
}
