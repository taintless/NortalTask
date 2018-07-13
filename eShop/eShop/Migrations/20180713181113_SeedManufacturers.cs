using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eShop.Migrations
{
    public partial class SeedManufacturers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO [Manufacturers] ([Name])
                VALUES ('Sony'), ('Apple'), ('HTC'), ('Samsung'), ('Nokia'), ('ZTE');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
