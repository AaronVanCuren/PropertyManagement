using PropertyManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Services
{
    public class ReviewService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        private readonly string id;

        public ReviewService(string userId)
        {
            id = userId;
        }

        // CREATE
        // READ
        // READ BY ID
        // UPDATE
        // DELETE
    }
}