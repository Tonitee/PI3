using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtividadeAula10.Migrations
{
    public partial class AddPlataforma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plataforma",
                table: "Produto");

            migrationBuilder.AddColumn<int>(
                name: "PlataformaId",
                table: "Produto",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Plataforma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plataforma", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PlataformaId",
                table: "Produto",
                column: "PlataformaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Plataforma_PlataformaId",
                table: "Produto",
                column: "PlataformaId",
                principalTable: "Plataforma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Plataforma_PlataformaId",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Plataforma");

            migrationBuilder.DropIndex(
                name: "IX_Produto_PlataformaId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "PlataformaId",
                table: "Produto");

            migrationBuilder.AddColumn<string>(
                name: "Plataforma",
                table: "Produto",
                nullable: true);
        }
    }
}
