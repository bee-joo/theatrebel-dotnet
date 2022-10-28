namespace theatrebel.Data.Models;

public class Play : ModelBase
{
    public string Name { get; set; } = null!;
    public string? Origname { get; set; }
    public int? Date { get; set; }
    public string? Description { get; set; }
    public string? City { get; set; }
    public string? Text { get; set; }

    public bool HasText { get; set; } = false;

    public IList<Writer> Writers { get; set; } = null!;
    public IList<Review> Reviews { get; set; } = null!;
}
