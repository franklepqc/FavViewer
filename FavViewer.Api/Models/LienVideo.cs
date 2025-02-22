namespace FavViewer.Api.Models
{
    public record LienVideo
    {
        public required int Id { get; set; }
        public string? Titre { get; set; }
        public required string Url { get; set; }
    }
}
