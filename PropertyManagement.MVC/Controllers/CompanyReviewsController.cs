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
    public class CompanyReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompanyReviews
        public ActionResult Index()
        {
            var svc = CompanyReviewCreateService();
            var cReview = svc.GetCompanyReviews();
            return View(cReview);
        }

        // GET: CompanyReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate review)
        {
            if (!ModelState.IsValid)
                return View(review);

            var svc = CompanyReviewCreateService();

            if (svc.ReviewCompanyCreate(review))
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
            var svc = CompanyReviewCreateService();
            var review = svc.GetCompanyReviewsById(id);
            return View(review);
        }

        // GET: VendorReviews/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CompanyReviewCreateService();
            var model = svc.GetCompanyReviewsById(id);
            var review = new ReviewEdit
            {
                Title = model.Title,
                Content = model.Content
            };

            return View(review);
        }

        // POST: CompanyReviews/Edit/{id}
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

            var svc = CompanyReviewCreateService();

            if (svc.UpdateCompanyReview(review))
            {
                TempData["SaveResult"] = "Company review was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Company review could not be updated.");
            return View(review);
        }

        // GET: CompanyReviews/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CompanyReviewCreateService();
            var review = svc.GetCompanyReviewsById(id);
            return View(review);
        }

        // POST: CompanyReviews/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var svc = CompanyReviewCreateService();
            svc.DeleteCompanyReview(id);
            TempData["SaveResult"] = "Company review was deleted.";
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

        private ReviewService CompanyReviewCreateService()
        {
            var userId = User.Identity.GetUserId();
            var svc = new ReviewService(userId);
            return svc;
        }
    }
}