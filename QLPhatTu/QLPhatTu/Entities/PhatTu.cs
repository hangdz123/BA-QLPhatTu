namespace QLPhatTu.Entities
{
    public class PhatTu
    {
        public int Id { get; set; }
        public string TenTaiKhoan {  get; set; }
        public string? AnhChup {  get; set; }
        public string? DaHoanTuc {  get; set; }
        public string Email {  get; set; }
        public string? GioiTinh {  get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public DateTime? NgayHoanTuc { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string MatKhau {  get; set; }
        public string? PhapDanh {  get; set; }
        public string? SoDienThoai {  get; set; }
        public int? ChuaId {  get; set; }
        public Chua? Chua {  get; set; }
        public int? QuyenHanId {  get; set; }
        public QuyenHan? QuyenHan { get; set;}
        public IEnumerable<BaiViet>? BaiViet { get; set;}
        public IEnumerable<NDThichBinhLuanBaiViet>? NDThichBinhLuanBaiViet { get; set; }
        public IEnumerable<BinhLuanBaiViet>? BinhLuanBaiViet { get; set; }
        public IEnumerable<NguoiDungThichBaiViet>? NguoiDungThichBaiViet { get; set; }
        public IEnumerable<XacNhanEmail> XacNhanEmail {  get; set; }
        public IEnumerable<RefeshToken>? RefeshToken { get; set;}
        public IEnumerable<DonDangKy>? DonDangKy { get; set; }
        public IEnumerable<PhatTuDaoTrang>? PhatTuDaoTrang { get; set; }
    }
}
