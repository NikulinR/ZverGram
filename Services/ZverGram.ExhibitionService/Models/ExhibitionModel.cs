using AutoMapper;
using ZverGram.Db.Entities;

namespace ZverGram.ExhibitionService.Models
{
    public class ExhibitionModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; } = String.Empty;
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ExhibitionRequestProfile : Profile
    {
        public ExhibitionRequestProfile()
        {
            CreateMap<Exhibition, ExhibitionModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
