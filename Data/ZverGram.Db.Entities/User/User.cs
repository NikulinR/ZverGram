using Microsoft.AspNetCore.Identity;

namespace ZverGram.Db.Entities
{
    public class User: IdentityUser<Guid>
    {
        public UserStatus Status { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
