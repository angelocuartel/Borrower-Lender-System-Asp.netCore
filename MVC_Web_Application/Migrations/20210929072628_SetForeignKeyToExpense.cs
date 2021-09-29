using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Web_Application.Migrations
{
    public partial class SetForeignKeyToExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Expenses",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Expenses",
                newName: "id");
        }
    }
}
