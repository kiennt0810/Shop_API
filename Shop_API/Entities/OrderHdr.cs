using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_API.Entities
{
    [Table("PRO_OrderHdr")]
    public class OrderHdr
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Column(Order = 1)]
        public int IdCustomer { set; get; }

        [ForeignKey("IdCustomer")]
        public virtual Customer? PRO_Customer { set; get; }

        public DateTime? NgayTao { set; get; }
        public string? TongTien { set; get; }
        public string? HinhThuc { set; get; }
        public string? TrangThai { set; get; }
    }
}
