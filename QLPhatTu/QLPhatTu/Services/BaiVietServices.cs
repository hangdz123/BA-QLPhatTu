using Microsoft.EntityFrameworkCore;
using QLPhatTu.Entities;
using QLPhatTu.IServices;

namespace QLPhatTu.Services
{
    public class BaiVietServices : IBaiVietServices
    {
        private readonly AppDbContext dbContext;
        public BaiVietServices()
        {
            dbContext = new AppDbContext();
        }

        public IEnumerable<BaiViet> GetDSBaiViet()
        {
            return dbContext.BaiViet.AsQueryable();
        }

        public BaiViet Sua(BaiViet baiViet)
        {
            var CanTim = dbContext.BaiViet.FirstOrDefault(x=>x.Id == baiViet.Id);
            if (CanTim != null)
            {
                CanTim.LoaiBaiVietId = baiViet.Id;
                CanTim.TieuDe = baiViet.TieuDe;
                CanTim.MoTa = baiViet.MoTa;
                CanTim.NoiDung = baiViet.NoiDung;
                CanTim.ThoiGianCapNhat = DateTime.Now;
                dbContext.Update(CanTim);
                dbContext.SaveChanges();
                return baiViet;
            }
            else
            {
                throw new Exception("Không Tồn Tại");
            }
        }

        public BaiViet Them(BaiViet baiViet, string tenTaiKhoan, string matKhau)
        {
            var CanTim = dbContext.PhatTu.SingleOrDefault(x => x.TenTaiKhoan == tenTaiKhoan
                                                         && x.MatKhau == matKhau);
            if(CanTim != null)
            {
                baiViet.PhanTuId = CanTim.Id;
                baiViet.ThoiGianDang = DateTime.Now;
                baiViet.SoLuotThich = 0;
                baiViet.SoLuotBinhLuan = 0;
                //baiViet.DaXoa = "Chưa";
                baiViet.TrangThaiBaiVietId = 1; //đang chờ duyệt
                dbContext.Add(baiViet);
                dbContext.SaveChanges();
                return baiViet;
            }
            else
            {
                throw new Exception("Tài Khoản Hoặc Mật Khẩu Không Đúng");
            }
        }
    }
}
