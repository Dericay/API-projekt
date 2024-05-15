using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_projekt.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    companyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.companyId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    appointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    companyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.appointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Companys_companyId",
                        column: x => x.companyId,
                        principalTable: "Companys",
                        principalColumn: "companyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "companyId", "Adress", "Email", "Phone", "companyName" },
                values: new object[,]
                {
                    { 1, "Frigatan 2", "Google@gmail.com", "021312459", "Google" },
                    { 2, "Ängsgatan 4", "facebook@hotmail.com", "02131249124", "Facebook" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customerId", "Address", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Solgatan 13", "anton@gmail.com", "Anton", "Larsson", "021302145921" },
                    { 2, "Mångatan 26", "alfred@gmail.com", "Alfred", "Larsson", "0713021421" },
                    { 3, "Storgatan 5", "anas@qlok.com", "Anas", "Qlok", "07231249213" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "appointmentId", "EndTime", "StartTime", "companyId", "customerId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 21, 10, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 21, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 5, 25, 12, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 11, 10, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, new DateTime(2024, 5, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 4, new DateTime(2024, 5, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 5, new DateTime(2024, 6, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_companyId",
                table: "Appointments",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_customerId",
                table: "Appointments",
                column: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
