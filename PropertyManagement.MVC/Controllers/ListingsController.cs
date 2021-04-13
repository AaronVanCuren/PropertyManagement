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
using PropertyManagement.Models.Listings;
using PropertyManagement.Services;

namespace PropertyManagement.Controllers
{
    public class ListingsController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

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
            var svcP = PropertyCreateService();
            ViewBag.Properties = svcP.GetProperties();
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListingCreate listing)
        {
            if (!ModelState.IsValid)
                return View(listing);

            var svc = ListingCreateService();

            if (svc.ListingCreate(listing))
            {
                TempData["SaveResult"] = "Your listing was created.";
                return RedirectToAction("Index");
            };
            ModelState
                .AddModelError("", "Property could not be created.");

            return View(listing);
        }

        // GET: Listings/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = ListingCreateService();
            var listing = svc.GetListingById(id);
            return View(listing);
        }

        // POST: Listings/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var svc = ListingCreateService();
            svc.DeleteListing(id);
            TempData["SaveResult"] = "Listing was deleted.";
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

        private PropertyService PropertyCreateService()
        {
            var userId = User.Identity.GetUserId();
            var svcP = new PropertyService(userId);
            return svcP;
        }
    }
}