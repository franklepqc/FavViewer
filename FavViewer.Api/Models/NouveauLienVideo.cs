namespace FavViewer.Api.Models
{
    public record NouveauLienVideo
    {
        public string? Titre { get; set; }
        public required string Url { get; set; }
    }
}
