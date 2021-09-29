using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Web_Application.Migrations
{
    public partial class ChangeForeignKeyNameToExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Expenses",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Expenses",
                newName: "CategoryId");
        }
    }
}
