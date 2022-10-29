using System.ComponentModel.DataAnnotations;

namespace theatrebel.Data.DTOs
{
    public class PlayDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;
        public List<long> WriterIds { get; set; } = new List<long>();
        public string? Origname { get; set; }
        public int? Date { get; set; }
        public string? Description { get; set; }
        public string? Text { get; set; }
    }
}
