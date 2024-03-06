using QLPhatTu.Entities;

namespace QLPhatTu.IServices
{
    public interface IUserLikeServices
    {
        NguoiDungThichBaiViet ThichBaiViet(NguoiDungThichBaiViet thichBaiViet, string tenTaiKhoan, string matKhau);
        void BoThichBaiViet(int Id);
        NDThichBinhLuanBaiViet ThichBinhLuan(NDThichBinhLuanBaiViet thichBinhLuan, string tenTaiKhoan, string matKhau);
        void BoThichBinhLuan(int Id);
    }
}
