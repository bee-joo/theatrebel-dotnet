using theatrebel.Data.Models;

namespace theatrebel.Data.Views
{
    public class PlayView : EmbeddedPlayView
    {
        public IList<EmbeddedWriterView> Writers { get; set; } = null!;
        public IList<ReviewView> Reviews { get; set; } = null!;
    }
}
