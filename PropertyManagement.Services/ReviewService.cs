using PropertyManagement.Data;
using PropertyManagement.Models;
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

        private readonly string _id;

        public ReviewService(string userId)
        {
            _id = userId;
        }

        // CREATE
        public bool ReviewCompanyCreate(ReviewCreate model)
        {
            var review = new Review()
            {
                FirstName = model.FirstName,
                Title = model.Title,
                Content = model.Content,
            };

            db.Reviews.Add(review);
            return db.SaveChanges() == 1;
        }

        // CREATE
        public bool ReviewVendorCreate(ReviewCreate model)
        {
            var review = new Review()
            {
                VendorId = model.VendorId,
                FirstName = model.FirstName,
                Title = model.Title,
                Content = model.Content,
            };

            db.Reviews.Add(review);
            return db.SaveChanges() == 1;
        }

        // READ
        public IEnumerable<ReviewList> GetCompanyReviews()
        {
            var search = db.Reviews.Where(r => r.VendorId == null)
                .Select(r => new ReviewList
                {
                    FirstName = r.FirstName,
                    Title = r.Title,
                    Content = r.Content,
                    ReviewCreated = r.ReviewCreated,
                    ReviewEdited = r.ReviewEdited
                });

            return search.ToArray();
        }

        // READ
        public IEnumerable<ReviewList> GetVendorReviews()
        {
            var search = db.Reviews.Where(r => r.VendorId != null)
                .Select(r => new ReviewList
                {
                    VendorName = db.Vendors
                        .Select(v => new VendorList
                        { VendorName = v.VendorName }),
                    FirstName = r.FirstName,
                    Title = r.Title,
                    Content = r.Content,
                    ReviewCreated = r.ReviewCreated,
                    ReviewEdited = r.ReviewEdited
                });

            return search.ToArray();
        }

        // READ BY ID
        public ReviewDetail GetCompanyReviewsById(int id)
        {
            var r = db.Reviews.Single(review => review.ReviewId == id);
            return new ReviewDetail
            {
                ReviewId = r.ReviewId,
                Title = r.Title,
                Content = r.Content,
                ReviewCreated = r.ReviewCreated,
                ReviewEdited = r.ReviewEdited
            };
        }

        // READ BY ID
        public ReviewDetail GetVendorReviewsById(int id)
        {
            var r = db.Reviews.Single(review => review.ReviewId == id);
            return new ReviewDetail
            {
                ReviewId = r.ReviewId,
                VendorName = db.Vendors
                    .Select(v => new VendorList
                    { VendorName = v.VendorName }),
                Title = r.Title,
                Content = r.Content,
                ReviewCreated = r.ReviewCreated,
                ReviewEdited = r.ReviewEdited
            };
        }

        // UPDATE
        public bool UpdateReview(ReviewEdit model)
        {
            var r = db.Reviews.Single(review => review.ReviewId == model.ReviewId && review.UserId == _id);
            {
                r.Title = model.Title;
                r.Content = model.Content;
            }

            return db.SaveChanges() == 1;
        }

        // DELETE
        public bool DeleteReview(int id)
        {
            var review = db.Reviews.Single(r => r.ReviewId == id && r.UserId == _id);
            db.Reviews.Remove(review);
            return db.SaveChanges() == 1;
        }
    }
}