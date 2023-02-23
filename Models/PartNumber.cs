using System.ComponentModel.DataAnnotations;

namespace SmartCart_API.Models
{
    public class PartNumber
    {
        [Required,MinLength(12),MaxLength(12)] // TG116402-6680
        public string PartNoSubAssy { get; set; } = null!;

        [Required]
        public int LotId { get; set; }

        [Required, MinLength(19), MaxLength(19)] // 2023-02-16T10:10:10
        public string TimeStamp { get; set; } = null!;

    }
}
