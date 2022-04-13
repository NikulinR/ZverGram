using AutoMapper;
using FluentValidation;
using ZverGram.CommentService.Models;

namespace ZverGram.Api.Controllers.Comments.Models
{
    public class AddCommentRequest
    {
        public int ExhibitionId { get; set; }
        public Guid AuthorId { get; set; }
        public int Rating { get; set; }
        public DateTime Posted { get; set; }
        public string Content { get; set; } = String.Empty;
    }

    public class AddCommentValidator: AbstractValidator<AddCommentRequest>
    {
        public AddCommentValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Comment should not be empty")
                .MaximumLength(5000).WithMessage("Comment is too long");
        }
    }

    public class AddCommentRequestProfile: Profile
    {
        public AddCommentRequestProfile()
        {
            CreateMap<AddCommentRequest, AddCommentModel>();
        }
    }
}
