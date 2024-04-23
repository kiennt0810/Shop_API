using System.ComponentModel.DataAnnotations;

namespace Shop_API.ViewModels
{
    public class StorageVM
    {
        public int? Id { set; get; }
        public string DungLuong { get; set; }
        public bool? TrangThai { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
