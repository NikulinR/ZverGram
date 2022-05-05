using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZverGram.Db.Entities
{
    public class Picture: BaseEntity
    {
        public string Filename { get; set; }
        public string? Description { get; set; }
        public char isPrimary { get; set; }
        public int ExhibitionId { get; set; }
        public virtual Exhibition Exhibition { get; set; }
        public byte[] Image { get; set; }
    }
}
