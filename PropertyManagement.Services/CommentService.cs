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

        private readonly string id;

        public CommentService(string userId)
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