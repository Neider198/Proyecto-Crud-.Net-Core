using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class eliminarPersonas_TipoIdentificacions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TipoIdentificacions_Personas_TipoIdentificacions",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Personas_TipoIdentificacions",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Personas_TipoIdentificacions",
                table: "Personas");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TipoIdentififcacionId",
                table: "Personas",
                column: "TipoIdentififcacionId");

            migrationBuilder.AddForeignKey(
                name: "Personas_TipoIdentificacions",
                table: "Personas",
                column: "TipoIdentififcacionId",
                principalSchema: "basicos",
                principalTable: "TipoIdentificacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Personas_TipoIdentificacions",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_TipoIdentififcacionId",
                table: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "Personas_TipoIdentificacions",
                table: "Personas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Personas_TipoIdentificacions",
                table: "Personas",
                column: "Personas_TipoIdentificacions");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TipoIdentificacions_Personas_TipoIdentificacions",
                table: "Personas",
                column: "Personas_TipoIdentificacions",
                principalSchema: "basicos",
                principalTable: "TipoIdentificacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
