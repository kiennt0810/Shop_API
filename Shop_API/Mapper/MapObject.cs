using AutoMapper;
using Shop_API.Entities;
using Shop_API.ViewModels;
using System.Globalization;

namespace Shop_API.Mapper
{
    public class MapObject : Profile
    {
        private String dtFmt = "dd/MM/yyyy";
        private String dtYearFmt = "yyyy";
        public MapObject() {
            CreateMap<string, string>().ConvertUsing<NullStringConverter>();
            CreateMap<Color, ColorVM>();
            CreateMap<ColorVM, Color>();
            CreateMap<Staff, StaffVM>().ForMember(
                    x => x.NgaySinh, opt => opt.MapFrom(src => src.NgaySinh == null ? null : ((DateTime)src.NgaySinh).ToString(dtFmt, CultureInfo.InvariantCulture))
                );
            CreateMap<StaffVM, Staff>().ForMember(
                    x => x.NgaySinh, opt => opt.MapFrom(src => parseDateTime(src.NgaySinh)
                ));
            CreateMap<StorageCapacities, StorageVM>();
            CreateMap<StorageVM, StorageCapacities>();
            CreateMap<Brand, BrandVM>();
            CreateMap<BrandVM, Brand>();
            CreateMap<Product, ProductVM>();
            CreateMap<ProductVM, Product>();
            CreateMap<Customer, CustomerVM>();
            CreateMap<CustomerVM, Customer>();
            CreateMap<AdFile, AdFileVM>();
            CreateMap<AdFileVM, AdFile>();
            CreateMap<ProFileImg, ProFileImgVM>();
            CreateMap<ProFileImgVM, ProFileImg>();
            CreateMap<FunctionVM, SysFunction>();
            CreateMap<SysFunction, FunctionVM>();

            CreateMap<SysGroup, GroupVM>();
            CreateMap<GroupVM, SysGroup>();

            CreateMap<GroupStaff, GroupStaffVM>();
            CreateMap<GroupStaffVM, GroupStaff>();

            CreateMap<Role, RoleVM>();
            CreateMap<RoleVM, Role>();
        }

        public class NullStringConverter : ITypeConverter<string, string>
        {
            public string Convert(string source, string destination, ResolutionContext context)
            {
                return source ?? string.Empty;
            }
        }

        private DateTime? parseDateTime(String strDate)
        {
            return String.IsNullOrEmpty(strDate) ? null :
                DateTime.ParseExact(strDate, dtFmt, CultureInfo.InvariantCulture);
        }
    }
}
