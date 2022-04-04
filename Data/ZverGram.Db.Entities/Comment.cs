using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZverGram.Db.Entities
{
    public class Comment : BaseEntity
    {
        //todo change to User class
        public int ExhibitionId { get; set; }
        public virtual Exhibition Exhibition { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public DateTime Posted { get; set; }
        public string Content { get; set; }
    }
}
