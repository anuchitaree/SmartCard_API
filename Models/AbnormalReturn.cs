using System.ComponentModel.DataAnnotations;

namespace SmartCard_API.Models
{
    public class AbnormalReturn
    {
        [Required] // TG116402-6680 control 12 charactor
        public string PartNoSubAssy { get; set; } = null!;

        [Required]
        public long LotId { get; set; }

        [Required] // 2023-02-16T10:10:10 control 19 charactor
        public string Detail { get; set; } = null!;

       
    }
}
