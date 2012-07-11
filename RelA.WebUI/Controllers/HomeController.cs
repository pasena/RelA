using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using RelA.WebUI.Util;
using RelA.Domain.Abstract;
using RelA.WebUI.Models;
using System.Data.Entity;
using RelA.Domain.Entities;

namespace RelA.WebUI.Controllers
{
    public class HomeController : Controller
    {
        ITaskRepository taskRepository = null;

        public HomeController(ITaskRepository taskRepo)
        {
            taskRepository = taskRepo;
        }

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.Color = Color.Red;
            model.TextColor = model.Color.GetReadableForeColor();

            IEnumerable<Task> tasks = taskRepository.GetAll.Where(w => w.TaskID == 1).ToList();

            model.Requested =
                (from requested in tasks
                 select new HomeSummaryViewModel
                 {
                     Title = requested.Title,
                     Description = requested.Description,
                     Status = requested.History.LastOrDefault().Status.Description,
                     Color = Color.FromName(requested.History.LastOrDefault().Status.Color),
                     ChangeDate = requested.History.LastOrDefault().HistoryDate
                 }).ToList();

            tasks = taskRepository.GetAll.Where(w => w.TaskID == 2).ToList();

            model.Developing =
               (from requested in tasks
                select new HomeSummaryViewModel
                {
                    Title = requested.Title,
                    Description = requested.Description,
                    Status = requested.History.LastOrDefault().Status.Description,
                    Color = Color.FromName(requested.History.LastOrDefault().Status.Color),
                    ChangeDate = requested.History.LastOrDefault().HistoryDate
                }).ToList();

            tasks = taskRepository.GetAll.Where(w => w.TaskID == 3).ToList();

            model.Concluded =
                (from requested in tasks
                 select new HomeSummaryViewModel
                 {
                     Title = requested.Title,
                     Description = requested.Description,
                     Status = requested.History.LastOrDefault().Status.Description,
                     Color = Color.FromName(requested.History.LastOrDefault().Status.Color),
                     ChangeDate = requested.History.LastOrDefault().HistoryDate
                 }).ToList();

            tasks = taskRepository.GetAll.Where(w => w.TaskID == 4).ToList();

            model.Others =
                (from requested in tasks
                 select new HomeSummaryViewModel
                 {
                     Title = requested.Title,
                     Description = requested.Description,
                     Status = requested.History.LastOrDefault().Status.Description,
                     Color = Color.FromName(requested.History.LastOrDefault().Status.Color),
                     ChangeDate = requested.History.LastOrDefault().HistoryDate
                 }).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
