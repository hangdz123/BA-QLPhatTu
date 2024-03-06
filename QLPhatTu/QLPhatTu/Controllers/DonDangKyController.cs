using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLPhatTu.Entities;
using QLPhatTu.IServices;
using QLPhatTu.Services;

namespace QLPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonDangKyController : ControllerBase
    {
        private readonly IDonDangKyServices services;
        private readonly AppDbContext dbContext;
        public DonDangKyController()
        {
            services = new DonDangKyServices();
            dbContext = new AppDbContext();
        }
        [HttpPost]
        public IActionResult Them([FromBody] DonDangKy donDangKy)
        {
            var res = services.Them(donDangKy);
            return Ok(res);
        }
        [HttpPut]
        public IActionResult Sua([FromBody] DonDangKy donDangKy)
        {
            var res = services.Sua(donDangKy);
            return Ok(res);
        }
        [HttpDelete]
        public IActionResult Xoa([FromQuery] int donDangKyId)
        {
            var CanTim = dbContext.DonDangKy.FirstOrDefault(x => x.Id == donDangKyId);
            if (CanTim == null)
            {
                return BadRequest("Đơn đăng ký không tồn tại không tồn tại!");
            }
            else
            {
                var daoTrang = dbContext.DaoTrang.FirstOrDefault(x => x.Id == CanTim.DaoTrangId);
                if (daoTrang != null)
                {
                    if (CanTim.TrangThaiDonId == 1)
                    {
                        daoTrang.SoThanhVienThamGia = daoTrang.SoThanhVienThamGia - 1;
                        dbContext.Update(daoTrang);
                        dbContext.SaveChanges();

                        dbContext.Remove(CanTim);
                        dbContext.SaveChanges();

                        return Ok("Xóa thành công");
                    }
                    else
                    {
                        dbContext.Remove(CanTim);
                        dbContext.SaveChanges();
                        return Ok("Xóa thành công");
                    }
                }
                else
                {
                    return BadRequest("Đạo tràng không tồn tại!");
                }
            }
        }
        [HttpPatch]
        public IActionResult DuyetDonDangKy(int donDangKyId, int nguoiXuLyId)
        {
            var CanTim = dbContext.DonDangKy.FirstOrDefault(x=>x.Id == donDangKyId);
            if(CanTim == null)
            {
                return BadRequest("Đơn đăng ký không tồn tại");
            }
            else
            {
                if(CanTim.TrangThaiDonId == 1)
                {
                    var phatTu = dbContext.PhatTu.FirstOrDefault(x => x.Id == nguoiXuLyId);
                    if(phatTu != null && phatTu.QuyenHanId == 2)
                    {
                        var daoTrang = dbContext.DaoTrang.FirstOrDefault(x => x.Id == CanTim.DaoTrangId);
                        if (daoTrang != null)
                        {
                            CanTim.NgayXuLy = DateTime.Now;
                            CanTim.NguoXuLy = phatTu.Id;
                            CanTim.TrangThaiDonId = 2;
                            dbContext.Update(CanTim);
                            dbContext.SaveChanges();

                            daoTrang.SoThanhVienThamGia = daoTrang.SoThanhVienThamGia + 1;
                            dbContext.Update(daoTrang);
                            dbContext.SaveChanges();
                            return Ok("Đã Duyệt");
                        }
                        else { return BadRequest("Đạo trang không tồn tại"); }
                    }
                    else { return BadRequest("Chỉ Admin mới được duyệt đơn đăng kí"); }
                }
                else { return BadRequest("Đơn đăng ký đã được duyệt"); }
            }
        }
    }
}
