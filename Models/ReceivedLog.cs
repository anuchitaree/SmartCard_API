using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCard_API.Models
{
    public class ReceivedLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

               
        [Required] // TG116402-6680 control 12 charactor
        public string PartNoSubAssy { get; set; } = null!;


        [Required]
        public long LotId { get; set; }


        [Required] // 2023-02-16T10:10:10 control 19 charactor
        public string TimeStamp { get; set; } = null!;


        [Required]
        public bool StockReceived { get; set; } = false;


        public bool StockSent { get; set; } = false;

    }
}
