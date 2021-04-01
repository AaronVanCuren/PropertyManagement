using PropertyManagement.Data;
using PropertyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Services
{
    public class VendorService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        private readonly string _id;

        public VendorService(string userId)
        {
            _id = userId;
        }

        // CREATE
        public bool VendorCreate (VendorCreate model)
        {
            var vendor = new Vendor()
            {
                VendorName = model.VendorName,
                Description = model.Description,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            db.Vendors.Add(vendor);
            return db.SaveChanges() == 1;
        }

        // READ
        public IEnumerable<VendorList> GetVendors()
        {
            var search = db.Vendors
                .Select(v => new VendorList
                {
                    VendorName = v.VendorName,
                    Description = v.Description,
                });

            return search.ToArray();
        }

        // READ BY ID
        public VendorDetail GetVendorById(int id)
        {
            var v = db.Vendors.Single(vendor => vendor.VendorId == id);
            return new VendorDetail
            {
                VendorName = v.VendorName,
                Description = v.Description,
                Reviews = db.VendorReviews.Where(r => r.VendorId == v.VendorId)
                    .Select(r => new ReviewList
                    {
                        FirstName = r.FirstName,
                        Title = r.Title,
                        ReviewCreated = r.ReviewCreated,
                        ReviewEdited = r.ReviewEdited
                    })
            };
        }

        // UPDATE
        public bool UpdateVendor(VendorEdit model)
        {
            var v = db.Vendors.Single(vendor => vendor.VendorId == model.VendorId);
            {
                v.VendorName = model.VendorName;
                v.Description = model.Description;
                v.Email = model.Email;
                v.PhoneNumber = model.PhoneNumber;
            }

            return db.SaveChanges() == 1;
        }

        // DELETE
        public bool DeleteVendor(int id)
        {
            var vendor = db.Vendors.Single(v => v.VendorId == id);
            db.Vendors.Remove(vendor);
            return db.SaveChanges() == 1;
        }
    }
}