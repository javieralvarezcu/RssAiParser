using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RssAiParser.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OriginalNews",
                columns: table => new
                {
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Titular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtitulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuerpo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OriginalNews", x => x.Url);
                });

            migrationBuilder.CreateTable(
                name: "ParsedNews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtitulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuerpo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParsingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginalId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParsedNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParsedNews_OriginalNews_OriginalId",
                        column: x => x.OriginalId,
                        principalTable: "OriginalNews",
                        principalColumn: "Url",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParsedNews_OriginalId",
                table: "ParsedNews",
                column: "OriginalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParsedNews");

            migrationBuilder.DropTable(
                name: "OriginalNews");
        }
    }
}
