using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client.Extensions.Msal;
using Shop_API.Context;
using Shop_API.Core;
using Shop_API.Entities;
using Shop_API.ViewModels;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SystemParam _sysParam;

        public StorageController(IMapper mapper, IUnitOfWork unitOfWork, IOptions<SystemParam> sysParam)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sysParam = sysParam.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var storage = _unitOfWork.StorageRepo.GetAll().OrderBy((id => id.Id));
            return Ok(_mapper.Map<IEnumerable<StorageVM>>(storage));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            StorageCapacities storage = _unitOfWork.StorageRepo.GetSingleOrDefault(s => s.Id == id);
            return Ok(storage);
        }
        [HttpPost]
        public void Post([FromBody] StorageVM storageVM)
        {
            StorageCapacities Ojb = _mapper.Map<StorageCapacities>(storageVM);
            Ojb.TrangThai = true;
            _unitOfWork.StorageRepo.Add(Ojb);
            _unitOfWork.SaveChanges();
        }
        [HttpPut]
        public void Put([FromBody] StorageVM storageVM)
        {
            StorageCapacities obj = _unitOfWork.StorageRepo.GetSingleOrDefault(s => s.Id == storageVM.Id);
            if (obj != null)
            {
                _unitOfWork.StorageRepo.Update(_mapper.Map<StorageCapacities>(obj));
                _unitOfWork.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            StorageCapacities obj = _unitOfWork.StorageRepo.GetSingleOrDefault(s => s.Id == id);
            if (obj == null) return NotFound();
            _unitOfWork.StorageRepo.Remove(obj);
            _unitOfWork.SaveChanges();
            return Ok();
        }

    }
}
