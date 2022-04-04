using Microsoft.EntityFrameworkCore;
using ZverGram.Db.Entities;

namespace ZverGram.Db.Context
{
    public class MainDbContext: DbContext
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

            modelBuilder.Entity<Exhibition>().ToTable("exhibitions");
            modelBuilder.Entity<Exhibition>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Exhibition>().Property(x => x.Description).HasMaxLength(1000);
            modelBuilder.Entity<Exhibition>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Exhibition>().HasMany(x => x.Categories).WithMany(x => x.Exhibitions).UsingEntity(t => t.ToTable("exhibitions_categories"));

            modelBuilder.Entity<Category>().ToTable("categories");

            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().HasOne(x => x.Exhibition).WithMany(x => x.Comments).HasForeignKey(x => x.ExhibitionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
