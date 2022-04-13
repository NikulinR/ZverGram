namespace ZverGram.Db.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Exhibition> Exhibitions { get; set; }
    }
}
