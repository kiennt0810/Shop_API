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
    public class AdFileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SystemParam _sysParam;

        public AdFileController(IMapper mapper, IUnitOfWork unitOfWork, IOptions<SystemParam> sysParam)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sysParam = sysParam.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var adFile = _unitOfWork.AdFileRepo.GetAll().OrderBy((id => id.ID));
            return Ok(adFile);
        }

        [HttpPost]
        public void Post([FromForm] AdFileVM objVM)
        {
            List<AdFile> lsFile = new List<AdFile>();
            foreach (string imgUrl in objVM.ListFile ?? Enumerable.Empty<string>())
            {
                AdFile adImg = new()
                {
                    Url = imgUrl,
                };
                lsFile.Add(adImg);
            }
            _unitOfWork.AdFileRepo.AddRange(lsFile);
            _unitOfWork.SaveChanges();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AdFile obj = _unitOfWork.AdFileRepo.GetSingleOrDefault(s => s.ID == id);
            if (obj == null) return NotFound();
            _unitOfWork.AdFileRepo.Remove(obj);
            _unitOfWork.SaveChanges();
            return Ok();
        }
    }
}
