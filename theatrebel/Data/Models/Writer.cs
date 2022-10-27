namespace theatrebel.Data.Models;

public class Writer : ModelBase
{
    public string Name { get; set; } = null!;
    public string? Country { get; set; }
    public IList<Play> Plays { get; set; } = null!;
}
