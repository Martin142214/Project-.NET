using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface ICommentRepository
    {
        Comments GetComment(int id);
        IEnumerable<Comments> GetAllComments();

        Comments Add(Comments comment);

        Comments Edit(Comments commentChanges);
        Comments Delete(int id);
    }
}
