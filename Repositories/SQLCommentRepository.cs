using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class SQLCommentRepository : ICommentRepository
    {
        private readonly AppDbContext context;
        public SQLCommentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Comments> GetAllComments()
        {
            return context.Comments;
        }

        public Comments GetComment(int id)
        {
            return context.Comments.Find(id);
        }

        public Comments Add(Comments comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
            return comment;
        }

        public Comments Delete(int id)
        {
            Comments comment = context.Comments.Find(id);
            if (comment != null)
            {
                context.Comments.Remove(comment);
                context.SaveChanges();
            }
            return comment;
        }

        public Comments Edit(Comments commentChanges)
        {
            var comment = context.Comments.Attach(commentChanges);
            comment.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return commentChanges;
        }

    }
}

