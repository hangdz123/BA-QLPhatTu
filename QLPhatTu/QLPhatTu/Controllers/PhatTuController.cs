using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QLPhatTu.Entities;
using QLPhatTu.Helper;
using QLPhatTu.IServices;
using QLPhatTu.Services;
using System;
using System.Security.Claims;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace QLPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhatTuController : ControllerBase
    {
        private readonly IPhatTuServices services;
        private readonly AppDbContext dbContext;
        private readonly IConfiguration _configuration;
        public PhatTuController(IConfiguration configuration)
        {
            dbContext = new AppDbContext();
            _configuration = configuration;
            services = new PhatTuServices(_configuration);
        }
        [HttpPost]
        public IActionResult DangKyTaiKhoan([FromBody] PhatTu phatTu)
        {
            var res = services.DangKyTaiKhoan(phatTu);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult XacThucDangKyTaiKhoan(string tenTaiKhoan, string maXacNhan)
        {
            var CanTim = services.XacThucDangKyTaiKhoan(tenTaiKhoan);
            if(CanTim == true) 
            {
                var phatTu = dbContext.PhatTu.SingleOrDefault(x => x.TenTaiKhoan == tenTaiKhoan);
                if(phatTu != null)
                {
                    var xacNhan = dbContext.XacNhanEmail.SingleOrDefault(x=>x.PhatTuId == phatTu.Id);
                    if(xacNhan != null)
                    {
                        if (xacNhan.MaXacNhan != maXacNhan)
                        {
                            return BadRequest("Mã Xác Nhận Không Đúng");
                        }
                        else
                        {
                            xacNhan.DaXacNhan = "Đã kích hoạt";
                            dbContext.Update(xacNhan);
                            dbContext.SaveChanges();
                            return Ok("Xác nhận thành công");
                        }
                    }
                    else { return BadRequest(); }
                }
                else { return BadRequest(); }
            }
            else
            {
                return BadRequest("Tài khoản không tồn tại");
            }
        }
        //[HttpPost("{dangNhap1}")]
        //public IActionResult DangNhapTaiKhoan(string tenTaiKhoan, string matKhau)
        //{
        //    var CanTim = dbContext.PhatTu.SingleOrDefault(x => x.TenTaiKhoan == tenTaiKhoan
        //                                                && x.MatKhau == matKhau);
        //    //var res = services.DangNhap1(tenTaiKhoan, matKhau);
        //    if (CanTim != null)
        //    {
        //        return Ok(CanTim);
        //    }
        //    else
        //    {
        //        return BadRequest("Tài khoản hoặc mật khẩu không đúng");
        //    }
        //    //return Ok(res);
        //}
        [HttpPost("{dangNhap1}")]
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
            return Ok(new { token });
            //return Ok("Đăng Nhập Thành Công");
        }
        [HttpPatch]
        public IActionResult DoiMatKhau(string tenTaiKhoan, string matKhauCu, string matKhauMoi) 
        {
            var CanTim1 = services.DangNhap(tenTaiKhoan, matKhauCu);
            if(CanTim1 == true)
            {
                var CanTim = dbContext.PhatTu.SingleOrDefault(x => x.TenTaiKhoan == tenTaiKhoan
                                                        && x.MatKhau == matKhauCu);
                if (CanTim != null && CanTim.MatKhau != matKhauMoi)
                {
                    CanTim.MatKhau = matKhauMoi;
                    dbContext.Update(CanTim);
                    dbContext.SaveChanges();
                    return Ok(CanTim);
                }
                else
                {
                    return BadRequest("Yêu cầu nhập đúng tên tài khoản và mật khẩu, mật khẩu mới không trùng mật khẩu cũ");
                }
            }
            else
            {
                return BadRequest("Đăng nhập thất bại ,Tài khoản hoặc mật khẩu không đúng");
            }
            
        }
        [HttpPatch("{quenMatKhau1}")]
        public IActionResult QuenMatKhau(string tenTaiKhoan)
        {
            Random random = new Random();
            string Code = random.Next(100000, 999999).ToString();
            var Tim = services.GuiMail(tenTaiKhoan, Code);
            if (Tim == true)
            {
                var CanTim = dbContext.PhatTu.SingleOrDefault(x => x.TenTaiKhoan == tenTaiKhoan);
                if(CanTim != null)
                {
                    var x = dbContext.XacNhanEmail.SingleOrDefault(x => x.PhatTuId == CanTim.Id);
                    if (x != null)
                    {
                        x.MaXacNhan = Code;
                        x.DaXacNhan = "Chưa Kích Hoạt Vì Để Chế Độ Quên Mật Khẩu";
                        dbContext.Update(x);
                        dbContext.SaveChanges();
                    }
                }
                return Ok("Mail Đã Được Gửi Về Gmail Của Bạn");
            }
            else { return BadRequest("Tài Khoản Không Tồn Tại"); }
        }
        [HttpPut("{taoMatKhau1}")]
        public IActionResult TaoMatKhauMoi(string tenTaiKhoan, string maXacNhan, string matKhauMoi)
        {
            var CanTim = dbContext.PhatTu.SingleOrDefault(x => x.TenTaiKhoan == tenTaiKhoan);
            if (CanTim != null)
            {
                var x = dbContext.XacNhanEmail.SingleOrDefault(x => x.PhatTuId == CanTim.Id);
                if (x != null && x.MaXacNhan == maXacNhan)
                {
                    x.MaXacNhan = maXacNhan;
                    x.DaXacNhan = "Đã Kích Hoạt"; 
                    dbContext.Update(x);
                    dbContext.SaveChanges();

                    CanTim.MatKhau = matKhauMoi;
                    dbContext.Update(CanTim);
                    dbContext.SaveChanges();

                    return Ok("Đổi Mật Khẩu Thành Công");
                }
                else { return BadRequest("Mã xác nhận không đúng"); }
            }
            else { return BadRequest("Tài Khoản Không Tồn Tại"); }
        }
        [HttpGet("{keyword1}")]
        public IActionResult GetDSPhatTu([FromQuery] string? tenTaiKhoan = null,
                                        [FromQuery] string? email = null,
                                        [FromQuery] string? gioiTinh = null, 
                                        [FromQuery] Pagination pagination = null)
        {
            var query = services.GetDSPhatTu(tenTaiKhoan, email, gioiTinh);
            var ds = PageResult<PhatTu>.ToPagedResult(pagination, (IQueryable<PhatTu>)query).AsEnumerable();
            pagination.TotalCount = ds.Count();
            var res = new PageResult<PhatTu>(pagination, ds);
            return Ok(res);
        }
    }
}
