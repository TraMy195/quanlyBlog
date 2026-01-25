using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Tin công nghệ", "Công nghệ" },
                    { 2, "Tin giải trí", "Giải trí" },
                    { 3, "Tin thể thao", "Thể thao" },
                    { 4, "Tin giáo dục", "Giáo dục" },
                    { 5, "Tin kinh tế", "Kinh tế" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FullName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", "Admin", "123", "Admin", "admin" },
                    { 2, "editor1@gmail.com", "Editor One", "123", "Editor", "editor1" },
                    { 3, "editor2@gmail.com", "Editor Two", "123", "Editor", "editor2" },
                    { 4, "reader1@gmail.com", "Reader One", "123", "Reader", "reader1" },
                    { 5, "reader2@gmail.com", "Reader Two", "123", "Reader", "reader2" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AuthorId", "CategoryId", "Content", "CreatedAt", "ImagePath", "Status", "Title", "Views" },
                values: new object[,]
                {
                    { 1, 2, 1, "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2381), null, "Công khai", "Bài viết công nghệ", 10 },
                    { 2, 2, 2, "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB", new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2407), null, "Công khai", "Bài viết giải trí", 5 },
                    { 3, 3, 3, "CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC", new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2409), null, "Công khai", "Bài viết thể thao", 20 },
                    { 4, 3, 4, "DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD", new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2411), null, "Công khai", "Bài viết giáo dục", 7 },
                    { 5, 2, 5, "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE", new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2412), null, "Công khai", "Bài viết kinh tế", 15 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "CreatedAt", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Bài hay", new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2491), 1, 4 },
                    { 2, "Rất hữu ích", new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2492), 1, 5 },
                    { 3, "Hay quá", new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2493), 2, 4 },
                    { 4, "Cảm ơn tác giả", new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2494), 3, 5 },
                    { 5, "Đọc rất thích", new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2495), 4, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
