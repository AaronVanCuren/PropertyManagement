using PropertyManagement.Data;
using PropertyManagement.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.Models.Listings
{
    public class ListingDetail
    {
        public int ListingId { get; set; }

        public IQueryable PropertyId { get; set; }
    }
}