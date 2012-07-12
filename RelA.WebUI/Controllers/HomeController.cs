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

            List<Task> tasks = taskRepository.GetAll.ToList();

            model.Requested =
                (from task in tasks
                 let h = task.History.LastOrDefault()
                 where task.History.LastOrDefault().Status.Description.ToUpper() == "SOLICITADO"
                 select new HomeSummaryViewModel
                 {
                     TaskID = task.TaskID,
                     Title = task.Title,
                     Description = task.Description,
                     Status = h.Status.Description,
                     Color = ColorTranslator.FromHtml(h.Status.Color),
                     ChangeDate = h.HistoryDate
                 }).ToList();

            model.Developing =
               (from task in tasks
                let h = task.History.LastOrDefault()
                where task.History.LastOrDefault().Status.Description.ToUpper() == "EM DESENVOLVIMENTO"
                select new HomeSummaryViewModel
                {
                    TaskID = task.TaskID,
                    Title = task.Title,
                    Description = task.Description,
                    Status = h.Status.Description,
                    Color = ColorTranslator.FromHtml(h.Status.Color),
                    ChangeDate = h.HistoryDate
                }).ToList();

            model.Concluded =
                (from task in tasks
                 let h = task.History.LastOrDefault()
                 where task.History.LastOrDefault().Status.Description.ToUpper() == "CONCLUIDO"
                 select new HomeSummaryViewModel
                 {
                     TaskID = task.TaskID,
                     Title = task.Title,
                     Description = task.Description,
                     Status = h.Status.Description,
                     Color = ColorTranslator.FromHtml(h.Status.Color),
                     ChangeDate = h.HistoryDate
                 }).ToList();

            model.Others =
                (from task in tasks
                 let h = task.History.LastOrDefault()
                 where task.History.LastOrDefault().Status.Description.ToUpper() != "SOLICITADO"
                    && task.History.LastOrDefault().Status.Description.ToUpper() != "EM DESENVOLVIMENTO"
                    && task.History.LastOrDefault().Status.Description.ToUpper() != "CONCLUIDO"
                 select new HomeSummaryViewModel
                 {
                     TaskID = task.TaskID,
                     Title = task.Title,
                     Description = task.Description,
                     Status = h.Status.Description,
                     Color = ColorTranslator.FromHtml(h.Status.Color),
                     ChangeDate = h.HistoryDate
                 }).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
