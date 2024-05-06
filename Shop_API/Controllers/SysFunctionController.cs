using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop_API.Context;
using Shop_API.Entities;
using Shop_API.ViewModels;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysFunctionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SysFunctionController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var htchucnangs = _unitOfWork.FunctionRepo.GetAll();
            return Ok(_mapper.Map<IEnumerable<FunctionVM>>(htchucnangs));
        }

        [HttpGet("{maCN}")]
        public IActionResult Get(String maCN)
        {
            SysFunction htchucnang = _unitOfWork.FunctionRepo.GetSingleOrDefault(s => s.MaCN == maCN);
            return Ok(_mapper.Map<FunctionVM>(htchucnang));

        }

        [HttpPost]
        public void Post([FromBody] FunctionVM htchucnangVM)
        {
            SysFunction htchucnang = _mapper.Map<SysFunction>(htchucnangVM);
            _unitOfWork.FunctionRepo.Add(htchucnang);
            _unitOfWork.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody] FunctionVM htchucnangVM)
        {
            SysFunction htchucnang = _unitOfWork.FunctionRepo.GetSingleOrDefault(s => s.MaCN == htchucnangVM.MaCN);
            if (htchucnang != null)
            {
                _unitOfWork.FunctionRepo.Update(_mapper.Map<SysFunction>(htchucnangVM));
                _unitOfWork.SaveChanges();
            }
        }

        [HttpDelete("{maCN}")]
        public void Delete(String maCN)
        {
            SysFunction htchucnang = _unitOfWork.FunctionRepo.GetSingleOrDefault(s => s.MaCN == maCN);
            if (htchucnang != null)
            {
                _unitOfWork.FunctionRepo.Remove(htchucnang);
                _unitOfWork.SaveChanges();
            }
        }

        [HttpPost("AddList")]
        public void PostList([FromBody] IEnumerable<FunctionVM> htchucnangVM)
        {
            IEnumerable<SysFunction> lsHTChucNang = _mapper.Map<IEnumerable<SysFunction>>(htchucnangVM);
            _unitOfWork.FunctionRepo.AddRange(lsHTChucNang);
            _unitOfWork.SaveChanges();
        }

        [HttpDelete("DeleteList/{maCNs}")]
        public void DeleteList(String maCNs)
        {
            IEnumerable<String> lsIDs = maCNs.Split(',');
            var lsHTChucNang = _unitOfWork.FunctionRepo.GetEntity().Where(t => lsIDs.Contains(t.MaCN.ToString()));
            if (lsHTChucNang != null)
            {
                _unitOfWork.FunctionRepo.RemoveRange(lsHTChucNang);
                _unitOfWork.SaveChanges();
            }
        }
    }
}
