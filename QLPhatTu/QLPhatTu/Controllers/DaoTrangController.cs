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
    public class DaoTrangController : ControllerBase
    {
        private readonly IDaoTrangServices services;
        private readonly AppDbContext dbContext;
        public DaoTrangController()
        {
            services = new DaoTrangServices();
            dbContext = new AppDbContext();
        }
        [HttpGet("{keyword1}")]
        public IActionResult GetDSDaoTrang([FromQuery] int? nguoiTruTri = null,
                                        [FromQuery] DateTime? ngayBatDau = null,
                                        [FromQuery] DateTime? ngayKetThuc = null,
                                            [FromQuery] Pagination pagination = null)
        {
            var query = services.GetDSDaoTrang(nguoiTruTri, ngayBatDau, ngayKetThuc);
            var ds = PageResult<DaoTrang>.ToPagedResult(pagination, (IQueryable<DaoTrang>)query).AsEnumerable();
            pagination.TotalCount = ds.Count();
            var res = new PageResult<DaoTrang>(pagination, ds);
            return Ok(res);
        }
        [HttpPost]
        public IActionResult Them([FromBody] DaoTrang daoTrang)
        {
            var res = services.Them(daoTrang);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult Sua([FromBody] DaoTrang daoTrang)
        {
            var res = services.Sua(daoTrang);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult Xoa([FromQuery] int daoTrangId)
        {
            var CanTim = dbContext.DaoTrang.FirstOrDefault(x => x.Id == daoTrangId);
            if (CanTim == null)
            {
                return BadRequest("Đạo tràng không tồn tại!");
            }
            else
            {
                dbContext.Remove(CanTim);
                dbContext.SaveChanges();
                return Ok("Xóa thành công");
            }
        }
    }
}
