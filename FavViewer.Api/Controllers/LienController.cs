using FavViewer.Api.Models;
using FavViewer.Api.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FavViewer.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LienController(ILienVideoRepo lienVideoRepo) : ControllerBase
    {
        /// <summary>
        /// Obtenir tous les liens.
        /// </summary>
        /// <returns>Liste des liens.</returns>
        [HttpGet]
        public IEnumerable<LienVideo> Get() => lienVideoRepo.Obtenir();

        /// <summary>
        /// Ajouter un lien.
        /// </summary>
        /// <param name="lien">Lien à ajouter.</param>
        /// <returns>Code HTTP.</returns>
        [HttpPost]
        public IActionResult Post(NouveauLienVideo lien) => lienVideoRepo.Ajouter(lien) ? Ok() : Conflict();

        /// <summary>
        /// Supprimer un lien.
        /// </summary>
        /// <param name="id">Identifiant.</param>
        /// <returns>Code HTTP.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id) => lienVideoRepo.Supprimer(id) ? Ok() : Conflict();
    }
}
