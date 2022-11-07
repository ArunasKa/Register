using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisterApi.DAL.Migrations
{
    public partial class RemovedTableFormImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonInformation_Image_ProfilePictureId",
                table: "PersonInformation");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_PersonInformation_ProfilePictureId",
                table: "PersonInformation");

            migrationBuilder.DropColumn(
                name: "ProfilePictureId",
                table: "PersonInformation");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageBytes",
                table: "PersonInformation",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "ImageContentType",
                table: "PersonInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "PersonInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBytes",
                table: "PersonInformation");

            migrationBuilder.DropColumn(
                name: "ImageContentType",
                table: "PersonInformation");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "PersonInformation");

            migrationBuilder.AddColumn<int>(
                name: "ProfilePictureId",
                table: "PersonInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInformation_ProfilePictureId",
                table: "PersonInformation",
                column: "ProfilePictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInformation_Image_ProfilePictureId",
                table: "PersonInformation",
                column: "ProfilePictureId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
