using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Archive.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EfolderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_folders_folders_EfolderId",
                        column: x => x.EfolderId,
                        principalTable: "folders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EfolderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_folders_EfolderId",
                        column: x => x.EfolderId,
                        principalTable: "folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_EfolderId",
                table: "Files",
                column: "EfolderId");

            migrationBuilder.CreateIndex(
                name: "IX_folders_EfolderId",
                table: "folders",
                column: "EfolderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "folders");
        }
    }
}
