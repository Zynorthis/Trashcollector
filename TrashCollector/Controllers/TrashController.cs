using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class TrashController : Controller
    {
        // instantuating database object
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult _Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                if (CheckUserIdentity() == "Admin")
                {
                    User.IsInRole("Admin");
                    ViewBag.displayMenu = "Admin";
                }
                else if (CheckUserIdentity() == "Employee")
                {
                    ViewBag.displayMenu = "Employee";
                }
                else if (CheckUserIdentity() == "Customer")
                {
                    ViewBag.displayMenu = "Customer";
                }
                else
                {
                    ViewBag.Name = "Not Logged In";
                }
            }
            else
            {
                ViewBag.Name = "Not Logged In";
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private string CheckUserIdentity()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                var s = userManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return "Admin";
                }
                else if (s[0].ToString() == "Employee")
                {
                    return "Employee";
                }
                else if (s[0].ToString() == "Customer")
                {
                    return "Customer";
                }
                else
                {
                    return "Error";
                }
            }
            else
            {
                return "Error";
            }
        }
    }
}
