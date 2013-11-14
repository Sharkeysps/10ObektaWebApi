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
        // GET api/comment
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

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

        //// PUT api/comment/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/comment/5
        //public void Delete(int id)
        //{
        //}
    }
}
