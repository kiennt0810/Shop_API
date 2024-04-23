using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shop_API.Context;
using Shop_API.Core;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SystemParam _sysParam;

        public GroupController(IMapper mapper, IUnitOfWork unitOfWork, IOptions<SystemParam> sysParam)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sysParam = sysParam.Value;
        }
    }
}
