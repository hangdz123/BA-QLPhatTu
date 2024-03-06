namespace QLPhatTu.Entities
{
    public class TrangThaiDon
    {
        public int Id {  get; set; }
        public string TenTrangThai {  get; set; }
        public IEnumerable<DonDangKy> DonDangKy { get; set; }
    }
}
