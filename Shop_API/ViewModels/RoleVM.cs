﻿namespace Shop_API.ViewModels
{
    public class RoleVM
    {
        public int? IdNhom { set; get; }
        public string? IdCn { set; get; }
        public string? MaNhom { set; get; }
        public string? TenCN { set; get; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
