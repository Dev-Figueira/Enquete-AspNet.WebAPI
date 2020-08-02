using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PollIO.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    Views = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OptionsPolls",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PollId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    Votes = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionsPolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionsPolls_Polls_PollId",
                        column: x => x.PollId,
                        principalTable: "Polls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OptionsPolls_PollId",
                table: "OptionsPolls",
                column: "PollId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptionsPolls");

            migrationBuilder.DropTable(
                name: "Polls");
        }
    }
}
