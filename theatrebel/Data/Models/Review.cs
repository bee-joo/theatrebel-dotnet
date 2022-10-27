namespace theatrebel.Data.Models;

public class Review : ModelBase
{
    public string Text { get; set; } = null!;
    public long PlayId { get; set; }
    public Play Play { get; set; } = null!;
}
