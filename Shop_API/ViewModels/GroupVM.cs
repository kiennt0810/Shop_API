namespace Shop_API.ViewModels
{
    public class GroupVM
    {
        public int? ID { set; get; }
        public string? MaNhom { set; get; }
        public string? Ten { set; get; }
        public bool? TinhTrang { set; get; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
