using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCar.Migrations
{
    /// <inheritdoc />
    public partial class ChatUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ChatUsers",
                columns: table => new
                {
                    ChatUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserNameActualChatUser = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUsers", x => x.ChatUserId);
                    table.ForeignKey(
                        name: "FK_ChatUsers_AspNetUsers_ChatUserId",
                        column: x => x.ChatUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChatUsers_AspNetUsers_UserNameActualChatUser",
                        column: x => x.UserNameActualChatUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_UserNameActualChatUser",
                table: "ChatUsers",
                column: "UserNameActualChatUser",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_UserName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }
    }
}
