using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RelA.Domain.Abstract;
using RelA.WebUI.Models;
using RelA.Domain.Entities;
using RelA.WebUI.Models.Create;
using RelA.Domain.Concrete;

namespace RelA.WebUI.Controllers
{
    public class TaskController : Controller
    {
        ITaskRepository repository = null;

        public TaskController(ITaskRepository repo)
        {
            this.repository = repo;
        }

        public ActionResult Index()
        {
            TaskViewModel model = new TaskViewModel();
            model.Entity = repository.GetAll.OrderBy(o => o.Project.ProjectID).ThenBy(o => o.Title);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(TaskViewModel model)
        {

            IQueryable<Task> query = repository.GetAll;

            if (!string.IsNullOrWhiteSpace(model.Filter.Title))
                query = query.Where(w => w.Title.Contains(model.Filter.Title));

            if (model.Filter.ProjectID > 0)
                query = query.Where(w => w.Project.ProjectID == model.Filter.ProjectID);

            if (model.Filter.RequestDateFrom.HasValue)
                query = query.Where(w => w.RequestDate >= model.Filter.RequestDateFrom);

            if (model.Filter.RequestDateTo.HasValue)
                query = query.Where(w => w.RequestDate <= model.Filter.RequestDateTo);

            model.Entity = query;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TaskAddViewModel task)
        {
            if (ModelState.IsValid)
            {
                this.repository.Save(task.Task);

                return RedirectToAction("Index");
            }

            return View(task);
        }

        [HttpGet]
        public ActionResult Edit(int TaskID)
        {
            TaskAddViewModel editTask = new TaskAddViewModel();

            editTask.Task = this.repository.GetAll.FirstOrDefault(t => t.TaskID == TaskID);

            editTask.Projetos = (new ProjectRepository().GetAll);

            if (editTask.Task != null)
            {
                return View(editTask);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            TaskAddViewModel task = new TaskAddViewModel();

            task.Task= new Task();
            task.Projetos = (new ProjectRepository().GetAll);

            return View("Edit", task);
        }

        [HttpPost]
        public ActionResult Delete(int TaskID)
        {
            repository.Delete(TaskID);

            return RedirectToAction("Index");
        }
    }
}
