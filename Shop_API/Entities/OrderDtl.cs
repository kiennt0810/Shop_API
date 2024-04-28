using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_API.Entities
{
    [Table("PRO_OrderDtl")]
    public class OrderDtl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [StringLength(50)]

        [Column(Order = 1)]
        public int IdOrderHdr { set; get; }

        [Column(Order = 2)]
        public int IdProduct { set; get; }

        [ForeignKey("IdOrderHdr")]
        public virtual OrderHdr PRO_OrderHdr { set; get; }

        [ForeignKey("IdProduct")]
        public virtual Product PRO_Product { set; get; }

        public string? TenSp { set; get; }
        public string? SoTien { set; get; }
    }
}
