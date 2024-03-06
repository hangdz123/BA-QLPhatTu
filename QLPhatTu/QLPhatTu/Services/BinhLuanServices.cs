using QLPhatTu.Entities;
using QLPhatTu.IServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLPhatTu.Services
{
    public class BinhLuanServices : IBinhLuanServices
    {
        private readonly AppDbContext dbContext;
        public BinhLuanServices()
        {
            dbContext = new AppDbContext();
        }

        public IEnumerable<BinhLuanBaiViet> GetDSBinhLuan(int? baiVietId)
        {
            var query = dbContext.BinhLuanBaiViet.AsQueryable();
            if (baiVietId.HasValue)
            {
                query = query.Where(x => x.BaiVietId == baiVietId);
            }
            return query;
        }

        public BinhLuanBaiViet Sua(BinhLuanBaiViet binhLuan)
        {
            var CanTim = dbContext.BinhLuanBaiViet.FirstOrDefault(x => x.Id == binhLuan.BaiVietId);
            if (CanTim != null)
            {
                var baiViet = dbContext.BaiViet.FirstOrDefault(x => x.Id == CanTim.BaiVietId);
                if (baiViet != null)
                {
                    CanTim.ThoiGianCapNhat = DateTime.Now;
                    CanTim.BinhLuan = binhLuan.BinhLuan;
                    dbContext.Update(CanTim);
                    dbContext.SaveChanges();
                    return binhLuan;
                }
                else { throw new Exception("Bài viết không tồn tại"); }
            }
            else { throw new Exception("Bình Luận không tồn tại"); }
        }

        public BinhLuanBaiViet Them(BinhLuanBaiViet binhLuan, string tenTaiKhoan, string matKhau)
        {
            var CanTim = dbContext.PhatTu.SingleOrDefault(x=>x.TenTaiKhoan == tenTaiKhoan
                                                            && x.MatKhau == matKhau);
            if(CanTim != null)
            {
                var baiViet = dbContext.BaiViet.FirstOrDefault(x => x.Id == binhLuan.BaiVietId);
                if(baiViet != null)
                {
                    binhLuan.PhatTuId = CanTim.Id;
                    binhLuan.SoLuotThich = 0;
                    binhLuan.ThoiGianTao = DateTime.Now;
                    dbContext.Add(binhLuan);
                    dbContext.SaveChanges();

                    baiViet.SoLuotBinhLuan = baiViet.SoLuotBinhLuan + 1;
                    dbContext.Update(baiViet);
                    dbContext.SaveChanges();
                    return binhLuan;
                }
                else { throw new Exception("Bài viết không tồn tại"); }
            }
            else { throw new Exception("Tài khoản hoặc mật khẩu không đúng"); }
        }
    }
}
