using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace theatrebel.Data.DTOs
{
    public class ReviewDTO
    {
        [Required]
        public string Text { get; set; } = null!;
        
        public long? PlayId { get; set; }
    }
}
