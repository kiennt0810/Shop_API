using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop_API.Entities
{
    [Table("SYS_Role")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(Order = 1)]
        public int IdNhom { set; get; }

        [Column(Order = 2)]
        [StringLength(50)]
        public string IdCn { set; get; }

        [ForeignKey("IdCn")]
        public virtual SysFunction HTChucNang { set; get; }

        [ForeignKey("IdNhom")]
        public virtual SysGroup HTNhom { set; get; }

        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
