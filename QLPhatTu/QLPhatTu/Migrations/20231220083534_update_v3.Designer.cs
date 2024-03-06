﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLPhatTu.Entities;

#nullable disable

namespace QLPhatTu.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231220083534_update_v3")]
    partial class update_v3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QLPhatTu.Entities.BaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DaXoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiBaiVietId")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NguoiDuyetBaiVietId")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhanTuId")
                        .HasColumnType("int");

                    b.Property<int?>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuotBinhLuan")
                        .HasColumnType("int");

                    b.Property<int>("SoLuotThich")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianDang")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThaiBaiVietId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoaiBaiVietId");

                    b.HasIndex("PhatTuId");

                    b.HasIndex("TrangThaiBaiVietId");

                    b.ToTable("BaiViet");
                });

            modelBuilder.Entity("QLPhatTu.Entities.BinhLuanBaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BaiVietId")
                        .HasColumnType("int");

                    b.Property<string>("BinhLuan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DaXoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuotThich")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianXoa")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BaiVietId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("BinhLuanBaiViet");
                });

            modelBuilder.Entity("QLPhatTu.Entities.Chua", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayThanhLap")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiTruTri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenChua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chua");
                });

            modelBuilder.Entity("QLPhatTu.Entities.DaoTrang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DaKetThuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NguoiTruTri")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiToChuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoThanhVienThamGia")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianBatDau")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DaoTrang");
                });

            modelBuilder.Entity("QLPhatTu.Entities.DonDangKy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DaoTrangId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayGuiDon")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayXuLy")
                        .HasColumnType("datetime2");

                    b.Property<int>("NguoXuLy")
                        .HasColumnType("int");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<int>("TrangThaiDonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DaoTrangId");

                    b.HasIndex("PhatTuId");

                    b.HasIndex("TrangThaiDonId");

                    b.ToTable("DonDangKy");
                });

            modelBuilder.Entity("QLPhatTu.Entities.LoaiBaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiBaiViet");
                });

            modelBuilder.Entity("QLPhatTu.Entities.NDThichBinhLuanBaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BinhLuanBaiVietId")
                        .HasColumnType("int");

                    b.Property<string>("DaXoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianLike")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BinhLuanBaiVietId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("NDThichBinhLuanBaiViet");
                });

            modelBuilder.Entity("QLPhatTu.Entities.NguoiDungThichBaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BaiVietId")
                        .HasColumnType("int");

                    b.Property<string>("DaXoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianThich")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BaiVietId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("NguoiDungThichBaiViet");
                });

            modelBuilder.Entity("QLPhatTu.Entities.PhatTu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnhChup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ChuaId")
                        .HasColumnType("int");

                    b.Property<string>("DaHoanTuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayHoanTuc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhapDanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuyenHanId")
                        .HasColumnType("int");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTaiKhoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChuaId");

                    b.HasIndex("QuyenHanId");

                    b.ToTable("PhatTu");
                });

            modelBuilder.Entity("QLPhatTu.Entities.PhatTuDaoTrang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DaThamGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DaoTrangId")
                        .HasColumnType("int");

                    b.Property<string>("LyDoKhongThamGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DaoTrangId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("PhatTuDaoTrang");
                });

            modelBuilder.Entity("QLPhatTu.Entities.QuyenHan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenQuyenHan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuyenHan");
                });

            modelBuilder.Entity("QLPhatTu.Entities.RefeshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianHetHan")
                        .HasColumnType("datetime2");

                    b.Property<string>("ToKen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhatTuId");

                    b.ToTable("RefeshToken");
                });

            modelBuilder.Entity("QLPhatTu.Entities.TrangThaiBaiViet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenTrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrangThaiBaiViet");
                });

            modelBuilder.Entity("QLPhatTu.Entities.TrangThaiDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenTrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrangThaiDon");
                });

            modelBuilder.Entity("QLPhatTu.Entities.XacNhanEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DaXacNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaXacNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianHetHan")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PhatTuId");

                    b.ToTable("XacNhanEmail");
                });

            modelBuilder.Entity("QLPhatTu.Entities.BaiViet", b =>
                {
                    b.HasOne("QLPhatTu.Entities.LoaiBaiViet", "LoaiBaiViet")
                        .WithMany("BaiViet")
                        .HasForeignKey("LoaiBaiVietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPhatTu.Entities.PhatTu", "PhatTu")
                        .WithMany("BaiViet")
                        .HasForeignKey("PhatTuId");

                    b.HasOne("QLPhatTu.Entities.TrangThaiBaiViet", "TrangThaiBaiViet")
                        .WithMany("BaiViet")
                        .HasForeignKey("TrangThaiBaiVietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiBaiViet");

                    b.Navigation("PhatTu");

                    b.Navigation("TrangThaiBaiViet");
                });

            modelBuilder.Entity("QLPhatTu.Entities.BinhLuanBaiViet", b =>
                {
                    b.HasOne("QLPhatTu.Entities.BaiViet", "BaiViet")
                        .WithMany("BinhLuanBaiViet")
                        .HasForeignKey("BaiVietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPhatTu.Entities.PhatTu", "PhatTu")
                        .WithMany("BinhLuanBaiViet")
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaiViet");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPhatTu.Entities.DonDangKy", b =>
                {
                    b.HasOne("QLPhatTu.Entities.DaoTrang", "DaoTrang")
                        .WithMany("DonDangKy")
                        .HasForeignKey("DaoTrangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPhatTu.Entities.PhatTu", "PhatTu")
                        .WithMany("DonDangKy")
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPhatTu.Entities.TrangThaiDon", "TrangThaiDon")
                        .WithMany("DonDangKy")
                        .HasForeignKey("TrangThaiDonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DaoTrang");

                    b.Navigation("PhatTu");

                    b.Navigation("TrangThaiDon");
                });

            modelBuilder.Entity("QLPhatTu.Entities.NDThichBinhLuanBaiViet", b =>
                {
                    b.HasOne("QLPhatTu.Entities.BinhLuanBaiViet", "BinhLuanBaiViet")
                        .WithMany("NDThichBinhLuanBaiViet")
                        .HasForeignKey("BinhLuanBaiVietId");

                    b.HasOne("QLPhatTu.Entities.PhatTu", "PhatTu")
                        .WithMany("NDThichBinhLuanBaiViet")
                        .HasForeignKey("PhatTuId");

                    b.Navigation("BinhLuanBaiViet");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPhatTu.Entities.NguoiDungThichBaiViet", b =>
                {
                    b.HasOne("QLPhatTu.Entities.BaiViet", "BaiViet")
                        .WithMany("NguoiDungThichBaiViet")
                        .HasForeignKey("BaiVietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPhatTu.Entities.PhatTu", "PhatTu")
                        .WithMany("NguoiDungThichBaiViet")
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaiViet");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPhatTu.Entities.PhatTu", b =>
                {
                    b.HasOne("QLPhatTu.Entities.Chua", "Chua")
                        .WithMany("PhatTu")
                        .HasForeignKey("ChuaId");

                    b.HasOne("QLPhatTu.Entities.QuyenHan", "QuyenHan")
                        .WithMany("PhatTu")
                        .HasForeignKey("QuyenHanId");

                    b.Navigation("Chua");

                    b.Navigation("QuyenHan");
                });

            modelBuilder.Entity("QLPhatTu.Entities.PhatTuDaoTrang", b =>
                {
                    b.HasOne("QLPhatTu.Entities.DaoTrang", "DaoTrang")
                        .WithMany("PhatTuDaoTrang")
                        .HasForeignKey("DaoTrangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLPhatTu.Entities.PhatTu", "PhatTu")
                        .WithMany("PhatTuDaoTrang")
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DaoTrang");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPhatTu.Entities.RefeshToken", b =>
                {
                    b.HasOne("QLPhatTu.Entities.PhatTu", "PhatTu")
                        .WithMany("RefeshToken")
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPhatTu.Entities.XacNhanEmail", b =>
                {
                    b.HasOne("QLPhatTu.Entities.PhatTu", "PhatTu")
                        .WithMany("XacNhanEmail")
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPhatTu.Entities.BaiViet", b =>
                {
                    b.Navigation("BinhLuanBaiViet");

                    b.Navigation("NguoiDungThichBaiViet");
                });

            modelBuilder.Entity("QLPhatTu.Entities.BinhLuanBaiViet", b =>
                {
                    b.Navigation("NDThichBinhLuanBaiViet");
                });

            modelBuilder.Entity("QLPhatTu.Entities.Chua", b =>
                {
                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPhatTu.Entities.DaoTrang", b =>
                {
                    b.Navigation("DonDangKy");

                    b.Navigation("PhatTuDaoTrang");
                });

            modelBuilder.Entity("QLPhatTu.Entities.LoaiBaiViet", b =>
                {
                    b.Navigation("BaiViet");
                });

            modelBuilder.Entity("QLPhatTu.Entities.PhatTu", b =>
                {
                    b.Navigation("BaiViet");

                    b.Navigation("BinhLuanBaiViet");

                    b.Navigation("DonDangKy");

                    b.Navigation("NDThichBinhLuanBaiViet");

                    b.Navigation("NguoiDungThichBaiViet");

                    b.Navigation("PhatTuDaoTrang");

                    b.Navigation("RefeshToken");

                    b.Navigation("XacNhanEmail");
                });

            modelBuilder.Entity("QLPhatTu.Entities.QuyenHan", b =>
                {
                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QLPhatTu.Entities.TrangThaiBaiViet", b =>
                {
                    b.Navigation("BaiViet");
                });

            modelBuilder.Entity("QLPhatTu.Entities.TrangThaiDon", b =>
                {
                    b.Navigation("DonDangKy");
                });
#pragma warning restore 612, 618
        }
    }
}
