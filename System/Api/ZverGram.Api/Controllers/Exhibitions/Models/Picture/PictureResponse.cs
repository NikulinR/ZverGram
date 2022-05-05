using AutoMapper;
using ZverGram.Db.Entities;

namespace ZverGram.ExhibitionService.Models
{
    public class PictureResponse
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string? Description { get; set; }
        public char isPrimary { get; set; }
        public int ExhibitionId { get; set; }
        public string Exhibition { get; set; }
        public byte[] Image { get; set; }
    }

    public class PictureResponseProfile : Profile
    {
        public PictureResponseProfile()
        {
            CreateMap<PictureModel, PictureResponse>()
                .ForMember(dest => dest.Exhibition, opt => opt.MapFrom(src => src.Exhibition));
        }
    }
}
