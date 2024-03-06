using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLPhatTu.Entities;
using QLPhatTu.Helper;
using QLPhatTu.IServices;
using QLPhatTu.Services;

namespace QLPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinhLuanController : ControllerBase
    {
        private readonly IBinhLuanServices services;
        private readonly AppDbContext dbContext;
        public BinhLuanController()
        {
            services = new BinhLuanServices();
            dbContext = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetDSBinhLuan([FromQuery]int? baiVietId, [FromQuery] Pagination pagination = null)
        {
            var query = services.GetDSBinhLuan(baiVietId);
            var ds = PageResult<BinhLuanBaiViet>.ToPagedResult(pagination, (IQueryable<BinhLuanBaiViet>)query).AsEnumerable();
            pagination.TotalCount = ds.Count();
            var res = new PageResult<BinhLuanBaiViet>(pagination, ds);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult Them([FromBody] BinhLuanBaiViet binhLuan, string tenTaiKhoan, string matKhau)
        {
            var res = services.Them(binhLuan, tenTaiKhoan, matKhau);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult Sua([FromBody] BinhLuanBaiViet binhLuan)
        {
            var res = services.Sua(binhLuan);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult Xoa([FromQuery] int binhLuanId)
        {
            var CanTim = dbContext.BinhLuanBaiViet.FirstOrDefault(x => x.Id == binhLuanId);
            if (CanTim != null)
            {
                var baiViet = dbContext.BaiViet.FirstOrDefault(x => x.Id == CanTim.BaiVietId);
                if (baiViet != null)
                {
                    dbContext.Remove(CanTim);
                    dbContext.SaveChanges();

                    baiViet.SoLuotBinhLuan = baiViet.SoLuotBinhLuan - 1;
                    dbContext.Update(baiViet);
                    dbContext.SaveChanges();
                    return Ok("Xóa thành công");
                }
                else { return BadRequest("Bài viết không tồn tại"); }
            }
            else { return BadRequest("Bình Luận không tồn tại"); }
        }
    }
}
