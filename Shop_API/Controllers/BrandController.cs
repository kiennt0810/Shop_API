using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shop_API.Context;
using Shop_API.Core;
using Shop_API.Entities;
using Shop_API.ViewModels;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SystemParam _sysParam;

        public BrandController(IMapper mapper, IUnitOfWork unitOfWork, IOptions<SystemParam> sysParam)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sysParam = sysParam.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var brand = _unitOfWork.BrandRepo.GetAll().OrderBy((id => id.Id));
            return Ok(brand);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Brand obj = _unitOfWork.BrandRepo.GetSingleOrDefault(s => s.Id == id);
            return Ok(obj);
        }
        [HttpPost]
        public void Post([FromBody] BrandVM objVM)
        {
            Brand ojb = _mapper.Map<Brand>(objVM);
            ojb.TrangThai = true;
            _unitOfWork.BrandRepo.Add(ojb);
            _unitOfWork.SaveChanges();
        }
        [HttpPut]
        public void Put([FromBody] BrandVM objVM)
        {
            Brand ojb = _unitOfWork.BrandRepo.GetSingleOrDefault(s => s.Id == objVM.ID);
            if (ojb != null)
            {
                _unitOfWork.BrandRepo.Update(_mapper.Map<Brand>(objVM));
                _unitOfWork.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Brand obj = _unitOfWork.BrandRepo.GetSingleOrDefault(s => s.Id == id);
            if (obj == null) return NotFound();
            _unitOfWork.BrandRepo.Remove(obj);
            _unitOfWork.SaveChanges();
            return Ok();
        }
    }
}
