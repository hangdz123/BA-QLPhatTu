namespace QLPhatTu.Entities
{
    public class BinhLuanBaiViet
    {
        public int Id {  get; set; }
        public int? BaiVietId {  get; set; }
        public BaiViet? BaiViet { get; set; }
        public int? PhatTuId {  get; set; }
        public PhatTu? PhatTu { get; set;}
        public string BinhLuan {  get; set; }
        public int? SoLuotThich { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public DateTime? ThoiGianXoa { get; set; }
        public string? DaXoa {  get; set; }
        public IEnumerable<NDThichBinhLuanBaiViet>? NDThichBinhLuanBaiViet { get; set; }
    }
}
