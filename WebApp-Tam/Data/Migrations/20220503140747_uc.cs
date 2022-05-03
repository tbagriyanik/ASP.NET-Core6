using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_Tam.Data.Migrations
{
    public partial class uc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mesaj",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yollayanMaili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mesaji = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yollanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    okunduMu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesaj", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mesaj");
        }
    }
}
