using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.Migrations
{
    public partial class Books_Entity_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Publisher = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    AuthorLastName = table.Column<string>(nullable: true),
                    AuthorFirstName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    MlaCitation = table.Column<string>(nullable: true),
                    ChicagoCitation = table.Column<string>(nullable: true),
                    JournalTitle = table.Column<string>(nullable: true),
                    PublicationDate = table.Column<DateTime>(nullable: false),
                    PageRange = table.Column<string>(nullable: true),
                    VolumeNumber = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
