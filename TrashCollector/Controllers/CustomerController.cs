using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext context;

        public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            ViewBag.States = new SelectList(context.States.Where(s => s.StateAbbrivation.Contains(s.StateAbbrivation)).ToList(), "ID", "StateAbbrivation");

            List<string> days = new List<string>()
            {
                "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
            };
            ViewBag.Days = new SelectList(days);

            //return View("CreatePickup", "Trashcollection");
            return View("CreatePickup");

        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Pickups model, int ID)
        {
            try
            {
                Pickups newPickup = new Pickups();
                newPickup.PickupDay = model.PickupDay;
                newPickup.IsCompleted = false;

                Address addressFromDb = context.Address.Where(a => a.Address1 == model.Address.Address1).SingleOrDefault();
                if (addressFromDb == null)
                {
                    newPickup.Address.Address1 = model.Address.Address1;
                    newPickup.Address.Address2 = model.Address.Address2;
                    newPickup.Address.Zipcode = model.Address.Zipcode;
                    newPickup.Address.State.StateAbbrivation = model.Address.State.StateAbbrivation;
                }
                else
                {
                    newPickup.Address.Address1 = addressFromDb.Address1;
                    newPickup.Address.Address2 = addressFromDb.Address2;
                    newPickup.Address.Zipcode = addressFromDb.Zipcode;
                    newPickup.Address.State.StateAbbrivation = addressFromDb.State.StateAbbrivation;
                }
                newPickup.Address.Customer.Name = model.Address.Customer.Name;

                context.Pickups.Add(newPickup);
                context.SaveChanges();

                return RedirectToAction("PickupDetails", new { id = newPickup.ID });
            }
            catch
            {
                return View("CreatePickup");
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
