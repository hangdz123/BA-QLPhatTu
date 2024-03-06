using QLPhatTu.Entities;
using QLPhatTu.IServices;

namespace QLPhatTu.Services
{
    public class UserLikeServices : IUserLikeServices
    {
        private readonly AppDbContext dbContext;
        public UserLikeServices()
        {
            dbContext = new AppDbContext();
        }

        public void BoThichBaiViet(int Id)
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
                }
                else { throw new Exception("Bài viết không tồn tại"); }
            }
        }

        public void BoThichBinhLuan(int Id)
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
                }
                else { throw new Exception("Bình luận không tồn tại"); }
            }
        }

        public NguoiDungThichBaiViet ThichBaiViet(NguoiDungThichBaiViet thichBaiViet, string tenTaiKhoan, string matKhau)
        {
            var CanTim = dbContext.PhatTu.SingleOrDefault(x => x.TenTaiKhoan == tenTaiKhoan
                                                            && x.MatKhau == matKhau);
            if(CanTim != null)
            {
                var baiViet = dbContext.BaiViet.FirstOrDefault(x => x.Id == thichBaiViet.BaiVietId);
                if (baiViet != null)
                {
                    thichBaiViet.PhatTuId = CanTim.Id;
                    thichBaiViet.ThoiGianThich = DateTime.Now;
                    dbContext.Add(thichBaiViet);
                    dbContext.SaveChanges();

                    baiViet.SoLuotThich = baiViet.SoLuotThich + 1;
                    dbContext.Update(baiViet); 
                    dbContext.SaveChanges();
                    return thichBaiViet;
                }
                else { throw new Exception("Bài viết không tồn tại"); }
            }
            else { throw new Exception("Tài khoản hoặc mật khẩu không đúng"); }
        }

        public NDThichBinhLuanBaiViet ThichBinhLuan(NDThichBinhLuanBaiViet thichBinhLuan, string tenTaiKhoan, string matKhau)
        {
            var CanTim = dbContext.PhatTu.SingleOrDefault(x => x.TenTaiKhoan == tenTaiKhoan
                                                            && x.MatKhau == matKhau);
            if (CanTim != null)
            {
                var binhLuan = dbContext.BinhLuanBaiViet.FirstOrDefault(x => x.Id == thichBinhLuan.BinhLuanBaiVietId);
                if (binhLuan != null)
                {
                    thichBinhLuan.PhatTuId = CanTim.Id;
                    thichBinhLuan.ThoiGianLike = DateTime.Now;
                    dbContext.Add(thichBinhLuan);
                    dbContext.SaveChanges();

                    binhLuan.SoLuotThich = binhLuan.SoLuotThich + 1;
                    dbContext.Update(binhLuan);
                    dbContext.SaveChanges();
                    return thichBinhLuan;
                }
                else { throw new Exception("Bình luận không tồn tại"); }
            }
            else { throw new Exception("Tài khoản hoặc mật khẩu không đúng"); }
        }
    }
}
