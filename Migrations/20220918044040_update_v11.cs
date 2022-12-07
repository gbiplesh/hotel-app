using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApp.Migrations
{
    public partial class update_v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
            name: "FirstName",
            table: "Checkout",
            newName: "FullName");

            migrationBuilder.RenameColumn(
            name: "LastName",
            table: "Checkout",
            newName: "PreferredName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
