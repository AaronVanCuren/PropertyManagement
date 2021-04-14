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
using PropertyManagement.Models.Comments;
using PropertyManagement.Services;

namespace PropertyManagement.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
        public ActionResult Index()
        {
            var svc = CreateCommentService();
            var comments = svc.GetComments();
            return View(comments);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return View(comment);

            var svc = CreateCommentService();

            if (svc.CommentCreate(comment))
            {
                TempData["SaveResult"] = "Comment was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Comment could not be created.");

            return View(comment);
        }

        // GET: Comments/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateCommentService();
            var comment = svc.GetCommentById(id);
            return View(comment);
        }

        // GET: Comments/Edit/{id}
        public ActionResult Edit(int id)
        {
            var svc = CreateCommentService();
            var model = svc.GetCommentById(id);
            var comment = new CommentEdit
            {
                Content = model.Content
            };

            return View(comment);
        }

        // POST: Comments/Edit/{id}
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommentEdit comment)
        {
            if (!ModelState.IsValid)
            {
                return View(comment);
            }

            if (comment.CommentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(comment);
            }

            var svc = CreateCommentService();

            if (svc.UpdateComment(comment))
            {
                TempData["SaveResult"] = "Comment was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Comment could not be updated.");
            return View(comment);
        }

        // GET: Comments/Delete/{id}
        public ActionResult Delete(int id)
        {
            var svc = CreateCommentService();
            var comment = svc.GetCommentById(id);
            return View(comment);
        }

        // POST: Comments/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var svc = CreateCommentService();
            svc.DeleteComment(id);
            TempData["SaveResult"] = "Comment was deleted.";
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

        private CommentService CreateCommentService()
        {
            var userId = User.Identity.GetUserId();
            var svc = new CommentService(userId);
            return svc;
        }
    }
}