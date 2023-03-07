using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCard_API.Models
{
    public class SmartCard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }


        [Required, StringLength(20)]
        public string Partnumber { get; set; } = null!;

        [StringLength(13)]
        public string Partname0 { get; set; } = null!;

        [StringLength(8)]
        public string Partname1 { get; set; } = null!;

        [StringLength(8)]
        public string Partname2 { get; set; } = null!;

        [StringLength(8)]
        public string Partname3 { get; set; } = null!;
    }
}
