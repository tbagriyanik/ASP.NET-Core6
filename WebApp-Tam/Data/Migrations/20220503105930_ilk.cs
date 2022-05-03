using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Tam.Data.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kampanya",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KampanyaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kampanya", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Urun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<float>(type: "real", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urun_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Urun_KategoriId",
                table: "Urun",
                column: "KategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kampanya");

            migrationBuilder.DropTable(
                name: "Urun");

            migrationBuilder.DropTable(
                name: "Kategori");
        }
    }
}
