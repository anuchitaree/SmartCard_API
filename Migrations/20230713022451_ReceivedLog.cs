using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartCard_API.Migrations
{
    public partial class ReceivedLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceivedLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartNoSubAssy = table.Column<string>(type: "text", nullable: false),
                    LotId = table.Column<long>(type: "bigint", nullable: false),
                    TimeStamp = table.Column<string>(type: "text", nullable: false),
                    StockReceived = table.Column<bool>(type: "boolean", nullable: false),
                    StockSent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Smartcards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Partnumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Partname0 = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Partname1 = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Partname2 = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Partname3 = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smartcards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceivedLogs");

            migrationBuilder.DropTable(
                name: "Smartcards");
        }
    }
}
