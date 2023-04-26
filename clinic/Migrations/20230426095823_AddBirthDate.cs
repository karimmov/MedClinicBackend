using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinic.Migrations
{
    /// <inheritdoc />
    public partial class AddBirthDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "clientaddress",
                table: "clients");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "clients",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "clients");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "clients",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "clients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "clientaddress",
                table: "clients",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
