using System.ComponentModel.DataAnnotations;

namespace QLPhatTu.Entities
{
    public class NDThichBinhLuanBaiViet
    {
        public int Id { get; set; }
        public DateTime? ThoiGianLike { get; set; }
        public string? DaXoa { get; set; }
        public int? PhatTuId { get; set; }
        public PhatTu? PhatTu { get; set; }
        public int? BinhLuanBaiVietId { get; set; }
        public BinhLuanBaiViet? BinhLuanBaiViet { get; set; }
    }
}
