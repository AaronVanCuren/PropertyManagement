using PropertyManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Services
{
    public class ReplyService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        private readonly string id;

        public ReplyService(string userId)
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