using AutoMapper;
using ZverGram.ExhibitionService.Models;

namespace ZverGram.Api.Controllers.Exhibitions.Models
{
    public class ExhibitionResponse
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ExhibitionResponseProfile: Profile
    {
        public ExhibitionResponseProfile()
        {
            CreateMap<ExhibitionModel, ExhibitionResponse>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
        }
    }
}
