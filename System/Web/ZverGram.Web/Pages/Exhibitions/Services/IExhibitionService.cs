namespace ZverGram.Web
{
    public interface IExhibitionService
    {
        Task<IEnumerable<ExhibitionListModel>> GetExhibitions(int offset = 0, int limit = 10);
        Task<ExhibitionListModel> GetExhibition(int exhibitionId);
        Task AddExhibition(ExhibitionModel model);
        Task EditExhibition(int exhibitionId, ExhibitionModel model);
        Task DeleteExhibition(int exhibitionId);
        Task<IEnumerable<CategoryModel>> GetCategoriesList();
        Task<IEnumerable<CommentModel>> GetComments(int exhibitionId);
        Task AddComment(AddCommentModel model);
    }
}
