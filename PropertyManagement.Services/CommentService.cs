using PropertyManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Services
{
    public class CommentService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        private readonly string _id;

        public CommentService(string userId)
        {
            _id = userId;
        }

        // CREATE
        // READ
        // READ BY ID
        // UPDATE
        // DELETE
    }
}