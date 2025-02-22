namespace FavViewer.Api.Database
{
    public record LienVideoDbEntity
    {
        public required int Id { get; set; }
        public string? Titre { get; set; }
        public required string Url { get; set; }
    }
}
