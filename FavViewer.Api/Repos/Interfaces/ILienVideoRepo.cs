using FavViewer.Api.Models;

namespace FavViewer.Api.Repos.Interfaces
{
    public interface ILienVideoRepo
    {
        IEnumerable<LienVideo> Obtenir();
        bool Ajouter(NouveauLienVideo lienVideo);
        bool Supprimer(int id);
    }
}
