using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RelA.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (Domain.Concrete.RelAContext context = new Domain.Concrete.RelAContext())
            {
                return View(context.Users.ToList());
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
