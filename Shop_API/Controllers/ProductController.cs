using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shop_API.Context;
using Shop_API.Core;
using Shop_API.Entities;
using Shop_API.ViewModels;
using System.Collections.Generic;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SystemParam _sysParam;

        public ProductController(IMapper mapper, IUnitOfWork unitOfWork, IOptions<SystemParam> sysParam)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sysParam = sysParam.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _unitOfWork.ProductRepo.GetAll().OrderBy((nv => nv.ID));
            return Ok(_mapper.Map<IEnumerable<ProductVM>>(products));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product obj = _unitOfWork.ProductRepo.GetSingleOrDefault(s => s.ID == id);
            return Ok(_mapper.Map < IEnumerable < ProductVM >>(obj));
        }
        [HttpPost]
        public void Post([FromBody] ProductVM objVM)
        {
            if (objVM.JsonColor != null)
            {
                ColorVM colorObj = JsonConvert.DeserializeObject<ColorVM>(objVM.JsonColor);
                if (colorObj != null)
                {
                    objVM.IDColor = colorObj.ID;
                }
            }

            if (objVM.JsonBrand != null)
            {
                BrandVM brandObj = JsonConvert.DeserializeObject<BrandVM>(objVM.JsonBrand);
                if (brandObj != null)
                {
                    objVM.IDBrand = brandObj.ID;
                }
            }

            if (objVM.JsonStorage != null)
            {
                StorageVM storageObj = JsonConvert.DeserializeObject<StorageVM>(objVM.JsonStorage);
                if (storageObj != null)
                {
                    objVM.IDStorage = storageObj.Id;
                }
            }

            Product Ojb = _mapper.Map<Product>(objVM);
            _unitOfWork.ProductRepo.Add(Ojb);
            _unitOfWork.SaveChanges();
        }
    }
}
