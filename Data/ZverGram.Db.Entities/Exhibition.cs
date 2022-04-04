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

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
