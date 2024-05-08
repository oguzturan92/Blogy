using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class start2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Writer",
                newName: "WriterName");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Writer",
                newName: "WriterImageUrl");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Writer",
                newName: "WriterDescription");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Articles",
                newName: "ArticleTitle");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Articles",
                newName: "ArticleDescription");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Articles",
                newName: "ArticleCreatedDate");

            migrationBuilder.RenameColumn(
                name: "CoverImageUrl",
                table: "Articles",
                newName: "ArticleCoverImageUrl");

            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageFullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.RenameColumn(
                name: "WriterName",
                table: "Writer",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "WriterImageUrl",
                table: "Writer",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "WriterDescription",
                table: "Writer",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ArticleTitle",
                table: "Articles",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ArticleDescription",
                table: "Articles",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ArticleCreatedDate",
                table: "Articles",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "ArticleCoverImageUrl",
                table: "Articles",
                newName: "CoverImageUrl");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");
        }
    }
}
