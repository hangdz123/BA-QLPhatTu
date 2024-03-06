using QLPhatTu.Entities;
using QLPhatTu.IServices;

namespace QLPhatTu.Services
{
    public class DonDangKyServices : IDonDangKyServices
    {
        private readonly AppDbContext dbContext;
        public DonDangKyServices()
        {
            dbContext = new AppDbContext();
        }

        public DonDangKy Sua(DonDangKy donDangKy)
        {
            var CanTim = dbContext.DonDangKy.FirstOrDefault(x=>x.Id == donDangKy.Id);  
            if (CanTim == null)
            {
                throw new Exception("Đơn đăng ký không tồn tại!");
            }
            else
            {
                if (CanTim.DaoTrangId == donDangKy.DaoTrangId)
                {
                    CanTim.NgayGuiDon = donDangKy.NgayGuiDon;
                    CanTim.DaoTrangId = donDangKy.DaoTrangId;
                    CanTim.PhatTuId = donDangKy.PhatTuId;
                    dbContext.DonDangKy.Update(CanTim);
                    dbContext.SaveChanges();
                    return donDangKy;
                }
                else
                {
                    var daoTrang = dbContext.DaoTrang.FirstOrDefault(x => x.Id == donDangKy.DaoTrangId);
                    var daoTrang2 = dbContext.DaoTrang.FirstOrDefault(x => x.Id == CanTim.DaoTrangId);
                    if (daoTrang != null && daoTrang2 != null)
                    {
                        CanTim.NgayGuiDon = donDangKy.NgayGuiDon;
                        CanTim.DaoTrangId = donDangKy.DaoTrangId;
                        CanTim.PhatTuId = donDangKy.PhatTuId;
                        dbContext.Update(CanTim);
                        dbContext.SaveChanges();

                        daoTrang.SoThanhVienThamGia = daoTrang.SoThanhVienThamGia + 1;
                        dbContext.Update(daoTrang);
                        dbContext.SaveChanges();

                        daoTrang2.SoThanhVienThamGia = daoTrang2.SoThanhVienThamGia - 1;
                        dbContext.Update(daoTrang2);
                        dbContext.SaveChanges();
                        return donDangKy;

                    }
                    else
                    {
                        throw new Exception("Đạo tràng không tồn tại!");
                    }
                }         
            }
        }

        public DonDangKy Them(DonDangKy donDangKy)
        {
            var canTim = dbContext.DaoTrang.FirstOrDefault(x => x.Id == donDangKy.DaoTrangId);
            if (canTim != null)
            {
                if (canTim.DaKetThuc == "Chưa Kết Thúc")
                {
                    donDangKy.NgayGuiDon = DateTime.Now;
                    donDangKy.TrangThaiDonId = 1;
                    dbContext.Add(donDangKy);
                    dbContext.SaveChanges();
                    return donDangKy;
                }
                else { throw new Exception("Đạo tràng đã kết thúc"); }
            }
            else { throw new Exception("Đạo Tràng không tồn tại"); }

        }

        //public void Xoa(int donDangKyId)
        //{
        //    var CanTim = dbContext.DonDangKy.FirstOrDefault(x => x.Id == donDangKyId);
        //    if (CanTim == null)
        //    {
        //        throw new Exception("Đơn đăng ký không tồn tại không tồn tại!");
        //    }
        //    else
        //    {
        //        var daoTrang = dbContext.DaoTrang.FirstOrDefault(x => x.Id == CanTim.DaoTrangId);
        //        if (daoTrang != null)
        //        {
        //            if (CanTim.TrangThaiDonId == 1)
        //            {
        //                daoTrang.SoThanhVienThamGia = daoTrang.SoThanhVienThamGia - 1;
        //                dbContext.Update(daoTrang);
        //                dbContext.SaveChanges();

        //                dbContext.Remove(CanTim);
        //                dbContext.SaveChanges();
        //            }
        //            else
        //            {
        //                dbContext.Remove(CanTim);
        //                dbContext.SaveChanges();
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("Đạo tràng không tồn tại!");
        //        }
        //    }
        //}
    }
}
