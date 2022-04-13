using AutoMapper;
using ZverGram.CategoryService.Models;

namespace ZverGram.Api.Controllers.Categories.Models
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryResponseProfile: Profile
    {
        public CategoryResponseProfile()
        {
            CreateMap<CategoryModel, CategoryResponse>();
        }
    }
}
