using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPMSwebapp.Data.Migrations
{
    public partial class dbupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilenameOriginal",
                table: "Paper");

            migrationBuilder.AlterColumn<string>(
                name: "Filename",
                table: "Paper",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldMaxLength: 2147483647,
                oldNullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<byte[]>(
                name: "Filename",
                table: "Paper",
                type: "varbinary(max)",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilenameOriginal",
                table: "Paper",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "");
        }
    }
}
