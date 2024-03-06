using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLPhatTu.Migrations
{
    /// <inheritdoc />
    public partial class y : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chua",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayThanhLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTruTri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chua", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DaoTrang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaKetThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiToChuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoThanhVienThamGia = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTruTri = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaoTrang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiBaiViet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiBaiViet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuyenHan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyenHan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenHan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiBaiViet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiBaiViet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiDon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiDon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhatTu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhChup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaHoanTuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHoanTuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhapDanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChuaId = table.Column<int>(type: "int", nullable: false),
                    QuyenHanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhatTu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhatTu_Chua_ChuaId",
                        column: x => x.ChuaId,
                        principalTable: "Chua",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhatTu_QuyenHan_QuyenHanId",
                        column: x => x.QuyenHanId,
                        principalTable: "QuyenHan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaiViet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiBaiVietId = table.Column<int>(type: "int", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhanTuId = table.Column<int>(type: "int", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: true),
                    NguoiDuyetBaiVietId = table.Column<int>(type: "int", nullable: false),
                    SoLuotThich = table.Column<int>(type: "int", nullable: false),
                    SoLuotBinhLuan = table.Column<int>(type: "int", nullable: false),
                    ThoiGianDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianXoa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaXoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThaiBaiVietId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiViet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaiViet_LoaiBaiViet_LoaiBaiVietId",
                        column: x => x.LoaiBaiVietId,
                        principalTable: "LoaiBaiViet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaiViet_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaiViet_TrangThaiBaiViet_TrangThaiBaiVietId",
                        column: x => x.TrangThaiBaiVietId,
                        principalTable: "TrangThaiBaiViet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonDangKy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayGuiDon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayXuLy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoXuLy = table.Column<int>(type: "int", nullable: false),
                    TrangThaiDonId = table.Column<int>(type: "int", nullable: false),
                    DaoTrangId = table.Column<int>(type: "int", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonDangKy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonDangKy_DaoTrang_DaoTrangId",
                        column: x => x.DaoTrangId,
                        principalTable: "DaoTrang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonDangKy_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonDangKy_TrangThaiDon_TrangThaiDonId",
                        column: x => x.TrangThaiDonId,
                        principalTable: "TrangThaiDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhatTuDaoTrang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaThamGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LyDoKhongThamGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaoTrangId = table.Column<int>(type: "int", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhatTuDaoTrang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhatTuDaoTrang_DaoTrang_DaoTrangId",
                        column: x => x.DaoTrangId,
                        principalTable: "DaoTrang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhatTuDaoTrang_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefeshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToKen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefeshToken_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XacNhanEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhatTuId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaXacNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaXacNhan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XacNhanEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XacNhanEmail_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BinhLuanBaiViet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaiVietId = table.Column<int>(type: "int", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false),
                    BinhLuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuotThich = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianXoa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaXoa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinhLuanBaiViet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BinhLuanBaiViet_BaiViet_BaiVietId",
                        column: x => x.BaiVietId,
                        principalTable: "BaiViet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BinhLuanBaiViet_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungThichBaiViet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaiVietId = table.Column<int>(type: "int", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false),
                    ThoiGianThich = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaXoa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungThichBaiViet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiDungThichBaiViet_BaiViet_BaiVietId",
                        column: x => x.BaiVietId,
                        principalTable: "BaiViet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguoiDungThichBaiViet_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NDThichBinhLuanBaiViet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianLike = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaXoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: true),
                    BinhLuanBaiVietId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NDThichBinhLuanBaiViet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NDThichBinhLuanBaiViet_BinhLuanBaiViet_BinhLuanBaiVietId",
                        column: x => x.BinhLuanBaiVietId,
                        principalTable: "BinhLuanBaiViet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NDThichBinhLuanBaiViet_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_LoaiBaiVietId",
                table: "BaiViet",
                column: "LoaiBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_PhatTuId",
                table: "BaiViet",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_TrangThaiBaiVietId",
                table: "BaiViet",
                column: "TrangThaiBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuanBaiViet_BaiVietId",
                table: "BinhLuanBaiViet",
                column: "BaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuanBaiViet_PhatTuId",
                table: "BinhLuanBaiViet",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_DonDangKy_DaoTrangId",
                table: "DonDangKy",
                column: "DaoTrangId");

            migrationBuilder.CreateIndex(
                name: "IX_DonDangKy_PhatTuId",
                table: "DonDangKy",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_DonDangKy_TrangThaiDonId",
                table: "DonDangKy",
                column: "TrangThaiDonId");

            migrationBuilder.CreateIndex(
                name: "IX_NDThichBinhLuanBaiViet_BinhLuanBaiVietId",
                table: "NDThichBinhLuanBaiViet",
                column: "BinhLuanBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_NDThichBinhLuanBaiViet_PhatTuId",
                table: "NDThichBinhLuanBaiViet",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungThichBaiViet_BaiVietId",
                table: "NguoiDungThichBaiViet",
                column: "BaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungThichBaiViet_PhatTuId",
                table: "NguoiDungThichBaiViet",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTu_ChuaId",
                table: "PhatTu",
                column: "ChuaId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTu_QuyenHanId",
                table: "PhatTu",
                column: "QuyenHanId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTuDaoTrang_DaoTrangId",
                table: "PhatTuDaoTrang",
                column: "DaoTrangId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTuDaoTrang_PhatTuId",
                table: "PhatTuDaoTrang",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_RefeshToken_PhatTuId",
                table: "RefeshToken",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_XacNhanEmail_PhatTuId",
                table: "XacNhanEmail",
                column: "PhatTuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonDangKy");

            migrationBuilder.DropTable(
                name: "NDThichBinhLuanBaiViet");

            migrationBuilder.DropTable(
                name: "NguoiDungThichBaiViet");

            migrationBuilder.DropTable(
                name: "PhatTuDaoTrang");

            migrationBuilder.DropTable(
                name: "RefeshToken");

            migrationBuilder.DropTable(
                name: "XacNhanEmail");

            migrationBuilder.DropTable(
                name: "TrangThaiDon");

            migrationBuilder.DropTable(
                name: "BinhLuanBaiViet");

            migrationBuilder.DropTable(
                name: "DaoTrang");

            migrationBuilder.DropTable(
                name: "BaiViet");

            migrationBuilder.DropTable(
                name: "LoaiBaiViet");

            migrationBuilder.DropTable(
                name: "PhatTu");

            migrationBuilder.DropTable(
                name: "TrangThaiBaiViet");

            migrationBuilder.DropTable(
                name: "Chua");

            migrationBuilder.DropTable(
                name: "QuyenHan");
        }
    }
}
