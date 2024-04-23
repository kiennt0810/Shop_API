using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_API.Entities
{
    [Table("SYS_Function")]
    public class Function
    {
        [StringLength(50)]
        [Key]
        public string MaCN { set; get; }

        [StringLength(250)]
        public string Ten { get; set; }

        [StringLength(50)]
        public string? MaMenu { get; set; }

        [StringLength(2)]
        public string? TrangThai { get; set; }
    }
}
