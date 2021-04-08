using PropertyManagement.Data;
using PropertyManagement.Models.Replies;
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

        private readonly string _id;

        public ReplyService(string userId)
        {
            _id = userId;
        }

        // CREATE
        public bool ReplyCommentCreate(ReplyCreate model)
        {
            var reply = new Reply()
            {
                CommentId = model.CommentId,
                UserName = db.Users.Single(user => user.Id == _id).UserName,
                Content = model.Content
            };

            db.Replies.Add(reply);
            return db.SaveChanges() == 1;
        }

        // CREATE
        public bool ReplyReviewCreate(ReplyCreate model)
        {
            var reply = new Reply()
            {
                ReviewId = model.ReviewId,
                UserName = db.Users.Single(user => user.Id == _id).UserName,
                Content = model.Content
            };

            db.Replies.Add(reply);
            return db.SaveChanges() == 1;
        }

        // READ
        public IEnumerable<ReplyList> GetCommentReplies()
        {
            var search = db.Replies
                .Select(r => new ReplyList
                {
                    ReplyId = r.ReplyId,
                    Content = r.Content,
                    ReplyCreated = r.ReplyCreated,
                    ReplyEdited = r.ReplyEdited
                });

            return search.ToArray();
        }

        // READ
        public IEnumerable<ReplyList> GetReviewReplies()
        {
            var search = db.Replies
                .Select(r => new ReplyList
                {
                    ReplyId = r.ReplyId,
                    Content = r.Content,
                    ReplyCreated = r.ReplyCreated,
                    ReplyEdited = r.ReplyEdited
                });

            return search.ToArray();
        }

        // READ BY ID
        public ReplyDetail GetCommentRepliesById(int? id)
        {
            var r = db.Replies.Single(review => review.ReplyId == id);
            return new ReplyDetail
            {
                ReplyId = r.ReplyId,
                Content = r.Content,
                ReplyCreated = r.ReplyCreated,
                ReplyEdited = r.ReplyEdited
            };
        }

        // READ BY ID
        public ReplyDetail GetReviewRepliesById(int id)
        {
            var r = db.Replies.Single(review => review.ReplyId == id);
            return new ReplyDetail
            {
                ReplyId = r.ReplyId,
                Content = r.Content,
                ReplyCreated = r.ReplyCreated,
                ReplyEdited = r.ReplyEdited
            };
        }

        // UPDATE
        public bool UpdateReply(ReplyEdit model)
        {
            var r = db.Replies.Single(review => review.ReplyId == model.ReplyId);
            {
                r.Content = model.Content;
            }

            return db.SaveChanges() == 1;
        }

        // DELETE
        public bool DeleteReply(int id)
        {
            var reply = db.Replies.Single(r => r.ReplyId == id);
            db.Replies.Remove(reply);
            return db.SaveChanges() == 1;
        }
    }
}