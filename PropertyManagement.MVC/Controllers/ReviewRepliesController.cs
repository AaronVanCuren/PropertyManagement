using Microsoft.AspNet.Identity;
using PropertyManagement.Data;
using PropertyManagement.Models.Replies;
using PropertyManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManagement.Controllers
{
    public class ReviewRepliesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReviewReplies
        public ActionResult Index()
        {
            var svc = CreateReviewRepliesService();
            var rReply = svc.GetReviewReplies();
            return View(rReply);
        }

        // GET: ReviewReplies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReviewReplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return View(reply);

            var svc = CreateReviewRepliesService();

            if (svc.ReplyReviewCreate(reply))
            {
                TempData["SaveResult"] = "Reply was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Reply could not be created.");

            return View(reply);
        }

        // GET: ReviewReplies/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateReviewRepliesService();
            var reply = svc.GetReviewRepliesById(id);
            return View(reply);
        }

        // GET: ReviewReplies/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateReviewRepliesService();
            var model = svc.GetReviewRepliesById(id);
            var reply = new ReplyEdit
            {
                Content = model.Content,
            };

            return View(reply);
        }

        // POST: ReviewReplies/Edit/{id}
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReplyEdit reply)
        {
            if (!ModelState.IsValid)
            {
                return View(reply);
            }

            if (reply.ReplyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(reply);
            }

            var svc = CreateReviewRepliesService();

            if (svc.UpdateReply(reply))
            {
                TempData["SaveResult"] = "Reply review was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Reply review could not be updated.");
            return View(reply);
        }

        // GET: ReviewReplies/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateReviewRepliesService();
            var reply = svc.GetReviewRepliesById(id);
            return View(reply);
        }

        // POST: ReviewReplies/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var svc = CreateReviewRepliesService();
            svc.DeleteReply(id);
            TempData["SaveResult"] = "Reply review was deleted.";
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

        private ReplyService CreateReviewRepliesService()
        {
            var userId = User.Identity.GetUserId();
            var svc = new ReplyService(userId);
            return svc;
        }
    }
}