using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QLPhatTu.Entities;
using QLPhatTu.IServices;
using QLPhatTu.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QLPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IConfiguration _configuration;
        private readonly IPhatTuServices services;
        public testController(IConfiguration configuration)
        {
            dbContext = new AppDbContext();
            _configuration = configuration;
            services = new PhatTuServices(_configuration);
        }
        [HttpPost]
        public IActionResult DangNhapTaiKhoan(string tenTaiKhoan, string matKhau)
        {
            var CanTim = dbContext.PhatTu.SingleOrDefault(x => x.TenTaiKhoan == tenTaiKhoan
                                                            && x.MatKhau == matKhau);
            // Kiểm tra và xác thực thông tin đăng nhập
            if (CanTim == null)
            {
                return Unauthorized("Tài Khoản Hoặc Mật Khẩu Không Đúng");
            }

            // Tạo mã thông báo
            var token = services.GenerateToken(tenTaiKhoan);

            // Lưu mã thông báo vào cơ sở dữ liệu
            services.SaveTokenToDatabase(tenTaiKhoan, token);

            // Trả về mã thông báo cho người dùng
            //return Ok(new { token });
            return Ok("Đăng Nhập Thành Công");
        }
        //[HttpGet]
        ////[Authorize]
        //public IActionResult UserInfo()
        //{
        //    // Lấy thông tin người dùng từ mã thông báo
        //    var username = User.Identity.Name;

        //    // Truy vấn thông tin người dùng từ cơ sở dữ liệu
        //    var user = dbContext.PhatTu.FirstOrDefault(u => u.TenTaiKhoan == username);

        //    // Trả về thông tin người dùng
        //    return Ok(new { user.Id, user.TenTaiKhoan, user.Email });
        //}
    }
}
