using Microsoft.EntityFrameworkCore.Migrations;

namespace FaryvetLogisticSupport.Server.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fechaContrado",
                schema: "FARYVET",
                table: "FLS_Conductores",
                newName: "fechaDeContratacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fechaDeContratacion",
                schema: "FARYVET",
                table: "FLS_Conductores",
                newName: "fechaContrado");
        }
    }
}
