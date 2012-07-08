﻿using System;
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
        ITaskRepository taskRepository = null;
        IProjectRepository projectRepository = null;
        IUserRepository userRepository = null;
        ITaskStatusRepository statusRepository = null;

        public TaskController(ITaskRepository taskRepo, IProjectRepository projectRepo, IUserRepository userRepo, ITaskStatusRepository statusRepository)
        {
            this.taskRepository = taskRepo;
            this.projectRepository = projectRepo;
            this.userRepository = userRepo;
            this.statusRepository = statusRepository;
        }

        public ActionResult Index()
        {
            TaskViewModel model = new TaskViewModel();

            model.Entity = this.taskRepository.GetAll.OrderBy(o => o.Project.ProjectID).ThenBy(o => o.Title).ToList();
            model.Projects = this.projectRepository.GetAll;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(TaskViewModel model)
        {
            IQueryable<Task> query = this.taskRepository.GetAll;

            if (!string.IsNullOrWhiteSpace(model.Filter.Title))
                query = query.Where(w => w.Title.Contains(model.Filter.Title));

            if (model.Filter.ProjectID > 0)
                query = query.Where(w => w.Project.ProjectID == model.Filter.ProjectID);

            if (model.Filter.RequestDateFrom.HasValue)
                query = query.Where(w => w.RequestDate >= model.Filter.RequestDateFrom);

            if (model.Filter.RequestDateTo.HasValue)
                query = query.Where(w => w.RequestDate <= model.Filter.RequestDateTo);

            model.Entity = query;
            model.Projects = this.projectRepository.GetAll;

            return View(model);
        }

        public ViewResult Details(int taskID)
        {
            TaskDetailsViewModel model = new TaskDetailsViewModel();

            model.Task = taskRepository.GetAll.FirstOrDefault(w => w.TaskID == taskID);
            model.Status = statusRepository.GetAll;

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeStatus(TaskDetailsViewModel model)
        {
            Task task = taskRepository.GetAll.FirstOrDefault(w => w.TaskID == model.Task.TaskID);

            if (task.History != null && task.History.Count > 0)
            {
                if (model.SelectedTaskStatusID > 0 && model.SelectedTaskStatusID != task.History.Last().Status.TaskStatusID)
                {
                    taskRepository.ChangeStatus(task, model.SelectedTaskStatusID);
                }
            }
            else
            {
                taskRepository.ChangeStatus(task, model.SelectedTaskStatusID);
            }

            model.Status = statusRepository.GetAll;

            return RedirectToAction("Details", new { taskID = model.Task.TaskID });
        }

        [HttpPost]
        public ActionResult Edit(TaskAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.taskRepository.Save(model.Task);

                return RedirectToAction("Index");
            }

            model.Projects = projectRepository.GetAll;

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int TaskID)
        {
            TaskAddViewModel editTask = new TaskAddViewModel();

            editTask.Task = this.taskRepository.GetAll.FirstOrDefault(t => t.TaskID == TaskID);
            editTask.Projects = this.projectRepository.GetAll;

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
            TaskAddViewModel model = new TaskAddViewModel();

            model.Task = new Task();

            model.Task.UserID = 1;
            model.Projects = this.projectRepository.GetAll;

            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Delete(int TaskID)
        {
            taskRepository.Delete(TaskID);

            return RedirectToAction("Index");
        }
    }
}
