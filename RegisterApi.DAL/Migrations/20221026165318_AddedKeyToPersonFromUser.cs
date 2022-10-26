using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisterApi.DAL.Migrations
{
    public partial class AddedKeyToPersonFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "UserInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserInformation_PersonId",
                table: "UserInformation",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInformation_PersonInformation_PersonId",
                table: "UserInformation",
                column: "PersonId",
                principalTable: "PersonInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInformation_PersonInformation_PersonId",
                table: "UserInformation");

            migrationBuilder.DropIndex(
                name: "IX_UserInformation_PersonId",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "UserInformation");
        }
    }
}
