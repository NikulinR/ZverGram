using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZverGram.Common.Exceptions;
using ZverGram.Common.Validator;
using ZverGram.Db.Context;
using ZverGram.Db.Entities;
using ZverGram.CategoryService.Models;

namespace ZverGram.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<AddCategoryModel> addValidator;
        private readonly IModelValidator<UpdateCategoryModel> updateValidator;

        public CategoryService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper, IModelValidator<AddCategoryModel> addValidator, IModelValidator<UpdateCategoryModel> updateValidator)
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.addValidator = addValidator;
            this.updateValidator = updateValidator;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories(int offset = 0, int limit = 100)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var Categories = context.Categories.AsQueryable();
            Categories = Categories.Skip(Math.Max(offset, 0)).Take(Math.Min(limit, 1000));

            var data = (await Categories.ToListAsync()).Select(Category => mapper.Map<CategoryModel>(Category));

            return data;
        }

        public async Task<CategoryModel> GetCategory(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var Category = await context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(id));
            var data = mapper.Map<CategoryModel>(Category);

            return data;
        }

        public async Task<CategoryModel> AddCategory(AddCategoryModel model)
        {
            addValidator.Check(model);
            using var context = await contextFactory.CreateDbContextAsync();

            var Category = mapper.Map<Category>(model);
            await context.Categories.AddAsync(Category);
            context.SaveChanges();

            return mapper.Map<CategoryModel>(Category);
        }

        public async Task UpdateCategory(int id, UpdateCategoryModel model)
        {
            updateValidator.Check(model);
            using var context = await contextFactory.CreateDbContextAsync();

            var Category = context.Categories.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new dbException($"Not found Category with id = {id}");
            Category = mapper.Map(model, Category);
            
            context.Categories.Update(Category);
            context.SaveChanges();
        }

        public async Task DeleteCategory(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var Category = context.Categories.FirstOrDefault(x => x.Id.Equals(id)) ?? throw new dbException($"Not found Category with id = {id}");
            
            context.Categories.Remove(Category);
            context.SaveChanges();
        }
    }
}
