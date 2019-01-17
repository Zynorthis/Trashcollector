using Microsoft.AspNet.Identity;
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
            //ViewModel model = context.Customer.Where(c => c.Name == context)
            return View("_Index");
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            Pickups pickupFromDB = context.Pickups.Where(p => p.ID == id).FirstOrDefault();

            return View("PickupDetails", pickupFromDB);
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
            ViewModel viewmodel = new ViewModel()
            {
                Pickups = new Pickups(),
                Address = new Address(),
                Customer = new Customer(),
                States = new States()
            };
            //return View("CreatePickup", "Trashcollection");
            return View("CreatePickup");

        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(ViewModel model)
        {
            string currentUserId = User.Identity.GetUserId();

                //try
                //{
                    //Pickups newPickup = new Pickups();
                    //newPickup.Address = new Address();
                    //newPickup.PickupDay = model.PickupDay;
                    //newPickup.IsCompleted = false;
                    //newPickup.CompletionDate = "Not Completed Yet";
                model.Address.CustId = context.Customer.Where(e => e.AspNetUserID == currentUserId).Single().ID;
                States stateFromDB = context.States.Where(s => s.StateAbbrivation == model.States.StateAbbrivation).FirstOrDefault();
                model.Address.StateRefID = stateFromDB.ID;

                model.Pickups.IsCompleted = false;
                model.Pickups.CompletionDate = "Not Completed Yet";
                model.Address.Customer.AspNetUserID = currentUserId;

                Address addressFromDb = context.Address.Where(a => a.Address1 == model.Address.Address1).SingleOrDefault();
                if (addressFromDb == null)
                {
                    //newPickup.Address.Address1 = model.Address.Address1;
                    //newPickup.Address.Address2 = model.Address.Address2;
                    //newPickup.Address.Zipcode = model.Address.Zipcode;
                    //newPickup.Address.State.StateAbbrivation = model.Address.State.StateAbbrivation;
                    context.Address.Add(model.Address);
                }
                else
                {
                    model.Address.Address1 = addressFromDb.Address1;
                    model.Address.Address2 = addressFromDb.Address2;
                    model.Address.Zipcode = addressFromDb.Zipcode;
                    model.Address.State.StateAbbrivation = addressFromDb.State.StateAbbrivation;
                }

                context.Customer.Add(model.Customer);
                context.Pickups.Add(model.Pickups);

                context.SaveChanges();

                return RedirectToAction("PickupDetails", new { id = model.Pickups.ID });
            //}
            //catch
            //{
                return RedirectToAction("Create");
            //}
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Pickups pickupFromDB = context.Pickups.Where(p => p.ID == id).FirstOrDefault();

            ViewBag.States = new SelectList(context.States.Where(s => s.StateAbbrivation.Contains(s.StateAbbrivation)).ToList(), "ID", "StateAbbrivation");
            List<string> days = new List<string>()
            {
                "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
            };
            ViewBag.Days = new SelectList(days);

            return View("EditPickup", pickupFromDB);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pickups pickup)
        {
            try
            {
                Pickups pickupFromDB = context.Pickups.Where(p => p.ID == id).FirstOrDefault();
                pickupFromDB.Address.Customer.Name = pickup.Address.Customer.Name;
                pickupFromDB.Address.Address1 = pickup.Address.Address1;
                pickupFromDB.Address.Address1 = pickup.Address.Address2;
                pickupFromDB.Address.State.StateAbbrivation = pickup.Address.State.StateAbbrivation;
                pickupFromDB.Address.Zipcode = pickup.Address.Zipcode;
                pickupFromDB.PickupDay = pickup.PickupDay;

                context.SaveChanges();

                return RedirectToAction("PickupDetails", id);
            }
            catch
            {
                return View("PickupDetails", id);
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Pickups pickup = context.Pickups.Where(p => p.ID == id).FirstOrDefault();
            return View("CancelPickup", pickup);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Pickups pickup)
        {
            try
            {
                Pickups pickupFromDb = context.Pickups.Where(p => p.ID == pickup.ID).FirstOrDefault();
                context.Pickups.Remove(pickupFromDb);
                context.SaveChanges();

                return RedirectToAction("PickupList");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult List()
        {
            //List<Pickups> pickupList = context.Pickups.Where(p => p.Address.Customer.ID == id).ToList();
            List<Pickups> pickupList = context.Pickups.ToList();
            ViewBag.ModelBool = context.Pickups.Any();
            return View("PickupList", pickupList);
        }
    }
}
