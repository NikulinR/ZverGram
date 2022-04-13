
namespace ZverGram.Db.Entities
{
    public class Comment : BaseEntity
    {
        public int? ExhibitionId { get; set; }
        public virtual Exhibition Exhibition { get; set; }
        public Guid AuthorId { get; set; }
        public virtual User Author { get; set; }
        public int Rating { get; set; }
        public DateTime Posted { get; set; }
        public string Content { get; set; }
    }
}
