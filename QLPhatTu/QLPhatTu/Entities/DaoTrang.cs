namespace QLPhatTu.Entities
{
    public class DaoTrang
    {
        public int Id { get; set; }
        public string DaKetThuc {  get; set; }
        public string NoiDung {  get; set; }
        public string NoiToChuc {  get; set; }
        public int SoThanhVienThamGia { get; set; }
        public DateTime ThoiGianBatDau {  get; set; }
        public int NguoiTruTri {  get; set; }
        public IEnumerable<DonDangKy> DonDangKy {  get; set; }
        public IEnumerable<PhatTuDaoTrang> PhatTuDaoTrang { get; set; }

    }
}
