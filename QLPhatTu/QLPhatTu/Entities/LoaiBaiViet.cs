namespace QLPhatTu.Entities
{
    public class LoaiBaiViet
    {
        public int Id { get; set; }
        public string TenLoai {  get; set; }
        public IEnumerable<BaiViet> BaiViet { get; set;}
    }
}
