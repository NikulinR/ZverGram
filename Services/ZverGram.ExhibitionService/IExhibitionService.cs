using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZverGram.CommentService.Models;
using ZverGram.ExhibitionService.Models;

namespace ZverGram.ExhibitionService
{
    public interface IExhibitionService
    {
        Task<IEnumerable<ExhibitionModel>> GetExhibitions(int offset = 0, int limit = 100);
        Task<ExhibitionModel> GetExhibition(int id);
        Task<ExhibitionModel> AddExhibition(AddExhibitionModel model);
        Task UpdateExhibition(int id, UpdateExhibitionModel model);
        Task DeleteExhibition(int id);
        Task<IEnumerable<CommentModel>> GetComments(int exhibitionId, int offset = 0, int limit = 100);
        Task<PictureModel> AddPicture(AddPictureModel model);
        Task<IEnumerable<PictureModel>> GetPictures(int exhibitionId, int offset = 0, int limit = 100);
        Task<PictureModel> GetPrimaryPicture(int exhibitionId);
    }
}
