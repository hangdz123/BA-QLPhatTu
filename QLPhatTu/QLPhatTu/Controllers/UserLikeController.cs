using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLPhatTu.Entities;
using QLPhatTu.IServices;
using QLPhatTu.Services;

namespace QLPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLikeController : ControllerBase
    {
        private readonly IUserLikeServices services;
        private readonly AppDbContext dbContext;
        public UserLikeController()
        {
            services = new UserLikeServices();
            dbContext = new AppDbContext();
        }
        [HttpPost]
        public IActionResult ThichBaiViet([FromBody] NguoiDungThichBaiViet thichBaiViet, string tenTaiKhoan, string matKhau)
        {
            var res = services.ThichBaiViet(thichBaiViet, tenTaiKhoan, matKhau);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult BoThichBaiViet([FromQuery] int Id)
        {
            var boThich = dbContext.NguoiDungThichBaiViet.FirstOrDefault(x => x.Id == Id);
            if (boThich != null)
            {
                var baiViet = dbContext.BaiViet.FirstOrDefault(x => x.Id == boThich.BaiVietId);
                if (baiViet != null)
                {
                    dbContext.Remove(boThich);
                    dbContext.SaveChanges();

                    baiViet.SoLuotThich = baiViet.SoLuotThich - 1;
                    dbContext.Update(baiViet);
                    dbContext.SaveChanges();
                    return Ok("Đã bỏ thích bài viết này");
                }
                else { return BadRequest("Bài viết không tồn tại"); }
            }
            else { return BadRequest("0"); }
        }
        [HttpPost("{thichBinhLuan}")]
        public IActionResult ThichBinhLuan([FromBody] NDThichBinhLuanBaiViet thichBinhLuan, string tenTaiKhoan, string matKhau)
        {
            var res = services.ThichBinhLuan(thichBinhLuan, tenTaiKhoan, matKhau);
            return Ok(res);
        }
        [HttpDelete("{Id}")]
        public IActionResult BoThichBinhLuan([FromQuery] int Id)
        {
            var boThich = dbContext.NDThichBinhLuanBaiViet.FirstOrDefault(x => x.Id == Id);
            if (boThich != null)
            {
                var binhLuan = dbContext.BinhLuanBaiViet.FirstOrDefault(x => x.Id == boThich.BinhLuanBaiVietId);
                if (binhLuan != null)
                {
                    dbContext.Remove(boThich);
                    dbContext.SaveChanges();

                    binhLuan.SoLuotThich = binhLuan.SoLuotThich - 1;
                    dbContext.Update(binhLuan);
                    dbContext.SaveChanges();
                    return Ok("Đã bỏ thích bình luận này");
                }
                else { return BadRequest("Bình luận không tồn tại"); }
            }
            else { return BadRequest("0"); }
        }
    }
}
