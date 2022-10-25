using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisterApi.DAL.Migrations
{
    public partial class ChangedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotebookUserAccounts",
                table: "NotebookUserAccounts");

            migrationBuilder.RenameTable(
                name: "NotebookUserAccounts",
                newName: "RegisterUserAccounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisterUserAccounts",
                table: "RegisterUserAccounts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisterUserAccounts",
                table: "RegisterUserAccounts");

            migrationBuilder.RenameTable(
                name: "RegisterUserAccounts",
                newName: "NotebookUserAccounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotebookUserAccounts",
                table: "NotebookUserAccounts",
                column: "Id");
        }
    }
}
