using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RelA.Domain.Abstract;
using RelA.Domain.Entities;
using RelA.WebUI.Models;

namespace RelA.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository repository = null;

        public UserController(IUserRepository repo)
        {
            this.repository = repo;
        }

        [HttpGet]
        public ViewResult Index(int page = 1)
        {
            UserViewModel model = new UserViewModel
            {
                Entity = repository.Users
            };

            // model.Paging(page);

            return View(model);
        }

        [HttpPost]
        public ViewResult Index(UserViewModel model)
        {
            if (model.Filter != null)
            {
                IQueryable<User> query = repository.Users;

                if (!string.IsNullOrWhiteSpace(model.Filter.Login))
                    query = query.Where(w => w.Login.Contains(model.Filter.Login));

                model.Entity = query;
            }

            // model.Paging();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                this.repository.SaveUser(user);

                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int UserID)
        {
            User editUser = this.repository.Users.FirstOrDefault(u => u.UserID == UserID);

            if (editUser != null)
            {
                return View(editUser);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Edit", new User());
        }
    }
}
