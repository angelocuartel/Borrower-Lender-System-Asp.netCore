using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Web_Application.Migrations
{
    public partial class ChangeExpenseColumnPropToAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Expenses",
                newName: "ExpenseAmount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseAmount",
                table: "Expenses",
                newName: "MyProperty");
        }
    }
}
