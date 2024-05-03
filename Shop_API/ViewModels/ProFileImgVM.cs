using Shop_API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop_API.ViewModels
{
    public class ProFileImgVM
    {
        public long ID { get; set; }
        public int IdProduct { set; get; }
        public string? ImgUrl { get; set; }
    }
}
