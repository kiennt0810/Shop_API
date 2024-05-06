using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop_API.Context;
using Shop_API.Entities;
using Shop_API.ViewModels;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var htquyens = _unitOfWork.RoleRepo.GetAll();
            return Ok(_mapper.Map<IEnumerable<RoleVM>>(htquyens));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Role htquyen = _unitOfWork.RoleRepo.GetSingleOrDefault(s => s.ID == id);
            return Ok(_mapper.Map<RoleVM>(htquyen));

        }

        [HttpPost]
        public void Post([FromBody] RoleVM htquyenVM)
        {
            Role htquyen = _mapper.Map<Role>(htquyenVM);
            _unitOfWork.RoleRepo.Add(htquyen);
            _unitOfWork.SaveChanges();
        }

        [HttpPost("{idNhom}")]
        public void Post(int idNhom, [FromBody] IEnumerable<RoleVM> htquyenVM)
        {
            var lsHTQuyen = _unitOfWork.RoleRepo.GetEntity().Where(t => t.IdNhom == idNhom);
            _unitOfWork.RoleRepo.RemoveRange(lsHTQuyen);

            IEnumerable<Role> lsHTQuyenInGroup = _mapper.Map<IEnumerable<Role>>(htquyenVM);
            _unitOfWork.RoleRepo.AddRange(lsHTQuyenInGroup);
            _unitOfWork.SaveChanges();

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Role htquyen = _unitOfWork.RoleRepo.GetSingleOrDefault(s => s.ID == id);
            if (htquyen != null)
            {
                _unitOfWork.RoleRepo.Remove(htquyen);
                _unitOfWork.SaveChanges();
            }
        }

        [HttpPost("AddList")]
        public void PostList([FromBody] IEnumerable<RoleVM> htquyenVM)
        {
            IEnumerable<Role> lsHTQuyen = _mapper.Map<IEnumerable<Role>>(htquyenVM);
            _unitOfWork.RoleRepo.AddRange(lsHTQuyen);
            _unitOfWork.SaveChanges();
        }

        [HttpDelete("DeleteList/{ids}")]
        public void DeleteList(String ids)
        {
            IEnumerable<String> lsIDs = ids.Split(',');
            var lsHTQuyen = _unitOfWork.RoleRepo.GetEntity().Where(t => lsIDs.Contains(t.ID.ToString()));
            if (lsHTQuyen != null)
            {
                _unitOfWork.RoleRepo.RemoveRange(lsHTQuyen);
                _unitOfWork.SaveChanges();
            }
        }

        [HttpGet("GetInGroup/{MaNhom}")]
        public IActionResult GetInGroup(String MaNhom)
        {
            var HTNhomE = _unitOfWork.GroupRepo.GetEntity();
            var HTQuyenE = _unitOfWork.RoleRepo.GetEntity();
            var HTChucNangE = _unitOfWork.FunctionRepo.GetEntity();
            var lsInGroup = (from q in HTQuyenE
                             join nh in HTNhomE on q.IdNhom equals nh.ID
                             join cn in HTChucNangE on q.IdCn equals cn.MaCN
                             where nh.MaNhom == MaNhom
                             select new RoleVM()
                             {
                                 IdNhom = nh.ID,
                                 IdCn = q.IdCn,
                                 MaNhom = nh.MaNhom,
                                 TenCN = cn.Ten
                             }).ToList();
            return Ok(lsInGroup);
        }
        [HttpGet("GetNotInGroup/{MaNhom}")]
        public IActionResult GetNotInGroup(String MaNhom)
        {
            var HTNhomE = _unitOfWork.GroupRepo.GetEntity();
            var HTQuyenE = _unitOfWork.RoleRepo.GetEntity();
            var HTChucNangE = _unitOfWork.FunctionRepo.GetEntity();
            var lsNotInGroup = (from cn in HTChucNangE
                                where !(from q in HTQuyenE
                                        join nh in HTNhomE on q.IdNhom equals nh.ID
                                        where nh.MaNhom == MaNhom
                                        select q.IdCn).ToList().Contains(cn.MaCN)
                                select new RoleVM()
                                {
                                    IdCn = cn.MaCN,
                                    TenCN = cn.Ten
                                }).ToList();
            return Ok(lsNotInGroup);
        }

    }
}
