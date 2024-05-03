using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_API.Entities
{
    [Table("PRO_FileImg")]
    public class ProFileImg
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [StringLength(500)]

        [Column(Order = 1)]
        public int IdProduct { set; get; }

        [ForeignKey("IdProduct")]
        public virtual Product PRO_Product { set; get; }
        public string? ImgUrl { get; set; }
    }
}
