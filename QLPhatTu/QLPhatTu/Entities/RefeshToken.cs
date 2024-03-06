namespace QLPhatTu.Entities
{
    public class RefeshToken
    {
        public int Id { get; set; }
        public string ToKen {  get; set; }
        public DateTime ThoiGianHetHan {  get; set; }
        public int PhatTuId {  get; set; }
        public PhatTu? PhatTu { get; set; }
    }
}
