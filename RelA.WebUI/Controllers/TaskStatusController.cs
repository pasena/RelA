using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RelA.Domain.Abstract;
using RelA.Domain.Entities;
using RelA.Domain.Concrete;
using RelA.WebUI.Models;

namespace RelA.WebUI.Controllers
{
    public class TaskStatusController : Controller
    {
        ITaskStatusRepository repository = null;

        public TaskStatusController(ITaskStatusRepository repo)
        {
            this.repository = repo;
        }

        public ActionResult Index()
        {
            TaskStatusViewModel model = new TaskStatusViewModel();
            model.Entity = repository.GetAll;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(TaskStatusViewModel model)
        {
            IQueryable<TaskStatus> query = repository.GetAll;

            if (model.Filter != null)
            {
                if (!string.IsNullOrWhiteSpace(model.Filter.Description))
                {
                    query = query.Where(w => w.Description.Contains(model.Filter.Description));
                }
            }

            model.Entity = query;

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Criar Novo Status";

            return View("Edit", new TaskStatus());
        }
            
        public ActionResult Edit(int TaskStatusID)
        {
            ViewBag.Title = "Editar Status";

            TaskStatus editTaskStatus = repository.GetAll.FirstOrDefault(w => w.TaskStatusID == TaskStatusID);

            if (editTaskStatus != null)
            {
                return View(editTaskStatus);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        
        [HttpPost]
        public ActionResult Edit(TaskStatus TaskStatus)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Save(TaskStatus);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(TaskStatus);
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int TaskStatusID)
        {
            repository.Delete(TaskStatusID);

            return RedirectToAction("Index");
        }
    }
}
