using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZverGram.Common.Exceptions;
using ZverGram.Common.Validator;
using ZverGram.Db.Context;
using ZverGram.Db.Entities;
using ZverGram.CommentService.Models;

namespace ZverGram.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<AddCommentModel> addValidator;
        private readonly IModelValidator<UpdateCommentModel> updateValidator;

        public CommentService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper, IModelValidator<AddCommentModel> addValidator, IModelValidator<UpdateCommentModel> updateValidator)
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.addValidator = addValidator;
            this.updateValidator = updateValidator;
        }

        public async Task<IEnumerable<CommentModel>> GetComments(int offset = 0, int limit = 100)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var comments = context.Comments.Include(x => x.Author)
                                           .Include(x => x.Exhibition).AsQueryable();

            comments = comments.Skip(Math.Max(offset, 0)).Take(Math.Min(limit, 1000));

            var data = (await comments.ToListAsync()).Select(Comment => mapper.Map<CommentModel>(Comment));

            return data;
        }

        public async Task<CommentModel> GetComment(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var Comment = await context.Comments.Include(x => x.Author)
                                                .Include(x => x.Exhibition).AsQueryable().FirstOrDefaultAsync(x => x.Id.Equals(id));
            var data = mapper.Map<CommentModel>(Comment);

            return data;
        }

        public async Task<CommentModel> AddComment(AddCommentModel model)
        {
            addValidator.Check(model);
            using var context = await contextFactory.CreateDbContextAsync();

            var Comment = mapper.Map<Comment>(model);
            await context.Comments.AddAsync(Comment);
            context.SaveChanges();

            return mapper.Map<CommentModel>(Comment);
        }

        public async Task UpdateComment(int id, UpdateCommentModel model)
        {
            updateValidator.Check(model);
            using var context = await contextFactory.CreateDbContextAsync();

            var Comment = context.Comments.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new dbException($"Not found Comment with id = {id}");
            Comment = mapper.Map(model, Comment);
            
            context.Comments.Update(Comment);
            context.SaveChanges();
        }

        public async Task DeleteComment(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var Comment = context.Comments.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new dbException($"Not found Comment with id = {id}");
            
            context.Remove(Comment);
            context.SaveChanges();
        }
    }
}
