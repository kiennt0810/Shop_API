using Shop_API.Entities;

namespace Shop_API.ViewModels
{
    public class GroupStaffVM
    {
        public int? ID { set; get; }
        public int? IdNhanVien { set; get; }
        public int? IdNhom { set; get; }
        public String? MaNhanVien { set; get; }

        public String? TenNhanVien { set; get; }
        public String? MaNhom { set; get; }
        public Staff? HTNhanVien { set; get; }
        public SysGroup? HTNhom { set; get; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
