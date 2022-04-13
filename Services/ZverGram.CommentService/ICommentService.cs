using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZverGram.CommentService.Models;

namespace ZverGram.CommentService
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentModel>> GetComments(int offset = 0, int limit = 100);
        Task<CommentModel> GetComment(int id);
        Task<CommentModel> AddComment(AddCommentModel model);
        Task UpdateComment(int id, UpdateCommentModel model);
        Task DeleteComment(int id);
    }
}
