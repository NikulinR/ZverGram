﻿using AutoMapper;

namespace ZverGram.ExhibitionService.Models
{
    public class ExhibitionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    //public class ExhibitionRequestProfile : Profile
    //{
    //    public ExhibitionRequestProfile()
    //    {
    //        CreateMap<ExhibitionResponse, ExhibitionModel> ();
    //    }
    //}
}