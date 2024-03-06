using QLPhatTu.Entities;
using QLPhatTu.IServices;
using System;

namespace QLPhatTu.Services
{
    public class DaoTrangServices:IDaoTrangServices
    {
        private readonly AppDbContext dbContext;

        public DaoTrangServices()
        {
            dbContext = new AppDbContext();
        }

        public IEnumerable<DaoTrang> GetDSDaoTrang(int? nguoiTruTri = null, DateTime? ngayBatDau = null, DateTime? ngayKetThuc = null)
        {
            var query = dbContext.DaoTrang.AsQueryable();
            //if (!string.IsNullOrEmpty())
            //{
            //    query = query.Where(x => x.NguoiTruTri.ToString().Contains(keyword.ToLower())
            //                        || x.ThoiGianBatDau == ngayBatDau
            //                        || x.ThoiGianBatDau == ngayKetThuc);
            //}
            if (nguoiTruTri.HasValue)
            {
                query = query.Where(x => x.NguoiTruTri == nguoiTruTri);
            }
            if (ngayBatDau.HasValue && ngayKetThuc.HasValue)
            {
                query = query.Where(x => x.ThoiGianBatDau >= ngayBatDau && x.ThoiGianBatDau <= ngayKetThuc);
            }
            return query;
        }

        public DaoTrang Sua(DaoTrang daoTrang)
        {
            var CanTim = dbContext.DaoTrang.FirstOrDefault(x => x.Id == daoTrang.Id);
            if (CanTim == null)
            {
                throw new Exception("Đạo trang không tồn tại!");
            }
            else
            {
                CanTim.DaKetThuc = daoTrang.DaKetThuc;
                CanTim.NoiDung = daoTrang.NoiDung;
                CanTim.NoiToChuc = daoTrang.NoiToChuc;
                CanTim.SoThanhVienThamGia = daoTrang.SoThanhVienThamGia;
                CanTim.ThoiGianBatDau = daoTrang.ThoiGianBatDau;
                CanTim.NguoiTruTri = daoTrang.NguoiTruTri;
                dbContext.Update(CanTim);
                dbContext.SaveChanges();
                return daoTrang;
            }
        }

        public DaoTrang Them(DaoTrang daoTrang)
        {
            dbContext.Add(daoTrang);
            dbContext.SaveChanges();
            return daoTrang;
        }
    }
}
