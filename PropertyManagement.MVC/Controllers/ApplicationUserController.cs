using Microsoft.AspNet.Identity;
using PropertyManagement.Data;
using PropertyManagement.Models.ApplicationUsers;
using PropertyManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManagement.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationUser
        public ActionResult Index()
        {
            return View();
        }

        // GET: ApplicationUser/Managers
        public ActionResult GetManagers()
        {
            ApplicationUserService svc = CreateUserService();
            var user = svc.GetManagers();
            return View(user);
        }

        // GET: ApplicationUser/Owners
        public ActionResult GetOwners()
        {
            ApplicationUserService svc = CreateUserService();
            var user = svc.GetOwners();
            return View(user);
        }

        // GET: ApplicationUser/Residents
        public ActionResult GetResidents()
        {
            ApplicationUserService svc = CreateUserService();
            var user = svc.GetResidents();
            return View(user);
        }

        // GET: ApplicationUser/Details/{id}
        [ActionName("Details")]
        public ActionResult Details(string id)
        {
            ApplicationUserService svc = CreateUserService();
            var user = svc.GetUserById(id);
            return View(user);
        }

        // GET: ApplicationUser/Edit/{id}
        [ActionName("Edit")]
        public ActionResult Edit(string id)
        {
            var svc = CreateUserService();
            var model = svc.GetUserById(id);
            var user = new ApplicationUserDetail
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            return View(user);
        }

        // POST: Properties/Edit/{id}
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, ApplicationUserDetail user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (user.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(user);
            }

            var svc = CreateUserService();

            if (svc.UpdateUser(user))
            {
                TempData["SaveResult"] = "Property was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Property could not be updated.");
            return View(user);
        }

        // GET: ApplicationUser/Delete/{id}
        public ActionResult Delete(string id)
        {
            var svc = CreateUserService();
            var user = svc.GetUserById(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser(string id)
        {
            var svc = CreateUserService();
            svc.DeleteUser(id);
            TempData["SaveResult"] = "User was deleted.";
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

        private ApplicationUserService CreateUserService()
        {
            var userId = User.Identity.GetUserId();
            var svc = new ApplicationUserService(userId);
            return svc;
        }
    }
}