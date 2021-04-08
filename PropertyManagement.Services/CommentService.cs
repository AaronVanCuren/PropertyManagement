using PropertyManagement.Data;
using PropertyManagement.Models.Comments;
using PropertyManagement.Models.Replies;
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
        public bool CommentCreate(CommentCreate model)
        {
            var comment = new Comment()
            {
                ListingId = model.ListingId,
                Content = model.Content,
            };
            db.Comments.Add(comment);
            return db.SaveChanges() == 1;
        }

        // READ
        public IEnumerable<CommentList> GetComments()
        {
            var search = db.Comments
                .Select(c => new CommentList
                {
                    Content = c.Content,
                    CommentCreated = c.CommentCreated,
                    CommentEdited = c.CommentEdited
                });

            return search.ToArray();
        }

        // READ BY ID
        public CommentDetail GetCommentById(int id)
        {
            var c = db.Comments.Single(comment => comment.CommentId == id);
            return new CommentDetail
            {
                ListingId = c.ListingId,
                Content = c.Content,
                CommentCreated = c.CommentCreated,
                CommentEdited = c.CommentEdited,
                Replies = db.Replies.Where(r => r.CommentId == c.CommentId)
                    .Select(r => new ReplyList
                    {
                        ReplyId = r.ReplyId,
                        Content = r.Content,
                        ReplyCreated = r.ReplyCreated,
                        ReplyEdited = r.ReplyEdited
                    })
            };
        }

        // UPDATE
        public bool UpdateComment(CommentEdit model)
        {
            var c = db.Comments.Single(comment => comment.CommentId == model.CommentId);
            {
                c.Content = model.Content;
            }

            return db.SaveChanges() == 1;
        }

        // DELETE
        public bool DeleteComment(int id)
        {
            var comment = db.Comments.Single(c => c.CommentId == id);
            db.Comments.Remove(comment);
            return db.SaveChanges() == 1;
        }
    }
}