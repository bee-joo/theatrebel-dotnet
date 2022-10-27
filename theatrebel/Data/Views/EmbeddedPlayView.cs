namespace theatrebel.Data.Views
{
    public class EmbeddedPlayView
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Origname { get; set; }
        public int? Date { get; set; }
        public string? Description { get; set; }
        public string? City { get; set; }
    }
}
