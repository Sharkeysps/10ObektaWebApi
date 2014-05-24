using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObektiApi.Models;

namespace ObektiApi.Controllers
{
    public class CommentController : ApiController
    {
        // GET api/comment/5
        public CommentsModel Get(int id)
        {
            var foundComments = new CommentsModel();
            foundComments.FindComments(id);
            return foundComments;
        }

        // POST api/comment
        public void Post([FromBody]PostCommentModel comment)
        {
            var newComment = new CommentsModel();
            newComment.SaveComment(comment);
        }
    }
}
