using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop_API.Entities
{
    [Table("SYS_Staff")]
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [StringLength(50)]
        public string? MaNhanVien { set; get; }
        [Required]
        [StringLength(50)]
        public string? MatKhau { set; get; }

        [StringLength(200)]
        public string? ChucDanh { get; set; }

        [StringLength(300)]
        public string? HoTen { get; set; }

        [StringLength(200)]
        public string? Email { get; set; }
        public DateTime? NgaySinh { get; set; }
        public bool? GioiTinh { get; set; }

        public int? CountLoginFail { get; set; }
        public bool? TinhTrang { get; set; }
        //public bool? IsLock { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
