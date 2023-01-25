﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCodeFirstTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentHasScholarshipColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasScholarship",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasScholarship",
                table: "Students");
        }
    }
}
