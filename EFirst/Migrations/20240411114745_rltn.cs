using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFirst.Migrations
{
    /// <inheritdoc />
    public partial class rltn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Tags_TagsId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TagsId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TagsId",
                table: "Posts");

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagsId",
                table: "PostTags",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.AddColumn<int>(
                name: "TagsId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TagsId",
                table: "Posts",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Tags_TagsId",
                table: "Posts",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}
