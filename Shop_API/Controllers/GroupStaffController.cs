using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop_API.Context;
using Shop_API.Entities;
using Shop_API.ViewModels;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupStaffController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GroupStaffController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var htnhomnhanviens = _unitOfWork.GroupStaffRepo.GetAll();
            return Ok(_mapper.Map<IEnumerable<GroupStaffVM>>(htnhomnhanviens));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            GroupStaff htnhomnhanvien = _unitOfWork.GroupStaffRepo.GetSingleOrDefault(s => s.ID == id);
            return Ok(_mapper.Map<GroupStaffVM>(htnhomnhanvien));

        }

        [HttpPost("{idNhom}")]
        public void Post(int idNhom, [FromBody] IEnumerable<GroupStaffVM> htnhomnhanvienVM)
        {
            var lsHTNhomNhanVien = _unitOfWork.GroupStaffRepo.GetEntity().Where(t => t.IdNhom == idNhom);
            _unitOfWork.GroupStaffRepo.RemoveRange(lsHTNhomNhanVien);

            IEnumerable<GroupStaff> lsHTNhomNhanVienInGroup = _mapper.Map<IEnumerable<GroupStaff>>(htnhomnhanvienVM);
            _unitOfWork.GroupStaffRepo.AddRange(lsHTNhomNhanVienInGroup);
            _unitOfWork.SaveChanges();

        }
        [HttpGet("GetInGroup/{MaNhom}")]
        public IActionResult GetInGroup(String MaNhom)
        {
            var HTNhomE = _unitOfWork.GroupRepo.GetEntity();
            var HTNhomNhanVienE = _unitOfWork.GroupStaffRepo.GetEntity();
            var HTNhanVienE = _unitOfWork.StaffRepo.GetEntity();
            var lsInGroup = (from nnv in HTNhomNhanVienE
                             join nh in HTNhomE on nnv.IdNhom equals nh.ID
                             join nv in HTNhanVienE on nnv.IdNhanVien equals nv.ID
                             where nh.MaNhom == MaNhom && nv.TinhTrang == true
                             select new GroupStaffVM()
                             {
                                 ID = nnv.ID,
                                 IdNhanVien = nnv.IdNhanVien,
                                 IdNhom = nnv.IdNhom,
                                 CreatedDate = nnv.CreatedDate,
                                 MaNhanVien = nv.MaNhanVien,
                                 TenNhanVien = nv.HoTen,
                                 MaNhom = nh.MaNhom
                             }).ToList();
            return Ok(lsInGroup);
        }
        [HttpGet("GetNotInGroup/{MaNhom}")]
        public IActionResult GetNotInGroup(String MaNhom)
        {
            var HTNhomE = _unitOfWork.GroupRepo.GetEntity();
            var HTNhomNhanVienE = _unitOfWork.GroupStaffRepo.GetEntity();
            var HTNhanVienE = _unitOfWork.StaffRepo.GetEntity();
            var lsNotInGroup = (from nv in HTNhanVienE
                                where nv.TinhTrang == true && !(from nnv in HTNhomNhanVienE
                                                                join nh in HTNhomE on nnv.IdNhom equals nh.ID
                                                                where nh.MaNhom == MaNhom
                                                                select nnv.IdNhanVien).ToList().Contains(nv.ID)
                                select new GroupStaffVM()
                                {
                                    IdNhanVien = nv.ID,
                                    MaNhanVien = nv.MaNhanVien,
                                    TenNhanVien = nv.HoTen
                                }).ToList();
            return Ok(lsNotInGroup);
        }
    }
}
