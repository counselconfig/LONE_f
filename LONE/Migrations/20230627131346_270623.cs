using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LONE.Migrations
{
    /// <inheritdoc />
    public partial class _270623 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    request_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    subject_forename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subject_surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    other_forename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    other_surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birth_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    death_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_of_birth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_address_town_city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_address_county = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_address_postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_address_country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestor_agent = table.Column<bool>(type: "bit", nullable: true),
                    agent_fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    agent_address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    agent_contact_address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    agent_town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    agent_contact_address_county = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    agent_postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    agent_country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.request_id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    enquiry_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    request_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    transaction_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "30000, 1"),
                    session_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    finished = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    amount_received = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.enquiry_id);
                    table.ForeignKey(
                        name: "FK_Payments_Requests_request_id",
                        column: x => x.request_id,
                        principalTable: "Requests",
                        principalColumn: "request_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_request_id",
                table: "Payments",
                column: "request_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
