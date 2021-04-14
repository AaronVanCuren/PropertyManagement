using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using PropertyManagement.Data;
using PropertyManagement.Models.Properties;
using PropertyManagement.Services;
using Microsoft.AspNet.Identity;
using System.Linq;
using System;

namespace PropertyManagement.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Properties
        public ActionResult Index()
        {
            var svc = CreatePropertyService();
            var property = svc.GetProperties();
            return View(property);
        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            /*ViewBag.Utilities = Enum.GetValues(typeof(Utilities)).Cast<Utilities>().ToList();
            ViewBag.Appliances = Enum.GetValues(typeof(Applicances)).Cast<Applicances>().ToList();
            ViewBag.Amenities = Enum.GetValues(typeof(Amenities)).Cast<Amenities>().ToList();*/

            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyCreate property)
        {
            if (!ModelState.IsValid)
                return View(property);

            var svc = CreatePropertyService();

            if (svc.PropertyCreate(property))
            {
                TempData["SaveResult"] = "Your property was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Property could not be created.");

            return View(property);
        }

        // GET: Properties/Details/{id}
        [ActionName("Details")]
        public ActionResult Details(int id)
        {
            var svc = CreatePropertyService();
            var property = svc.GetPropertyById(id);
            return View(property);
        }


        // GET: Properties/Edit/{id}
        [ActionName("Edit")]
        public ActionResult Edit(int id)
        {
            /*ViewBag.Utilities = Enum.GetValues(typeof(Utilities)).Cast<Utilities>().ToList();
            ViewBag.Appliances = Enum.GetValues(typeof(Applicances)).Cast<Applicances>().ToList();
            ViewBag.Amenities = Enum.GetValues(typeof(Amenities)).Cast<Amenities>().ToList();*/

            var svc = CreatePropertyService();
            var model = svc.GetPropertyById(id);
            var property = new PropertyDetail
            {
                Address = model.Address,
                PropTy = model.PropTy,
                IsAHP = model.IsAHP,
                Status = model.Status,
                Description = model.Description,
                Bedroom = model.Bedroom,
                Bathroom = model.Bathroom,
                SqFt = model.SqFt,
                Rent = model.Rent,
                AppFee = model.AppFee,
                SD = model.SD,
                NSFee = model.NSFee,
                /*Utilities = model.Utilities,
                Appliances = model.Appliances,*/
                Cat = model.Cat,
                Dog = model.Dog,
                /*Amenities = model.Amenities*/
            };

            return View(property);
        }

        // POST: Properties/Edit/{id}
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PropertyDetail property)
        {
            if (!ModelState.IsValid)
            {
                return View(property);
            }

            if (property.PropertyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(property);
            }

            var svc = CreatePropertyService();

            if (svc.UpdateProperty(property))
            {
                TempData["SaveResult"] = "Property was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Property could not be updated.");
            return View(property);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProperty(int id)
        {
            var svc = CreatePropertyService();
            svc.DeleteProperty(id);
            TempData["SaveResult"] = "Property was deleted.";
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

        private PropertyService CreatePropertyService()
        {
            var userId = User.Identity.GetUserId();
            var svc = new PropertyService(userId);
            return svc;
        }
    }
}