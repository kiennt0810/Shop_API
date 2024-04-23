using Shop_API.Entities;

namespace Shop_API.ViewModels
{
    public class ProductVM
    {
        public int? IDColor { get; set; }
        public int? IDBrand { get; set; }
        public int? IDStorage { get; set; }
        public string? JsonBrand { get; set; }
        public string? JsonStorage { get; set; }
        public string? JsonColor { get; set; }
        public int? ID { get; set; }
        public string? TenSp { get; set; }
        public string? SoLuong { get; set; }
        public string? GiaThanh { get; set; }
        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
