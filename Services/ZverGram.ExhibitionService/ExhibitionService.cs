using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZverGram.ExhibitionService.Models;

namespace ZverGram.ExhibitionService
{
    internal class ExhibitionService : IExhibitionService
    {
        public async Task<IEnumerable<ExhibitionModel>> GetExhibitions()
        {
            return new List<ExhibitionModel>()
            {
                new ExhibitionModel() { Id = 1, Name = "Heh"},
                new ExhibitionModel() { Id = 2, Name ="Ha", Description="hoho"}
            };
        }

        public async Task<ExhibitionModel> GetExhibition(int id)
        {
            return new ExhibitionModel() { Id = id, Name = "Ha", Description = "hoho" };
        }

        public async Task<ExhibitionModel> AddExhibition(AddExhibitionModel model)
        {
            return new ExhibitionModel() { Id = 1, Name = "Ha", Description = "hoho" };
        }

        public async Task UpdateExhibition(int id, UpdateExhibitionModel model)
        {
           // throw new NotImplementedException();
        }
    }
}
