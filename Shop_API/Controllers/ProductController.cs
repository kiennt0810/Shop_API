using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client.Extensions.Msal;
using Newtonsoft.Json;
using Shop_API.Context;
using Shop_API.Core;
using Shop_API.Entities;
using Shop_API.ViewModels;
using System.Collections.Generic;
using System.Drawing;
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
            return Ok(obj);
        }
        [HttpPost]
        public void Post([FromBody] ProductVM objVM)
        {
            if (objVM.IDColor != null)
            {
                Entities.Color color = _unitOfWork.ColorRepo.GetSingleOrDefault(s => s.Id == objVM.IDColor);
                if (color != null)
                {
                    objVM.MaMau = color.MaMau;
                }
            }

            if (objVM.IDBrand != null)
            {
                Brand brandObj = _unitOfWork.BrandRepo.GetSingleOrDefault(s => s.Id == objVM.IDBrand);
                if (brandObj != null)
                {
                    objVM.ThuongHieu = brandObj.ThuongHieu;
                }
            }

            if (objVM.IDStorage != null)
            {
                StorageCapacities storageObj = _unitOfWork.StorageRepo.GetSingleOrDefault(s => s.Id == objVM.IDStorage);
                if (storageObj != null)
                {
                    objVM.DungLuong = storageObj.DungLuong;
                }
            }

            Product Ojb = _mapper.Map<Product>(objVM);
            _unitOfWork.ProductRepo.Add(Ojb);

            List<ProFileImg> lsFile = [];
            ProFileImg adImg = new()
            {
                IdProduct = (int)objVM.ID,
                FileName = objVM.TenSp,
            };

            lsFile.Add(adImg);
  
            _unitOfWork.ProFileImgRepo.AddRange(lsFile);
            _unitOfWork.SaveChanges();

            _unitOfWork.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody] ProductVM objVM)
        {
            Product proObj = _unitOfWork.ProductRepo.GetSingleOrDefault(s => s.ID == objVM.ID);
            if (proObj != null)
            {
                if (objVM.IDColor != null)
                {
                    Entities.Color color = _unitOfWork.ColorRepo.GetSingleOrDefault(s => s.Id == objVM.IDColor);
                    if (color != null)
                    {
                        objVM.MaMau = color.MaMau;
                    }
                }

                if (objVM.IDBrand != null)
                {
                    Brand brandObj = _unitOfWork.BrandRepo.GetSingleOrDefault(s => s.Id == objVM.IDBrand);
                    if (brandObj != null)
                    {
                        objVM.ThuongHieu = brandObj.ThuongHieu;
                    }
                }

                if (objVM.IDStorage != null)
                {
                    StorageCapacities storageObj = _unitOfWork.StorageRepo.GetSingleOrDefault(s => s.Id == objVM.IDStorage);
                    if (storageObj != null)
                    {
                        objVM.DungLuong = storageObj.DungLuong;
                    }
                }
                _unitOfWork.ProductRepo.Update(_mapper.Map<Product>(objVM));
                _unitOfWork.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _unitOfWork.ProductRepo.GetSingleOrDefault(s => s.ID == id);
            if (product == null) return NotFound();
            _unitOfWork.ProductRepo.Remove(product);
            _unitOfWork.SaveChanges();
            return Ok();
        }
    }
}
