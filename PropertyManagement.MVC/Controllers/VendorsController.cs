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
using PropertyManagement.Models.Vendors;
using PropertyManagement.Services;

namespace PropertyManagement.Controllers
{
    public class VendorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vendors
        public ActionResult Index()
        {
            var svc = CreateVendorService();
            var vendors = svc.GetVendors();
            return View(vendors);
        }


        // GET: Vendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendorCreate vendor)
        {
            if (!ModelState.IsValid)
                return View(vendor);

            var svc = CreateVendorService();

            if (svc.VendorCreate(vendor))
            {
                TempData["SaveResult"] = "Vendor was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Vendor could not be created.");

            return View(vendor);
        }

        // GET: Vendors/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateVendorService();
            var vendor = svc.GetVendorById(id);
            return View(vendor);
        }

        // GET: Vendors/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateVendorService();
            var model = svc.GetVendorById(id);
            var vendor = new VendorEdit
            {
                VendorName = model.VendorName,
                Description = model.Description,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            return View(vendor);
        }

        // POST: Vendors/Edit/{id}
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VendorEdit vendor)
        {
            if (!ModelState.IsValid)
            {
                return View(vendor);
            }

            if (vendor.VendorId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(vendor);
            }

            var svc = CreateVendorService();

            if (svc.UpdateVendor(vendor))
            {
                TempData["SaveResult"] = "Vendor was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Vendor could not be updated.");
            return View(vendor);
        }

        // GET: Vendors/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateVendorService();
            var vendor = svc.GetVendorById(id);
            return View(vendor);
        }

        // POST: Vendors/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var svc = CreateVendorService();
            svc.DeleteVendor(id);
            TempData["SaveResult"] = "Vendor was deleted.";
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

        private VendorService CreateVendorService()
        {
            var userId = User.Identity.GetUserId();
            var svc = new VendorService(userId);
            return svc;
        }
    }
}