using System.ComponentModel;

namespace theatrebel.Data.Parameters
{
    public class PlayParameters : Parameters
    {
        public string? Name { get; set; }
        public bool? HasText { get; set; }

        [DefaultValue("Name")]
        public new string? OrderBy { get; set; } = "Name";
    }
}
