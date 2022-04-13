using AutoMapper;
using ZverGram.CommentService.Models;

namespace ZverGram.Api.Controllers.Comments.Models
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public int ExhibitionId { get; set; }
        public string Exhibition { get; set; } = String.Empty;
        public Guid AuthorId { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public DateTime Posted { get; set; }
        public string Content { get; set; } = String.Empty;
    }

    public class CommentResponseProfile: Profile
    {
        public CommentResponseProfile()
        {
            CreateMap<CommentModel, CommentResponse>();
        }
    }
}
