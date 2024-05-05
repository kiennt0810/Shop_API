using Shop_API.Entities;
using System.Text.Json;

namespace Shop_API.ViewModels
{
    public class ProductVM
    {
        public int? IDColor { get; set; }
        public int? IDBrand { get; set; }
        public int? IDStorage { get; set; }
        public int? ID { get; set; }
        public string? TenSp { get; set; }
        public string? SoLuong { get; set; }
        public string? GiaThanh { get; set; }
        public string? MoTa { get; set; }
        public string? ThuongHieu { get; set; }
        public string? MaMau { get; set; }
        public string? DungLuong { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? ImgUrlHdr { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<string>? ListFile { get; set; }
        public List<ProFileImg>? ListProFile { get; set; }
    }
}
