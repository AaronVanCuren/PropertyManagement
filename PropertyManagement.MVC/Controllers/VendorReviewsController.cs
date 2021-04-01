using Microsoft.AspNet.Identity;
using PropertyManagement.Data;
using PropertyManagement.Models;
using PropertyManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManagement.Controllers
{
    public class VendorReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VendorReviews
        public ActionResult Index()
        {
            var svc = VendorReviewCreateService();
            var vReview = svc.GetVendorReviews();
            return View(vReview);
        }

        // GET: VendorReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate review)
        {
            if (!ModelState.IsValid)
                return View(review);

            var svc = VendorReviewCreateService();

            if (svc.ReviewVendorCreate(review))
            {
                TempData["SaveResult"] = "Vendor was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Vendor could not be created.");

            return View(review);
        }

        // GET: VendorReviews/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = VendorReviewCreateService();
            var review = svc.GetVendorReviewsById(id);
            return View(review);
        }

        // GET: VendorReviews/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = VendorReviewCreateService();
            var model = svc.GetVendorReviewsById(id);
            var review = new ReviewEdit
            {
                Title = model.Title,
                Content = model.Content
            };

            return View(review);
        }

        // POST: VendorReviews/Edit/{id}
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewEdit review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }

            if (review.ReviewId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(review);
            }

            var svc = VendorReviewCreateService();

            if (svc.UpdateVendorReview(review))
            {
                TempData["SaveResult"] = "Vendor review was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Vendor review could not be updated.");
            return View(review);
        }

        // GET: VendorReviews/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = VendorReviewCreateService();
            var review = svc.GetVendorReviewsById(id);
            return View(review);
        }

        // POST: VendorReviews/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var svc = VendorReviewCreateService();
            svc.DeleteVendorReview(id);
            TempData["SaveResult"] = "Vendor review was deleted.";
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

        private ReviewService VendorReviewCreateService()
        {
            var userId = User.Identity.GetUserId();
            var svc = new ReviewService(userId);
            return svc;
        }
    }
}