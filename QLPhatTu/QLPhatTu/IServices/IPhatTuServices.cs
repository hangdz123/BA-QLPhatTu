using QLPhatTu.Entities;

namespace QLPhatTu.IServices
{
    public interface IPhatTuServices
    {
        PhatTu DangKyTaiKhoan(PhatTu phatTu);
        bool XacThucDangKyTaiKhoan(string tenTaiKhoan);
        bool KiemTraTaiKhoan(string tenTaiKhoan);
        bool DangNhap(string tenTaiKhoan, string matKhau);
        bool GuiMail(string tenTaiKhoan, string Code);
        IEnumerable<PhatTu> GetDSPhatTu(string? tenTaiKhoan = null, string? email = null, string? gioiTinh = null);
        string GenerateToken(string tenTaiKhoan);
        void SaveTokenToDatabase(string tenTaiKhoan, string token);
    }
}
