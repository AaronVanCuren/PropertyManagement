using PropertyManagement.Data;
using PropertyManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace PropertyManagement.Services
{
    public class PropertyService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        private readonly string id;

        public PropertyService(string userId)
        {
            id = userId;
        }


        //CREATE
        public bool PropertyCreate (PropertyCreate model)
        {
            var property = new Property()
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
                Utilities = model.Utilities,
                Appliances = model.Appliances,
                Cat = model.Cat,
                Dog = model.Dog,
                Amenities = model.Amenities
            };

            db.Properties.Add(property);
            return db.SaveChanges() == 1;
        }

        // READ
        public IEnumerable<PropertyList> GetProperties()
        {
            var search = db.Properties
                .Select(
                p => new PropertyList
                {
                    PropertyId = p.PropertyId,
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
                });

            return search.ToArray();
        }

        // READ BY ID
        public PropertyDetail GetPropertyById(int id)
        {
            var p = db.Properties.Single(property => property.PropertyId == id);
            return new PropertyDetail
                {
                    PropertyId = p.PropertyId,
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
                };
        }

        // UPDATE
        public bool UpdateProperty(PropertyEdit model)
        {
            var p = db.Properties.Single(property => property.PropertyId == model.PropertyId);

            p.Address = model.Address;
            p.PropTy = model.PropTy;
            p.IsAHP = model.IsAHP;
            p.Status = model.Status;
            p.Description = model.Description;
            p.Bedroom = model.Bedroom;
            p.Bathroom = model.Bathroom;
            p.SqFt = model.SqFt;
            p.Rent = model.Rent;
            p.AppFee = model.AppFee;
            p.SD = model.SD;
            p.NSFee = model.NSFee;
            p.Utilities = model.Utilities;
            p.Appliances = model.Appliances;
            p.Cat = model.Cat;
            p.Dog = model.Dog;
            p.Amenities = model.Amenities;

            return db.SaveChanges() == 1;
        }

        // DELETE
        public bool DeleteProperty(int id)
        {
            var property = db.Properties.Single(p => p.PropertyId == id);
            db.Properties.Remove(property);
            return db.SaveChanges() == 1;
        }
    }
}