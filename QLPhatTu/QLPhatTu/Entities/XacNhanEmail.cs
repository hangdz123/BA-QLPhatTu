namespace QLPhatTu.Entities
{
    public class XacNhanEmail
    {
        public int Id { get; set; }
        public int PhatTuId {  get; set; }
        public PhatTu? PhatTu { get; set; }
        public DateTime ThoiGianHetHan {  get; set; }
        public string MaXacNhan {  get; set; }
        public string DaXacNhan { get; set; }
    }
}
