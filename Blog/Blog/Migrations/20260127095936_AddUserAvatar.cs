using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAvatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarPath",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 27, 16, 59, 33, 805, DateTimeKind.Local).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 27, 16, 59, 33, 805, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 27, 16, 59, 33, 805, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 27, 16, 59, 33, 805, DateTimeKind.Local).AddTicks(7951));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 27, 16, 59, 33, 805, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 27, 16, 59, 33, 805, DateTimeKind.Local).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 27, 16, 59, 33, 805, DateTimeKind.Local).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 27, 16, 59, 33, 805, DateTimeKind.Local).AddTicks(7927));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 27, 16, 59, 33, 805, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 27, 16, 59, 33, 805, DateTimeKind.Local).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "AvatarPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "AvatarPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "AvatarPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "AvatarPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "AvatarPath",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarPath",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2491));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 23, 28, 35, 241, DateTimeKind.Local).AddTicks(2412));
        }
    }
}
