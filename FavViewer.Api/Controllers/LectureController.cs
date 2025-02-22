using FavViewer.Api.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FavViewer.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LectureController(ILienVideoRepo lienVideoRepo) : ControllerBase
    {
        /// <summary>
        /// Obtenir la redirection de la vidéo.
        /// </summary>
        /// <param name="id">Identifiant de la vidéo.</param>
        /// <returns>Lien url.</returns>
        [HttpGet("{id}")]
        public string? Get([FromRoute] int id) => lienVideoRepo.Obtenir(id);
    }
}
