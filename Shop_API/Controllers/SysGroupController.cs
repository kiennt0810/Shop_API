using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop_API.Context;
using Shop_API.Entities;
using Shop_API.ViewModels;
using System.Text.RegularExpressions;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysGroupController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SysGroupController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var groups = _unitOfWork.GroupRepo.GetAll().OrderBy((group => group.ID));
                return Ok(_mapper.Map<IEnumerable<GroupVM>>(groups));
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            SysGroup group = _unitOfWork.GroupRepo.GetSingleOrDefault(s => s.ID == id);
            return Ok(_mapper.Map<GroupVM>(group));

        }
        [HttpGet("GetByMaNhom/{maNhom}")]
        public IActionResult GetByMaNhom(String maNhom)
        {
            SysGroup group = _unitOfWork.GroupRepo.GetSingleOrDefault(s => s.MaNhom == maNhom);
            return Ok(_mapper.Map<GroupVM>(group));

        }

        [HttpPost]
        public void Post([FromBody] GroupVM objVM)
        {
            SysGroup group = _mapper.Map<SysGroup>(objVM);
            _unitOfWork.GroupRepo.Add(group);
            _unitOfWork.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody] GroupVM objVM)
        {
            SysGroup group = _unitOfWork.GroupRepo.GetSingleOrDefault(s => s.ID == objVM.ID);
            if (group != null)
            {
                _unitOfWork.GroupRepo.Update(_mapper.Map<SysGroup>(objVM));
                _unitOfWork.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SysGroup group = _unitOfWork.GroupRepo.GetSingleOrDefault(s => s.ID == id);
            if (group != null)
            {
                _unitOfWork.GroupRepo.Remove(group);
                _unitOfWork.SaveChanges();
            }
        }

        [HttpPost("AddList")]
        public void PostList([FromBody] IEnumerable<GroupVM> objVM)
        {
            IEnumerable<SysGroup> lsGroup = _mapper.Map<IEnumerable<SysGroup>>(objVM);
            _unitOfWork.GroupRepo.AddRange(lsGroup);
            _unitOfWork.SaveChanges();
        }

        [HttpDelete("DeleteList/{ids}")]
        public void DeleteList(String ids)
        {
            IEnumerable<String> lsIDs = ids.Split(',');
            var lsGroup = _unitOfWork.GroupRepo.GetEntity().Where(t => lsIDs.Contains(t.ID.ToString()));
            if (lsGroup != null)
            {
                _unitOfWork.GroupRepo.RemoveRange(lsGroup);
                _unitOfWork.SaveChanges();
            }
        }
    }
}
