using System.ComponentModel.DataAnnotations;

namespace theatrebel.Data.DTOs
{
    public class WriterDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? Country { get; set; }
    }
}
