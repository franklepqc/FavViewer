using AutoMapper;
using FavViewer.Api.Database;
using FavViewer.Api.Mappings;
using FavViewer.Api.Models;
using FavViewer.Api.Repos.Interfaces;

namespace FavViewer.Api.Repos
{
    public class LienVideoRepo(FavViewerDbContext dbContext, ILogger<LienVideoRepo>? logger) : ILienVideoRepo
    {
        /// <summary>
        /// Système de mapping.
        /// </summary>
        private readonly Mapper _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<LienMappings>()));

        /// <summary>
        /// Ajouter le lien.
        /// </summary>
        /// <param name="lienVideo">Lien vidéo.</param>
        /// <returns>Vrai si l'opération est une réussite, faux sinon.</returns>
        public bool Ajouter(NouveauLienVideo lienVideo)
        {
            try
            {
                // Nouvelle entité.
                var nouveauLienDb = _mapper.Map<LienVideoDbEntity>(lienVideo);

                // Ajout.
                dbContext.Liens.Add(nouveauLienDb);

                // Sauvegarde.
                dbContext.SaveChanges();

                // Message.
                logger?.LogInformation("Lien #{Id} ajouté!", nouveauLienDb);

                // Retour.
                return true;
            }
            catch (Exception exception)
            {
                logger?.LogError(exception, "Erreur lors de l'ajout du lien.");
            }

            return false;
        }

        /// <summary>
        /// Obtenir tous les liens.
        /// </summary>
        /// <returns>Liste.</returns>
        public IEnumerable<LienVideo> Obtenir() => dbContext.Liens.ToList().Select(_mapper.Map<LienVideo>);

        /// <summary>
        /// Supprimer le lien.
        /// </summary>
        /// <param name="id">Identifiant.</param>
        /// <returns>Vrai si l'opération est une réussite, faux sinon.</returns>
        public bool Supprimer(int id)
        {
            try
            {
                // Entite.
                var entiteDb = dbContext.Liens.Find(id) ?? throw new Exception("Lien non trouvé.");

                // Ajout.
                dbContext.Liens.Remove(entiteDb);

                // Sauvegarde.
                dbContext.SaveChanges();

                // Message.
                logger?.LogInformation("Lien #{Id} retiré!", id);

                // Retour.
                return true;
            }
            catch (Exception exception)
            {
                logger?.LogError(exception, "Erreur lors de la suppression du lien.");
            }

            return false;
        }
    }
}
