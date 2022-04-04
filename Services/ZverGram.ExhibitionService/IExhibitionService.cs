﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZverGram.ExhibitionService.Models;

namespace ZverGram.ExhibitionService
{
    public interface IExhibitionService
    {
        Task<IEnumerable<ExhibitionModel>> GetExhibitions();
        Task<ExhibitionModel> GetExhibition(int id);
        Task<ExhibitionModel> AddExhibition(AddExhibitionModel model);
        Task UpdateExhibition(int id, UpdateExhibitionModel model);

    }
}
