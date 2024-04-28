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
    public class CustomerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SystemParam _sysParam;

        public CustomerController(IMapper mapper, IUnitOfWork unitOfWork, IOptions<SystemParam> sysParam)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sysParam = sysParam.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var custtomers = _unitOfWork.CustomerRepo.GetAll().OrderBy((nv => nv.ID));
            return Ok(_mapper.Map<IEnumerable<CustomerVM>>(custtomers));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Customer obj = _unitOfWork.CustomerRepo.GetSingleOrDefault(s => s.ID == id);
            return Ok(obj);
        }

        [HttpPost]
        public void Post([FromBody] CustomerVM objVM)
        {
            Customer Ojb = _mapper.Map<Customer>(objVM);
            Ojb.TrangThai = true;
            _unitOfWork.CustomerRepo.Add(Ojb);
            _unitOfWork.SaveChanges();
        }
        [HttpPut]
        public void Put([FromBody] ProductVM objVM)
        {
            Customer cusObj = _unitOfWork.CustomerRepo.GetSingleOrDefault(s => s.ID == objVM.ID);
            if (cusObj != null)
            {
                _unitOfWork.CustomerRepo.Update(_mapper.Map<Customer>(objVM));
                _unitOfWork.SaveChanges();
            }
        }
    }
}
