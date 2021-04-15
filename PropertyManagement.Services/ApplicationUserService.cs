using PropertyManagement.Data;
using PropertyManagement.Models.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Services
{
    public class ApplicationUserService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        private readonly string _id;

        public ApplicationUserService(string userId)
        {
            _id = userId;
        }

        // READ
        public IEnumerable<ApplicationUserDetail> GetManagers()
        {
            var query = db.Users.Where(um => um.UserType == UserType.manager)
                .Select(um => new ApplicationUserDetail
                {
                    FirstName = um.FirstName,
                    LastName = um.LastName,
                    UserName = um.UserName,
                    Email = um.Email,
                    PhoneNumber = um.PhoneNumber
                });

            return query.ToArray();
        }

        public IEnumerable<ApplicationUserDetail> GetOwners()
        {
            var query = db.Users.Where(uo => uo.UserType == UserType.owner)
                .Select(uo => new ApplicationUserDetail
                {

                    FirstName = uo.FirstName,
                    LastName = uo.LastName,
                    UserName = uo.UserName,
                    Email = uo.Email,
                    PhoneNumber = uo.PhoneNumber
                });

            return query.ToArray();
        }

        public IEnumerable<ApplicationUserDetail> GetResidents()
        {
            var query = db.Users.Where(ur => ur.UserType == UserType.resident)
                .Select(ur => new ApplicationUserDetail
                {
                    FirstName = ur.FirstName,
                    LastName = ur.LastName,
                    UserName = ur.UserName,
                    Email = ur.Email,
                    PhoneNumber = ur.PhoneNumber
                });

            return query.ToArray();
        }

        // READ BY ID
        public ApplicationUserDetail GetUserById(string id)
        {
            var user = db.Users.Single(u => u.Id == id);
            return new ApplicationUserDetail
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }

        // UPDATE
        public bool UpdateUser(ApplicationUserDetail model)
        {
            var user = db.Users.Single(u => u.Id == model.Id);
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
            };

            return db.SaveChanges() == 1;
        }

        // DELETE
        public bool DeleteUser(string email)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Users.Single(e => e.Email == email);
                db.Users.Remove(entity);
                return db.SaveChanges() == 1;
            }
        }
    }
}