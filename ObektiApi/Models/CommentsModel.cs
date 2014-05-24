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
                    if (String.IsNullOrEmpty(comment.Comment))
                    {
                        continue;
                    }

                    var commentModel = new CommentModel();
                    commentModel.Comment = comment.Comment.Trim();
                    commentModel.SiteID = comment.SiteID;
                    String username = comment.UserName;
                    if (!String.IsNullOrEmpty(username))
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
                if (String.IsNullOrEmpty(postedComment.Comment))
                {
                    return;
                }
                newComment.UserName = postedComment.UserName;
                newComment.Comment = postedComment.Comment.Trim();
                newComment.SiteID = postedComment.SiteID;
                db.SiteComments.Add(newComment);
                db.SaveChanges();
            }
        }

    }
}