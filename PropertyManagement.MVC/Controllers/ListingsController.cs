using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PropertyManagement.Data;
using PropertyManagement.Services;

namespace PropertyManagement.Controllers
{
    public class ListingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Listings
        public ActionResult Index()
        {
            var svc = ListingCreateService();
            var listing = svc.GetListings();
            return View(listing);
        }

        // GET: Listings/Create
        public ActionResult Create()
        {
            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyId", "Address");
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListingId,PropertyId")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Listings.Add(listing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyId", "Address", listing.PropertyId);
            return View(listing);
        }

        // GET: Listings/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }


        // GET: Listings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyId", "Address", listing.PropertyId);
            return View(listing);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListingId,PropertyId")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyId", "Address", listing.PropertyId);
            return View(listing);
        }

        // GET: Listings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Listing listing = db.Listings.Find(id);
            db.Listings.Remove(listing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private ListingService ListingCreateService()
        {
            var userId = User.Identity.GetUserId();
            var svc = new ListingService(userId);
            return svc;
        }
    }
}