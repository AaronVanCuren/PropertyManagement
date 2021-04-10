using PropertyManagement.Data;
using PropertyManagement.Models.Listings;
using PropertyManagement.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Services
{
    public class ListingService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        private readonly string _id;

        public ListingService(string userId)
        {
            _id = userId;
        }

        //CREATE
        public bool ListingCreate(ListingCreate model)
        {
            var listing = new Listing()
            {
                PropertyId = model.PropertyId
            };

            db.Listings.Add(listing);
            return db.SaveChanges() == 1;
        }

        // READ
        public IEnumerable<ListingList> GetListings()
        {
            var search = db.Listings
                .Select(
                li => new ListingList
                {
                    PropertyId = db.Properties.Where(p => p.PropertyId == li.PropertyId)
                    .Select(p => new PropertyList
                    {
                        PropertyId = p.PropertyId,
                        Address = p.Address,
                    })
                });

            return search.ToArray();
        }

        // READ BY ID
        public ListingDetail GetListingById(int id)
        {
            var li = db.Listings.Single(listing => listing.PropertyId == id);
            return new ListingDetail
            {
                PropertyId = db.Properties.Where(p => p.PropertyId == li.PropertyId)
                .Select(p => new PropertyDetail
                {
                    Address = p.Address,
                    PropTy = p.PropTy,
                    IsAHP = p.IsAHP,
                    Status = p.Status,
                    Description = p.Description,
                    Bedroom = p.Bedroom,
                    Bathroom = p.Bathroom,
                    SqFt = p.SqFt,
                    Rent = p.Rent,
                    AppFee = p.AppFee,
                    SD = p.SD,
                    NSFee = p.NSFee,
                    Utilities = p.Utilities,
                    Appliances = p.Appliances,
                    Cat = p.Cat,
                    Dog = p.Dog,
                    Amenities = p.Amenities
                })
            };
        }

        // UPDATE BY UPDATING PROPERTY

        // DELETE
        public bool DeleteListing(int id)
        {
            var listing = db.Listings.Single(li => li.PropertyId == id);
            db.Listings.Remove(listing);
            return db.SaveChanges() == 1;
        }
    }
}