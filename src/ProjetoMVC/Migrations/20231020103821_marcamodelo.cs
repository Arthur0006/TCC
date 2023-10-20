using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMVC.Migrations
{
    public partial class marcamodelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MecanicaFotosModel_MecanicaModel_MecanicaId",
                table: "MecanicaFotosModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MecanicaModel_AspNetUsers_UsuarioId",
                table: "MecanicaModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MecanicaModel",
                table: "MecanicaModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MecanicaFotosModel",
                table: "MecanicaFotosModel");

            migrationBuilder.RenameTable(
                name: "MecanicaModel",
                newName: "Mecanicas");

            migrationBuilder.RenameTable(
                name: "MecanicaFotosModel",
                newName: "MecanicaFotos");

            migrationBuilder.RenameIndex(
                name: "IX_MecanicaModel_UsuarioId",
                table: "Mecanicas",
                newName: "IX_Mecanicas_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_MecanicaFotosModel_MecanicaId",
                table: "MecanicaFotos",
                newName: "IX_MecanicaFotos_MecanicaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mecanicas",
                table: "Mecanicas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MecanicaFotos",
                table: "MecanicaFotos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_MarcaId",
                table: "Modelos",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MecanicaFotos_Mecanicas_MecanicaId",
                table: "MecanicaFotos",
                column: "MecanicaId",
                principalTable: "Mecanicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mecanicas_AspNetUsers_UsuarioId",
                table: "Mecanicas",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MecanicaFotos_Mecanicas_MecanicaId",
                table: "MecanicaFotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Mecanicas_AspNetUsers_UsuarioId",
                table: "Mecanicas");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mecanicas",
                table: "Mecanicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MecanicaFotos",
                table: "MecanicaFotos");

            migrationBuilder.RenameTable(
                name: "Mecanicas",
                newName: "MecanicaModel");

            migrationBuilder.RenameTable(
                name: "MecanicaFotos",
                newName: "MecanicaFotosModel");

            migrationBuilder.RenameIndex(
                name: "IX_Mecanicas_UsuarioId",
                table: "MecanicaModel",
                newName: "IX_MecanicaModel_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_MecanicaFotos_MecanicaId",
                table: "MecanicaFotosModel",
                newName: "IX_MecanicaFotosModel_MecanicaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MecanicaModel",
                table: "MecanicaModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MecanicaFotosModel",
                table: "MecanicaFotosModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MecanicaFotosModel_MecanicaModel_MecanicaId",
                table: "MecanicaFotosModel",
                column: "MecanicaId",
                principalTable: "MecanicaModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MecanicaModel_AspNetUsers_UsuarioId",
                table: "MecanicaModel",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
