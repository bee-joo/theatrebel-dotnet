using theatrebel.Data.Models;

namespace theatrebel.Data.Views
{
    public class WriterView : EmbeddedWriterView
    {
        public IList<EmbeddedPlayView> Plays { get; set; } = null!;
    }
}
