using Microsoft.EntityFrameworkCore;

namespace QLPhatTu.Entities
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<BaiViet> BaiViet { get; set; }
        public virtual DbSet<BinhLuanBaiViet> BinhLuanBaiViet { get; set; }
        public virtual DbSet<Chua> Chua { get; set; }
        public virtual DbSet<DaoTrang> DaoTrang { get; set; }
        public virtual DbSet<DonDangKy> DonDangKy { get; set; }
        public virtual DbSet<LoaiBaiViet> LoaiBaiViet { get; set; }
        public virtual DbSet<NguoiDungThichBaiViet> NguoiDungThichBaiViet { get; set; }
        public virtual DbSet<NDThichBinhLuanBaiViet> NDThichBinhLuanBaiViet { get; set; }
        public virtual DbSet<PhatTu> PhatTu { get; set; }
        public virtual DbSet<PhatTuDaoTrang> PhatTuDaoTrang { get; set; }
        public virtual DbSet<QuyenHan> QuyenHan { get; set; }
        public virtual DbSet<RefeshToken> RefeshToken { get; set; }
        public virtual DbSet<TrangThaiBaiViet> TrangThaiBaiViet { get; set; }
        public virtual DbSet<TrangThaiDon> TrangThaiDon { get; set; }
        public virtual DbSet<XacNhanEmail> XacNhanEmail { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server = DESKTOP-KFO8VF1\\SQLEXPRESS2; Database = QLPhatTuApi; Trusted_Connection = True;" +
                $" TrustServerCertificate=True");
        }
    }
}
