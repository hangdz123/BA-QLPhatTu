namespace QLPhatTu.Entities
{
    public class PhatTuDaoTrang
    {
        public int Id {  get; set; }
        public string DaThamGia {  get; set; }
        public string LyDoKhongThamGia { get; set; }
        public int DaoTrangId { get; set; }
        public DaoTrang? DaoTrang { get; set; }
        public int PhatTuId { get; set; }
        public PhatTu? PhatTu { get; set; }
    }
}
