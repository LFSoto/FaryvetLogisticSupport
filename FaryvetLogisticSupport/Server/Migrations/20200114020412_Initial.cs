using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaryvetLogisticSupport.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FARYVET");

            migrationBuilder.CreateTable(
                name: "FLS_Conductores",
                schema: "FARYVET",
                columns: table => new
                {
                    cedula = table.Column<string>(nullable: false),
                    nombre = table.Column<string>(nullable: false),
                    apellido1 = table.Column<string>(nullable: false),
                    apellido2 = table.Column<string>(nullable: false),
                    licenciaB = table.Column<int>(nullable: false),
                    fechaVencimientoB = table.Column<DateTime>(type: "date", nullable: false),
                    licenciaA = table.Column<int>(nullable: false),
                    fechaVencimientoA = table.Column<DateTime>(type: "date", nullable: false),
                    estado = table.Column<string>(nullable: false),
                    fechaContrado = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLS_Conductores", x => x.cedula);
                });

            migrationBuilder.CreateTable(
                name: "FLS_DisionesGeograficas",
                schema: "FARYVET",
                columns: table => new
                {
                    codigoPostal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ubicacion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLS_DisionesGeograficas", x => x.codigoPostal);
                });

            migrationBuilder.CreateTable(
                name: "FLS_Vehiculos",
                schema: "FARYVET",
                columns: table => new
                {
                    placa = table.Column<string>(nullable: false),
                    capacidadCarga = table.Column<float>(nullable: false),
                    estado = table.Column<string>(nullable: false),
                    CVOSenasa = table.Column<bool>(nullable: false),
                    fechaVencimientoCVOSenasa = table.Column<DateTime>(type: "date", nullable: false),
                    marca = table.Column<string>(nullable: false),
                    modelo = table.Column<string>(nullable: false),
                    annioFabricacion = table.Column<int>(nullable: false),
                    licenciaRequerida = table.Column<string>(maxLength: 2, nullable: false),
                    salidaPais = table.Column<bool>(nullable: false),
                    fechaVencimientoSalidaPais = table.Column<DateTime>(type: "date", nullable: false),
                    isReparto = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLS_Vehiculos", x => x.placa);
                });

            migrationBuilder.CreateTable(
                name: "FLS_Entregas",
                schema: "FARYVET",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chofer = table.Column<string>(nullable: false),
                    vehiculo = table.Column<string>(nullable: false),
                    peso = table.Column<float>(nullable: false),
                    costo = table.Column<float>(nullable: false),
                    comentarios = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: false),
                    kilometrajeSalida = table.Column<float>(nullable: false),
                    kilometrajeLlegada = table.Column<float>(nullable: false),
                    fechaSalida = table.Column<DateTime>(type: "date", nullable: false),
                    fechaLlegada = table.Column<DateTime>(type: "date", nullable: false),
                    costoOperativo = table.Column<float>(nullable: false),
                    recargaCombustible = table.Column<bool>(nullable: false),
                    comentariosLlegada = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLS_Entregas", x => x.id);
                    table.ForeignKey(
                        name: "FK_FLS_Entregas_FLS_Conductores_chofer",
                        column: x => x.chofer,
                        principalSchema: "FARYVET",
                        principalTable: "FLS_Conductores",
                        principalColumn: "cedula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FLS_Entregas_FLS_Vehiculos_vehiculo",
                        column: x => x.vehiculo,
                        principalSchema: "FARYVET",
                        principalTable: "FLS_Vehiculos",
                        principalColumn: "placa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FLS_Facturas",
                schema: "FARYVET",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    entrega = table.Column<int>(nullable: false),
                    formaDespacho = table.Column<string>(nullable: false),
                    pesoTotal = table.Column<float>(nullable: false),
                    formaCobro = table.Column<string>(nullable: false),
                    moneda = table.Column<string>(nullable: false),
                    montoTotal = table.Column<float>(nullable: false),
                    nombreCliente = table.Column<string>(nullable: false),
                    comentarios = table.Column<string>(nullable: true),
                    estado = table.Column<string>(nullable: false),
                    ubicacion = table.Column<int>(nullable: false),
                    direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLS_Facturas", x => x.id);
                    table.ForeignKey(
                        name: "FK_FLS_Facturas_FLS_Entregas_entrega",
                        column: x => x.entrega,
                        principalSchema: "FARYVET",
                        principalTable: "FLS_Entregas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FLS_Facturas_FLS_DisionesGeograficas_ubicacion",
                        column: x => x.ubicacion,
                        principalSchema: "FARYVET",
                        principalTable: "FLS_DisionesGeograficas",
                        principalColumn: "codigoPostal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FLS_Entregas_chofer",
                schema: "FARYVET",
                table: "FLS_Entregas",
                column: "chofer");

            migrationBuilder.CreateIndex(
                name: "IX_FLS_Entregas_vehiculo",
                schema: "FARYVET",
                table: "FLS_Entregas",
                column: "vehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_FLS_Facturas_entrega",
                schema: "FARYVET",
                table: "FLS_Facturas",
                column: "entrega");

            migrationBuilder.CreateIndex(
                name: "IX_FLS_Facturas_ubicacion",
                schema: "FARYVET",
                table: "FLS_Facturas",
                column: "ubicacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FLS_Facturas",
                schema: "FARYVET");

            migrationBuilder.DropTable(
                name: "FLS_Entregas",
                schema: "FARYVET");

            migrationBuilder.DropTable(
                name: "FLS_DisionesGeograficas",
                schema: "FARYVET");

            migrationBuilder.DropTable(
                name: "FLS_Conductores",
                schema: "FARYVET");

            migrationBuilder.DropTable(
                name: "FLS_Vehiculos",
                schema: "FARYVET");
        }
    }
}
