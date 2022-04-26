using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZverGram.Db.Entities
{
    public class Exhibition: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; } 

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
