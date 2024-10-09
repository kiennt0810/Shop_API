using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop_API.Entities
{
    [Table("PRO_Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(Order = 1)]
        public int IdBrand { set; get; }

        [Column(Order = 2)]
        public int IdColor { set; get; }

        [Column(Order = 3)]
        public int IdStorage { set; get; }

        [ForeignKey("IdBrand")]
        public virtual Brand? Pro_Brand { set; get; }

        [ForeignKey("IdColor")]
        public virtual Color? Pro_Color { set; get; }

        [ForeignKey("IdStorage")]
        public virtual StorageCapacities? Pro_Storage { set; get; }

        public string? TenSp {  get; set; }
        public string? SoLuong { get; set; }
        public string? GiaThanh {  get; set; }
        public string? MoTa {  get; set; }
        public string? ThuongHieu { get; set; }
        public string? MaMau { get; set; }
        public string? DungLuong { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? ImgUrlHdr { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
