namespace Shop_API.ViewModels
{
    public class BrandVM
    {
        public int? ID { get; set; }
        public string? ThuongHieu { set; get; }
        public bool? TrangThai { set; get; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
