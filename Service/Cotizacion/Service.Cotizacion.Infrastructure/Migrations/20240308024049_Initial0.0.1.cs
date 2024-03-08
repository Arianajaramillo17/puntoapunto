using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Cotizacion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cotiza");

            migrationBuilder.CreateTable(
                name: "EstadosCotizaciones",
                schema: "cotiza",
                columns: table => new
                {
                    EstadoCotizacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosCotizaciones", x => x.EstadoCotizacionId);
                });

            migrationBuilder.CreateTable(
                name: "TiposMateriales",
                schema: "cotiza",
                columns: table => new
                {
                    TipoMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMateriales", x => x.TipoMaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                schema: "cotiza",
                columns: table => new
                {
                    CotizacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoCotizacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => x.CotizacionId);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_EstadosCotizaciones_EstadoCotizacionId",
                        column: x => x.EstadoCotizacionId,
                        principalSchema: "cotiza",
                        principalTable: "EstadosCotizaciones",
                        principalColumn: "EstadoCotizacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialesPrimarios",
                schema: "cotiza",
                columns: table => new
                {
                    MaterialPrimarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialesPrimarios", x => x.MaterialPrimarioId);
                    table.ForeignKey(
                        name: "FK_MaterialesPrimarios_TiposMateriales_TipoMaterialId",
                        column: x => x.TipoMaterialId,
                        principalSchema: "cotiza",
                        principalTable: "TiposMateriales",
                        principalColumn: "TipoMaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionesDetalles",
                schema: "cotiza",
                columns: table => new
                {
                    CotizacionDetalleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CotizacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialPrimarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionesDetalles", x => x.CotizacionDetalleId);
                    table.ForeignKey(
                        name: "FK_CotizacionesDetalles_Cotizaciones_CotizacionId",
                        column: x => x.CotizacionId,
                        principalSchema: "cotiza",
                        principalTable: "Cotizaciones",
                        principalColumn: "CotizacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CotizacionesDetalles_MaterialesPrimarios_MaterialPrimarioId",
                        column: x => x.MaterialPrimarioId,
                        principalSchema: "cotiza",
                        principalTable: "MaterialesPrimarios",
                        principalColumn: "MaterialPrimarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_EstadoCotizacionId",
                schema: "cotiza",
                table: "Cotizaciones",
                column: "EstadoCotizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionesDetalles_CotizacionId",
                schema: "cotiza",
                table: "CotizacionesDetalles",
                column: "CotizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionesDetalles_MaterialPrimarioId",
                schema: "cotiza",
                table: "CotizacionesDetalles",
                column: "MaterialPrimarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesPrimarios_TipoMaterialId",
                schema: "cotiza",
                table: "MaterialesPrimarios",
                column: "TipoMaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotizacionesDetalles",
                schema: "cotiza");

            migrationBuilder.DropTable(
                name: "Cotizaciones",
                schema: "cotiza");

            migrationBuilder.DropTable(
                name: "MaterialesPrimarios",
                schema: "cotiza");

            migrationBuilder.DropTable(
                name: "EstadosCotizaciones",
                schema: "cotiza");

            migrationBuilder.DropTable(
                name: "TiposMateriales",
                schema: "cotiza");
        }
    }
}
