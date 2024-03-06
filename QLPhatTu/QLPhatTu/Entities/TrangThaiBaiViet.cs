namespace QLPhatTu.Entities
{
    public class TrangThaiBaiViet
    {
        public int Id { get; set; }
        public string TenTrangThai {  get; set; }
        public IEnumerable<BaiViet> BaiViet { get; set;}
    }
}
