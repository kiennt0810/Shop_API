﻿using AutoMapper;
using Shop_API.Entities;
using Shop_API.ViewModels;
using System.Globalization;

namespace Shop_API.Mapper
{
    public class MapObject : Profile
    {
        public MapObject() {
            CreateMap<string, string>().ConvertUsing<NullStringConverter>();
            CreateMap<Color, ColorVM>();
            CreateMap<ColorVM, Color>();
            CreateMap<Staff, StaffVM>();
            CreateMap<StaffVM, Staff>();
            CreateMap<StorageCapacities, StorageVM>();
            CreateMap<StorageVM, StorageCapacities>();
            CreateMap<Brand, BrandVM>();
            CreateMap<BrandVM, Brand>();
            CreateMap<Product, ProductVM>();
            CreateMap<ProductVM, Product>();
            CreateMap<Customer, CustomerVM>();
            CreateMap<CustomerVM, Customer>();
        }

        public class NullStringConverter : ITypeConverter<string, string>
        {
            public string Convert(string source, string destination, ResolutionContext context)
            {
                return source ?? string.Empty;
            }
        }
    }
}
