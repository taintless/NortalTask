using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eShop.Migrations
{
    public partial class AddedOsIdToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Oses_OsId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "OsId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Oses_OsId",
                table: "Products",
                column: "OsId",
                principalTable: "Oses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Oses_OsId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "OsId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Oses_OsId",
                table: "Products",
                column: "OsId",
                principalTable: "Oses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
