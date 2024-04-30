using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop_API.Entities
{
    [Table("Ad_File")]
    public class AdFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [StringLength(500)]
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        [StringLength(50)]
        public String? ContentType { set; get; }


    }
}
