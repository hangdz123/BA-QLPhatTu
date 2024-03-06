using QLPhatTu.Entities;

namespace QLPhatTu.IServices
{
    public interface IBinhLuanServices
    {
        BinhLuanBaiViet Them(BinhLuanBaiViet binhLuan, string tenTaiKhoan, string matKhau);
        BinhLuanBaiViet Sua(BinhLuanBaiViet binhLuan);
        IEnumerable<BinhLuanBaiViet> GetDSBinhLuan(int? baiVietId);
    }
}
