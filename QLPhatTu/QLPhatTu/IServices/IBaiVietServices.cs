using QLPhatTu.Entities;

namespace QLPhatTu.IServices
{
    public interface IBaiVietServices
    {
        BaiViet Them(BaiViet baiViet, string tenTaiKhoan, string matKhau);
        BaiViet Sua(BaiViet baiViet);
        IEnumerable<BaiViet> GetDSBaiViet();
    }
}
