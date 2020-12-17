using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDomainEntity.Migrations
{
    public partial class databasemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesTb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    IdentityNumber = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    Salary = table.Column<long>(nullable: false),
                    Currency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesTb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberTb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumberTb_EmployeesTb_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeesTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumberTb_EmployeeId",
                table: "PhoneNumberTb",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumberTb");

            migrationBuilder.DropTable(
                name: "EmployeesTb");
        }
    }
}
