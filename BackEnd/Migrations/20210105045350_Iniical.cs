using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BackEnd.Migrations
{
    public partial class Iniical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "basicos");

            migrationBuilder.CreateTable(
                name: "Sexos",
                schema: "basicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoIdentificacions",
                schema: "basicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificacions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombres = table.Column<string>(type: "character varying", maxLength: 20, nullable: false),
                    Apellidos = table.Column<string>(type: "character varying", maxLength: 30, nullable: false),
                    Direccion = table.Column<string>(type: "character varying", maxLength: 60, nullable: false),
                    Telefono = table.Column<string>(type: "character varying", maxLength: 11, nullable: false),
                    SexoId = table.Column<int>(type: "integer", nullable: false),
                    TipoIdentififcacionId = table.Column<int>(type: "integer", nullable: false),
                    Personas_TipoIdentificacions = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_TipoIdentificacions_Personas_TipoIdentificacions",
                        column: x => x.Personas_TipoIdentificacions,
                        principalSchema: "basicos",
                        principalTable: "TipoIdentificacions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Personas_Sexos",
                        column: x => x.SexoId,
                        principalSchema: "basicos",
                        principalTable: "Sexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Personas_TipoIdentificacions",
                table: "Personas",
                column: "Personas_TipoIdentificacions");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_SexoId",
                table: "Personas",
                column: "SexoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "TipoIdentificacions",
                schema: "basicos");

            migrationBuilder.DropTable(
                name: "Sexos",
                schema: "basicos");
        }
    }
}
