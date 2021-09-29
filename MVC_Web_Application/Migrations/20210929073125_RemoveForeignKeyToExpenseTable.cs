using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Web_Application.Migrations
{
    public partial class RemoveForeignKeyToExpenseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseCategories_ExpenseCategoryCategoryId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenseCategoryCategoryId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseCategoryCategoryId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Expenses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenseCategoryCategoryId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseCategoryCategoryId",
                table: "Expenses",
                column: "ExpenseCategoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseCategories_ExpenseCategoryCategoryId",
                table: "Expenses",
                column: "ExpenseCategoryCategoryId",
                principalTable: "ExpenseCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
