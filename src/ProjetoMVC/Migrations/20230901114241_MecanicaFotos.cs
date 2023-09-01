using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMVC.Migrations
{
    public partial class MecanicaFotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MecanicaFotosModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Padrao = table.Column<bool>(type: "bit", nullable: false),
                    MecanicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MecanicaFotosModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MecanicaFotosModel_MecanicaModel_MecanicaId",
                        column: x => x.MecanicaId,
                        principalTable: "MecanicaModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MecanicaFotosModel_MecanicaId",
                table: "MecanicaFotosModel",
                column: "MecanicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MecanicaFotosModel");
        }
    }
}
