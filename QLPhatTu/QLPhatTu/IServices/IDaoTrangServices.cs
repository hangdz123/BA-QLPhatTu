using QLPhatTu.Entities;

namespace QLPhatTu.IServices
{
    public interface IDaoTrangServices
    {
        DaoTrang Them(DaoTrang daoTrang);
        DaoTrang Sua(DaoTrang daoTrang);
        IEnumerable<DaoTrang> GetDSDaoTrang(int? nguoiTruTri = null, DateTime? ngayBatDau = null, DateTime? ngayKetThuc = null);
    }
}
