namespace ZverGram.Web
{
    public class AddCommentModel
    {
        public int ExhibitionId { get; set; }
        public Guid AuthorId { get; set; }
        public int Rating { get; set; }
        public DateTime Posted { get; set; }
        public string Content { get; set; } = String.Empty;
    }
}
