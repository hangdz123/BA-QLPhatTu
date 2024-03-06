namespace QLPhatTu.Entities
{
    public class QuyenHan
    {
        public int Id { get; set; }
        public string TenQuyenHan {  get; set; }
        public IEnumerable<PhatTu> PhatTu { get; set; }
    }
}
