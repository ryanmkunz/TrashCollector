using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class EmployeesController : BaseController
    {
		public ApplicationDbContext Context = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
			var CurrentEmployee = Context.Employees.Where(c => c.ApplicationUserId == UserId).SingleOrDefault();
			if (CurrentEmployee == null)
			{
				return RedirectToAction("Create");
			}
			else
			{
				return RedirectToAction("CustomersInZip");
			}
		}

		public ActionResult CustomersInZip()
		{            
			var CurrentEmployee = Context.Employees.Where(e => e.ApplicationUserId == UserId).SingleOrDefault();
			var customersInZip = Context.Customers.Where(c => c.Zip == CurrentEmployee.Zip).Where(c => c.StartPickups <= DateTime.Today).ToList();
            return View(customersInZip);
		}

        public ActionResult CustomersInZipAnyDay()
        {
            var CurrentEmployee = Context.Employees.Where(e => e.ApplicationUserId == UserId).SingleOrDefault();
            var customersInZipAnyDay = Context.Customers.Where(c => c.Zip == CurrentEmployee.Zip);
            return View(customersInZipAnyDay);
        }

        public ActionResult CompletePickup(int? id)
        {
            var currentCustomer = Context.Customers.Find(id);
            DateTime newDate = DateTime.Today.AddDays(1);
            double newBill = currentCustomer.Bill + 7.50;

            currentCustomer.StartPickups = newDate;
            currentCustomer.Bill = newBill;
            
            Context.SaveChanges();
            return RedirectToAction("CustomersInZip");
        }

        public ActionResult ShowMap(int? id)
        {            
            string requestUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyAgLf7eJrlMl3r9OeTofUeBM06a59Ackjk";
            LocationViewModel locationViewModel = new LocationViewModel();            
            var customers = Context.Customers.Where(c => c.Id == id).SingleOrDefault();
            locationViewModel.customer = customers;
            WebRequest request = WebRequest.Create(requestUrl);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());

            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            XElement locationElement = result.Element("geometry").Element("location");
            XElement lat = locationElement.Element("lat");
            XElement lng = locationElement.Element("lng");

            locationViewModel.latitude = double.Parse(lat);
            locationViewModel.longitude = double.Parse(lng);

            return View(locationViewModel);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = Context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Zip")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    employee.ApplicationUserId = UserId;
                    Context.Employees.Add(employee); 
                    Context.SaveChanges();
                    return RedirectToAction("CustomersInZip");
                }
                catch (Exception)
                {
                    return View();                    
                }
                
			}

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = Context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Zip")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(employee).State = EntityState.Modified;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = Context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = Context.Employees.Find(id);
            Context.Employees.Remove(employee);
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
