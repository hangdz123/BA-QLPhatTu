namespace QLPhatTu.Entities
{
    public class NguoiDungThichBaiViet
    {
        public int Id { get; set; }
        public int? BaiVietId { get; set; }
        public BaiViet? BaiViet { get; set; }
        public int? PhatTuId { get; set; }
        public PhatTu? PhatTu { get; set; }
        public DateTime? ThoiGianThich { get; set; }
        public string? DaXoa {  get; set; }
    }
}
