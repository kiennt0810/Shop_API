using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_API.Entities
{
    [Table("PRO_Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [StringLength(50)]
        public string? HoTen { set; get; }

        public DateTime? NgaySinh { set; get; }
        public string? DiaChi { set; get; }
        public string? DienThoai { set; get; }
        public string? Email { set; get; }
        public string? UserName { set; get; }
        public string? MatKhau { set; get; }
        public bool? GioiTinh { set; get; }
        public bool? TrangThai { set; get; }
    }
}
