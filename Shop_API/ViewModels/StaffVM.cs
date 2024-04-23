using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shop_API.Entities;
using AutoMapper;

namespace Shop_API.ViewModels
{
    public class StaffVM
    {
        public int ID { set; get; }
        public string MaNhanVien { set; get; }

        public string MatKhau { set; get; }

        public string? ChucDanh { get; set; }

        public string HoTen { get; set; }

        public string? Email { get; set; }
        public DateTime? NgaySinh { get; set; }
        public bool? GioiTinh { get; set; }

        public int? CountLoginFail { get; set; }
        public bool? TinhTrang { get; set; }
        //public bool? IsLock { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
