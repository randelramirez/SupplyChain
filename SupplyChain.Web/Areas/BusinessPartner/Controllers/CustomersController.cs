using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SupplyChain.Core.Models;
using SupplyChain.Infrastructure.Models;

namespace SupplyChain.Web.Areas.BusinessPartner.Controllers
{
    public class CustomersController : Controller
    {
        private SupplyChainContext db = new SupplyChainContext();
        private IRepository repository = new Repository();

        // GET: BusinessPartner/Customers
        public ActionResult Index()
        {
            var x = this.repository.GetAll<SalesOrderHeader>().ToList();
          //TO DO
            var customers = //this.repository.GetAll<Customer>();
            new Repository().All123<Customer>(m => m.SalesOrder);
            return View(customers);
            //return View(db.Customers.ToList());
        }

        // GET: BusinessPartner/Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: BusinessPartner/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessPartner/Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastModified,CreatedAt")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //db.Customers.Add(customer);
                //db.SaveChanges();
                this.repository.Add<Customer>(customer);
                this.repository.Save();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: BusinessPartner/Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customers.Find(id);
            Customer customer = this.repository.Find<Customer>(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: BusinessPartner/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastModified,CreatedAt")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(customer).State = EntityState.Modified;
                //db.SaveChanges();
                this.repository.Update<Customer>(customer);
                this.repository.Save();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: BusinessPartner/Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Customer customer = db.Customers.Find(id);
            var customer = this.repository.Find<Customer>(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: BusinessPartner/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Customer customer = db.Customers.Find(id);
            //db.Customers.Remove(customer);
            //db.SaveChanges();

            var customer = this.repository.Find<Customer>(id);
            this.repository.Delete<Customer>(customer);
            this.repository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                (this.repository as IDisposable).Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
