using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historicos",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD_JOGADOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TENTATIVA = table.Column<int>(type: "int", nullable: false),
                    DT_HR_TENTATIVA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RESULTADO = table.Column<int>(type: "int", nullable: false),
                    Chute = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historicos", x => x._id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historicos");
        }
    }
}
