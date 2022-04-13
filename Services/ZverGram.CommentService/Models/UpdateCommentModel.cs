﻿using AutoMapper;
using FluentValidation;
using ZverGram.Db.Entities;

namespace ZverGram.CommentService.Models
{
    public class UpdateCommentModel
    {
        public int ExhibitionId { get; set; }
        public Guid AuthorId { get; set; }
        public int Rating { get; set; }
        public DateTime Posted { get; set; }
        public string Content { get; set; } = String.Empty;
    }

    public class UpdateCommentModelValidator : AbstractValidator<UpdateCommentModel>
    {
        public UpdateCommentModelValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Comment should not be empty")
                .MaximumLength(5000).WithMessage("Comment is too long");

            RuleFor(x => x.ExhibitionId)
                .NotEmpty().WithMessage("Can't add comment to unknown exhibition");

            //RuleFor(x => x.AuthorId)
            //    .NotEmpty().WithMessage("Comment should have author");
        }
    }

    public class UpdateCommentRequestProfile : Profile
    {
        public UpdateCommentRequestProfile()
        {
            CreateMap<UpdateCommentModel, Comment>();
        }
    }
}
