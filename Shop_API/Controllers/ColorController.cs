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
    public class ColorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SystemParam _sysParam;

        public ColorController(IMapper mapper, IUnitOfWork unitOfWork, IOptions<SystemParam> sysParam)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sysParam = sysParam.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var color = _unitOfWork.ColorRepo.GetAll().OrderBy((id => id.Id));
            return Ok(color);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Color color = _unitOfWork.ColorRepo.GetSingleOrDefault(s => s.Id == id);
            return Ok(color);
        }
        [HttpPost]
        public void Post([FromBody] ColorVM colorVM)
        {
            Color colorOjb = _mapper.Map<Color>(colorVM);
            colorOjb.TrangThai = true;
            _unitOfWork.ColorRepo.Add(colorOjb);
            _unitOfWork.SaveChanges();
        }
        [HttpPut]
        public void Put([FromBody] ColorVM colorVM)
        {
            Color colorvm = _unitOfWork.ColorRepo.GetSingleOrDefault(s => s.Id == colorVM.ID);
            if (colorvm != null)
            {
                _unitOfWork.ColorRepo.Update(_mapper.Map<Color>(colorVM));
                _unitOfWork.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Color colorvm = _unitOfWork.ColorRepo.GetSingleOrDefault(s => s.Id == id);
            if (colorvm == null) return NotFound();
            _unitOfWork.ColorRepo.Remove(colorvm);
            _unitOfWork.SaveChanges();
            return Ok();
        }

    }
}
