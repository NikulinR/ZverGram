using AutoMapper;
using ZverGram.ExhibitionService.Models;

namespace ZverGram.Api.Controllers.Exhibitions.Models
{
    public class ExhibitionResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ExhibitionResponseProfile: Profile
    {
        public ExhibitionResponseProfile()
        {
            CreateMap<ExhibitionModel, ExhibitionResponse>();
        }
    }
}
