using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalabatWebAspDotNetCoreApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_delivery_person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DeliveryPersonId",
                table: "Deliveries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DeliveryPersonId",
                table: "Deliveries",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
