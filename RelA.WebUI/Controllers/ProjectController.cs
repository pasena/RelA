using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RelA.WebUI.Models;
using RelA.Domain.Abstract;
using RelA.Domain.Entities;

namespace RelA.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        IProjectRepository repository = null;

        public ProjectController(IProjectRepository repo)
        {
            this.repository = repo;
        }

        public ActionResult Index()
        {
            ProjectViewModel model = new ProjectViewModel();
            model.Entity = repository.GetAll();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ProjectViewModel model)
        {
            IQueryable<Project> query = repository.GetAll();

            if (model.Filter != null)
            {
                if (!string.IsNullOrWhiteSpace(model.Filter.Name))
                {
                    query = query.Where(w => w.Name.Contains(model.Filter.Name));
                }
            }

            model.Entity = query;

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Criar Novo Projeto";

            return View("Edit", new Project());
        }
            
        public ActionResult Edit(int projectID)
        {
            ViewBag.Title = "Editar Projeto";

            Project editProject = repository.GetAll().FirstOrDefault(w => w.ProjectID == projectID);

            if (editProject != null)
            {
                return View(editProject);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        
        [HttpPost]
        public ActionResult Edit(Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Save(project);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(project);
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int projectID)
        {
            repository.Delete(projectID);

            return RedirectToAction("Index");
        }
    }
}
