using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareaAPiXD.Migrations
{
    /// <inheritdoc />
    public partial class EntrevistaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entrevistadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDelEntrevistador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrevistadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "entrevistados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDelEntrevistador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hojadevida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrevistados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hojadevidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hojadevidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "detalleEntrevistadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrevistadoId = table.Column<int>(type: "int", nullable: false),
                    HojadevidaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleEntrevistadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalleEntrevistadores_entrevistados_EntrevistadoId",
                        column: x => x.EntrevistadoId,
                        principalTable: "entrevistados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleEntrevistadores_hojadevidas_HojadevidaId",
                        column: x => x.HojadevidaId,
                        principalTable: "hojadevidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalleHojadevidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntrevistadoId = table.Column<int>(type: "int", nullable: false),
                    HojadevidaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleHojadevidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalleHojadevidas_entrevistados_EntrevistadoId",
                        column: x => x.EntrevistadoId,
                        principalTable: "entrevistados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleHojadevidas_hojadevidas_HojadevidaId",
                        column: x => x.HojadevidaId,
                        principalTable: "hojadevidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "entrevistadores",
                columns: new[] { "Id", "Activo", "NombreDelEntrevistador", "edad" },
                values: new object[] { 1, true, "Edwin", 22 });

            migrationBuilder.InsertData(
                table: "entrevistados",
                columns: new[] { "Id", "Activo", "Area", "Hojadevida", "NombreDelEntrevistador" },
                values: new object[] { 1, true, "desarrollador junior", "aceptada", "Edwin" });

            migrationBuilder.InsertData(
                table: "hojadevidas",
                columns: new[] { "Id", "Disponible", "departamento" },
                values: new object[] { 1, true, "Programadores" });

            migrationBuilder.InsertData(
                table: "detalleEntrevistadores",
                columns: new[] { "Id", "EntrevistadoId", "HojadevidaId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "detalleHojadevidas",
                columns: new[] { "Id", "EntrevistadoId", "HojadevidaId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_detalleEntrevistadores_EntrevistadoId",
                table: "detalleEntrevistadores",
                column: "EntrevistadoId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleEntrevistadores_HojadevidaId",
                table: "detalleEntrevistadores",
                column: "HojadevidaId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleHojadevidas_EntrevistadoId",
                table: "detalleHojadevidas",
                column: "EntrevistadoId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleHojadevidas_HojadevidaId",
                table: "detalleHojadevidas",
                column: "HojadevidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleEntrevistadores");

            migrationBuilder.DropTable(
                name: "detalleHojadevidas");

            migrationBuilder.DropTable(
                name: "entrevistadores");

            migrationBuilder.DropTable(
                name: "entrevistados");

            migrationBuilder.DropTable(
                name: "hojadevidas");
        }
    }
}
