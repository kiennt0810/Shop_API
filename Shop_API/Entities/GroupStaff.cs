using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_API.Entities
{
    [Table("SYS_GroupStaff")]
    public class GroupStaff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(128)]
        [Column(Order = 1)]
        public int IdNhanVien { set; get; }

        [Column(Order = 2)]
        public int IdNhom { set; get; }

        [ForeignKey("IdNhanVien")]
        public virtual Staff HTNhanVien { set; get; }

        [ForeignKey("IdNhom")]
        public virtual SysGroup HTNhom { set; get; }

        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

}
