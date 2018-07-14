using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eShop.Migrations
{
    public partial class AddOses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OsId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Oses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    IconName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OsId",
                table: "Products",
                column: "OsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Oses_OsId",
                table: "Products",
                column: "OsId",
                principalTable: "Oses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Oses_OsId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Oses");

            migrationBuilder.DropIndex(
                name: "IX_Products_OsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OsId",
                table: "Products");
        }
    }
}
