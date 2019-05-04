using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollection.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if(string.IsNullOrEmpty(UserId))
            {
                return RedirectToAction("Register", "Account");
            }
            else
            {
                // TODO: Potentially use AspNetUserRoles & AspNetRoles tables [?]
                var employee = Context.Employees.FirstOrDefault(e => e.ApplicationUserId == UserId);
                if(employee != null)
                {
                    return RedirectToAction("Index", "Employees");
                }

                var customer = Context.Customers.FirstOrDefault(c => c.ApplicationUserId == UserId);
                if (customer != null)
                {
                    return RedirectToAction("Index", "Customers");
                }

                return RedirectToAction("Register", "Account");
            }
               
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}