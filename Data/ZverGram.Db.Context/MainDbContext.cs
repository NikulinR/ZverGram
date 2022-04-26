using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZverGram.Db.Entities;

namespace ZverGram.Db.Context
{
    public class MainDbContext: IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("user_roles");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");

            modelBuilder.Entity<Exhibition>().ToTable("exhibitions");
            modelBuilder.Entity<Exhibition>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Exhibition>().Property(x => x.Description).HasMaxLength(1000);
            modelBuilder.Entity<Exhibition>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Exhibition>().HasOne(x => x.Category).WithMany(x => x.Exhibitions).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().ToTable("categories");

            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().HasOne(x => x.Exhibition).WithMany(x => x.Comments).HasForeignKey(x => x.ExhibitionId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Comment>().HasOne(x => x.Author).WithMany(x => x.Comments).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
