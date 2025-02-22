using Microsoft.EntityFrameworkCore;

namespace FavViewer.Api.Database
{
    public class FavViewerDbContext(DbContextOptions options) : DbContext(options)
    {
        /// <summary>
        /// Table des liens.
        /// </summary>
        public DbSet<LienVideoDbEntity> Liens { get; set; }

        /// <summary>
        /// Création du modèle (migrations).
        /// </summary>
        /// <param name="modelBuilder">Constructeur de modèle.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LienVideoDbEntity>(entityTypeBuilder =>
            {
                // PK.
                entityTypeBuilder.HasKey(k => k.Id);

                // Champs.
                entityTypeBuilder.Property(k => k.Titre)
                    .IsRequired(false)
                    .HasMaxLength(100);

                entityTypeBuilder.Property(k => k.Url)
                    .IsRequired(true)
                    .HasMaxLength(1000);
            });
        }
    }
}
