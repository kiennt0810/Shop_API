using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_API.Entities
{
    [Table("Pro_Color")]
    public class Color
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [StringLength(50)]
        public string MaMau { get; set; }

        [StringLength(2)]
        public bool TrangThai { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
