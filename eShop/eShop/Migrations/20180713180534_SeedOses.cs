using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eShop.Migrations
{
    public partial class SeedOses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO [Oses] ([Name], [IconName])
                VALUES ('Android', 'android'), ('iOS', 'apple-ios'), ('Windows', 'windows');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
