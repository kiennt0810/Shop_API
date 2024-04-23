using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop_API.Context;
using Shop_API.Core;
using Shop_API.Entities;
using Shop_API.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SystemParam _sysParam;

        public StaffController(IMapper mapper, IUnitOfWork unitOfWork, IOptions<SystemParam> sysParam)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sysParam = sysParam.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var htnhanviens = _unitOfWork.StaffRepo.GetAll().OrderBy((nv => nv.MaNhanVien));
            return Ok(_mapper.Map<IEnumerable<StaffVM>>(htnhanviens));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Staff htnhanvien = _unitOfWork.StaffRepo.GetSingleOrDefault(s => s.ID == id);
            return Ok(htnhanvien);

        }

        [HttpPost("Login")]
        public IActionResult Validate(LoginModel model)
        {
            var user = _unitOfWork.StaffRepo.GetSingleOrDefault(p => p.MaNhanVien == model.UserName && p.TinhTrang == true);
            bool isSuccess = false;
            if (user != null)
            {
                if (user.MatKhau == EncryptBase64(model.Password))
                {
                    user.CountLoginFail = 0;
                    isSuccess = true;
                }
                else
                {
                    user.CountLoginFail = user.CountLoginFail + 1;
                    if (user.CountLoginFail >= _sysParam.SoLanDangNhap)
                    {
                        user.CountLoginFail = 0;
                        user.TinhTrang = false;
                    }
                }
                _unitOfWork.StaffRepo.Update(user);
                _unitOfWork.SaveChanges();
            }
            if (isSuccess)
            {
                return Ok(new LoginResponse
                {
                    Success = true,
                    Message = "Authenticate success",
                    Role = GetRoles(user.ID),
                    Data = GenerateToken(user),
                    isFirstLogin = (user.MatKhau == _sysParam.MatKhauMacDinh)
                });
            }
            else
            {
                return Ok(new LoginResponse
                {
                    Success = false,
                    Message = "Invalid username/password"
                });
            }
        }

        private string GenerateToken(Staff nguoiDung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            //var lsRoles = GetRoles(nguoiDung.ID);
             var secretKeyBytes = Encoding.UTF8.GetBytes(_sysParam.ApiSecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("Id", nguoiDung.ID.ToString()),
                    new Claim(ClaimTypes.Name, nguoiDung.HoTen),
                    new Claim("UserName", nguoiDung.MaNhanVien),
                    new Claim("TokenId", Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }

        private String[] GetRoles(int IdNhanVien)
        {
            var qHTNhanVien = _unitOfWork.StaffRepo.GetEntity();
            var qHTNhomNhanVien = _unitOfWork.GroupStaffRepo.GetEntity();
            var qHTQuyen = _unitOfWork.RoleRepo.GetEntity();


            var nnvq = qHTNhomNhanVien.Join(qHTQuyen, nnv => nnv.IdNhom, q => q.IdNhom, (nnv, q) => new { nnv, q })
                .Select(nnvq => new
                {
                    IdCn = nnvq.q.IdCn,
                    IdNhom = nnvq.q.IdNhom,
                    IdNhanVien = nnvq.nnv.IdNhanVien
                    // other assignments
                }).Where(a => a.IdNhanVien == IdNhanVien)
                .OrderBy(a => a.IdCn);

            var roles = nnvq.Select(a => a.IdCn).Distinct().ToArray();
            return roles;
            //return string.Join(";", roles);
        }

        private String EncryptBase64(string text)
        {
            var textBytes = Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(textBytes);
        }

        private String DecryptBase64(string base64Encoded)
        {
            var base64EncodeBytes = System.Convert.FromBase64String(base64Encoded);
            return Encoding.UTF8.GetString(base64EncodeBytes);
        }
    }
}
