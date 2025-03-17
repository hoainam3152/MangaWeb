using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MangaAPI.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        #region
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<MangaGenres> MangaGenres { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Default configurations for Identity entities, including IdentityUserLogin<string> 
            base.OnModelCreating(modelBuilder);

            //Create unique index for AuthorName
            modelBuilder.Entity<Genre>()
                .HasIndex(e => e.GenreName)
                .IsUnique();

            modelBuilder.Entity<MangaGenres>(entity =>
            {
                //Create PK
                entity.HasKey(e => new { e.MangaId, e.GenreId });

                //Create FK
                entity.HasOne(e => e.Manga)
                    .WithMany(e => e.MangaGenres)
                    .HasForeignKey(e => e.MangaId);

                entity.HasOne(e => e.Genre)
                    .WithMany(e => e.MangaGenres)
                    .HasForeignKey(e => e.GenreId);
            });
        }
    }
}
