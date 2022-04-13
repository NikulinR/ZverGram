using AutoMapper;
using ZverGram.Db.Entities;

namespace ZverGram.CommentService.Models
{
    public class CommentModel
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

    public class CommentRequestProfile : Profile
    {
        public CommentRequestProfile()
        {
            CreateMap<Comment, CommentModel>()
                .ForMember(dest => dest.Exhibition, opt => opt.MapFrom(src => src.Exhibition.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.UserName));
        }
    }
}
