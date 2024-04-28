using System.ComponentModel.DataAnnotations;

namespace Shop_API.ViewModels
{
    public class CustomerVM
    {
        public int ID { set; get; }
        public string? HoTen { set; get; }
        public DateTime? NgaySinh { set; get; }
        public string? DiaChi { set; get; }
        public string? DienThoai { set; get; }
        public string? Email { set; get; }
        public string? UserName { set; get; }
        public string? MatKhau { set; get; }
        public bool? GioiTinh { set; get; }
        public bool? TrangThai { set; get; }
    }
}
