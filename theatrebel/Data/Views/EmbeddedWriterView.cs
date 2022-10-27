using theatrebel.Data.Models;

namespace theatrebel.Data.Views
{
    public class EmbeddedWriterView
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Country { get; set; }
    }
}
