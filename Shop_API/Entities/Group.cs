using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop_API.Entities
{
    [Table("SYS_Group")]
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [StringLength(50)]
        public string MaNhom { set; get; }

        [StringLength(250)]
        public string Ten { set; get; }

        public bool? TinhTrang { set; get; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
