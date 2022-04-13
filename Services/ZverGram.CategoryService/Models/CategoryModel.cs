using AutoMapper;
using ZverGram.Db.Entities;

namespace ZverGram.CategoryService.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }

    public class CategoryRequestProfile : Profile
    {
        public CategoryRequestProfile()
        {
            CreateMap<Category, CategoryModel>();
        }
    }
}
