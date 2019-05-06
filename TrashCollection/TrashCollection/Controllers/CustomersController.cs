using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;
using Microsoft.AspNet.Identity;

namespace TrashCollection.Controllers
{
    public class CustomersController : BaseController
    {
        public ApplicationDbContext Context = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var CurrentCustomer = Context.Customers.Where(c => c.ApplicationUserId == UserId).SingleOrDefault();
            if (CurrentCustomer == null)
            {
                return RedirectToAction("Create");                
            }
            else
            {
                return RedirectToAction("Details", new { id = CurrentCustomer.Id });
            }
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = Context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,WeeklyPickupDay,StartPickUps,OneTimePickupDay,TempStopStart,TempStopEnd,Street,City,State,Zip")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.ApplicationUserId = UserId;
                customer.Bill = 0;
				Context.Customers.Add(customer);
                Context.SaveChanges();
                return RedirectToAction("Details", new { id = customer.Id });
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = Context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,WeeklyPickupDay,OneTimePickupDay,TempStopStart,TempStopEnd,Bill,Street,City,State,Zip")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(customer).State = EntityState.Modified;
                Context.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = Context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = Context.Customers.Find(id);
            Context.Customers.Remove(customer);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
