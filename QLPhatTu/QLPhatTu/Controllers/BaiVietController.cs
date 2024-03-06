using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLPhatTu.Entities;
using QLPhatTu.Helper;
using QLPhatTu.IServices;
using QLPhatTu.Services;
using System.Security.Claims;

namespace QLPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        private readonly IBaiVietServices services;
        private readonly AppDbContext dbContext;
        public BaiVietController()
        {
            services = new BaiVietServices();
            dbContext = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetDSBaiViet([FromQuery] Pagination pagination = null)
        {
            var query = services.GetDSBaiViet();
            var ds = PageResult<BaiViet>.ToPagedResult(pagination, (IQueryable<BaiViet>)query).AsEnumerable();
            pagination.TotalCount = ds.Count();
            var res = new PageResult<BaiViet>(pagination, ds);
            return Ok(res);
        }
        //[HttpGet]
        //public IEnumerable<BaiViet> Get()
        //{
        //    var baiVietList = dbContext.BaiViet.ToList();

        //    var baiVietDtoList = baiVietList.Select(b => new BaiViet
        //    {
        //        Id = b.Id,
        //        TieuDe = b.TieuDe,
        //        MoTa = b.MoTa,
        //        NoiDung = b.NoiDung,
        //        SoLuotThich = b.SoLuotThich,
        //        SoLuotBinhLuan = b.SoLuotBinhLuan
        //    });

        //    return baiVietDtoList;
        //}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var baiViet = dbContext.BaiViet.FirstOrDefault(b => b.Id == id);

            if (baiViet == null)
            {
                return NotFound();
            }

            var baiVietNoiDungDto = new HienThiBaiViet
            {
                Id = baiViet.Id,
                TieuDe = baiViet.TieuDe,
                MoTa = baiViet.MoTa,
                NoiDung = baiViet.NoiDung,
                SoLuotThich = baiViet.SoLuotThich,
                SoLuotBinhLuan = baiViet.SoLuotBinhLuan
            };

            return Ok(baiVietNoiDungDto);
        }
        [HttpPost]
        public IActionResult Them([FromBody] BaiViet baiViet, string tenTaiKhoan, string matKhau)
        {
            //var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //var user1 = User.FindFirst(ClaimTypes.Name)?.Value;
            //var user2 = User.FindFirst(ClaimTypes.Email)?.Value;
            //return Ok($"Hello, {user}, {user1}, {user2}.");
            var res = services.Them(baiViet, tenTaiKhoan, matKhau);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult Sua([FromBody] BaiViet baiViet)
        {
            var res = services.Sua(baiViet);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult Xoa([FromQuery] int baiVietId)
        {
            var CanTim = dbContext.BaiViet.FirstOrDefault(x => x.Id == baiVietId);
            if (CanTim != null)
            {
                dbContext.Remove(CanTim);
                dbContext.SaveChanges();
                return Ok("Xóa thành công");
            }
            else
            {
                return BadRequest("Bài viết không tồn tại");
            }
        }
        [HttpPatch]
        public IActionResult DuyetBaiViet(int baiVietId, int nguoiDuyetId)
        {
            var CanTim = dbContext.BaiViet.FirstOrDefault(x => x.Id == baiVietId);
            if (CanTim == null)
            {
                return BadRequest("Bài viết không tồn tại");
            }
            else
            {
                if (CanTim.TrangThaiBaiVietId == 1)
                {
                    var phatTu = dbContext.PhatTu.FirstOrDefault(x => x.Id == nguoiDuyetId);
                    if (phatTu != null && phatTu.QuyenHanId == 2)
                    {
                        CanTim.NguoiDuyetBaiVietId = phatTu.Id;
                        CanTim.TrangThaiBaiVietId = 2;
                        dbContext.Update(CanTim);
                        dbContext.SaveChanges();
                        return Ok("Đã Duyệt");
                    }
                    else { return BadRequest("Chỉ Admin mới được duyệt đơn đăng kí"); }
                }
                else { return BadRequest("Đơn đăng ký đã được duyệt"); }
            }
        }
    }
}
