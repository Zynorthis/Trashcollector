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

        // GET: Trash
        public ActionResult Index()
        {
            return View();
        }

        // GET: Trash/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Trash/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trash/Create
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

        // GET: Trash/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trash/Edit/5
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

        // GET: Trash/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trash/Delete/5
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
    }
}
