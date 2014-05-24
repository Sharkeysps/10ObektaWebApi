using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitesDB;
namespace ObektiApi.Models
{
    public class CommentsModel
    {
        public List<CommentModel> Comments { get; set; }

        public CommentsModel()
        {
            this.Comments = new List<CommentModel>();
        }

        public void FindComments(int siteId)
        {
            using (var db = new SitesEntities())
            {
                var comments = (from c in db.SiteComments
                                where c.SiteID == siteId
                                select c);

                foreach (var comment in comments)
                {
                    var commentModel = new CommentModel();
                    commentModel.Comment = comment.Comment;
                    commentModel.SiteID = comment.SiteID;
                    if (!comment.UserName.Equals(null))
                    {
                        commentModel.UserName = comment.UserName;
                    }
                    else
                    {
                        commentModel.UserName = "Анонимен";
                    }
                    
                    Comments.Add(commentModel);

                }
                
            }

        }

        public void SaveComment(PostCommentModel postedComment)
        {
            using (var db = new SitesEntities())
            {
                SiteComment newComment = new SiteComment();
                newComment.UserName = postedComment.UserName;
                newComment.Comment = postedComment.Comment;
                newComment.SiteID = postedComment.SiteID;
                db.SiteComments.Add(newComment);
                db.SaveChanges();
            }
        }

    }
}