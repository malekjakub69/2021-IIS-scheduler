using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class ScheduleUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Leaders_LeaderId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Participants_ParticipantId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "SchedulerUsers");

            migrationBuilder.RenameIndex(
                name: "IX_User_ParticipantId",
                table: "SchedulerUsers",
                newName: "IX_SchedulerUsers_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_User_LeaderId",
                table: "SchedulerUsers",
                newName: "IX_SchedulerUsers_LeaderId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchedulerUsers",
                table: "SchedulerUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SchedulerUsers_Leaders_LeaderId",
                table: "SchedulerUsers",
                column: "LeaderId",
                principalTable: "Leaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchedulerUsers_Participants_ParticipantId",
                table: "SchedulerUsers",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerUsers_Leaders_LeaderId",
                table: "SchedulerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerUsers_Participants_ParticipantId",
                table: "SchedulerUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchedulerUsers",
                table: "SchedulerUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Schedules");

            migrationBuilder.RenameTable(
                name: "SchedulerUsers",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_SchedulerUsers_ParticipantId",
                table: "User",
                newName: "IX_User_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_SchedulerUsers_LeaderId",
                table: "User",
                newName: "IX_User_LeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Leaders_LeaderId",
                table: "User",
                column: "LeaderId",
                principalTable: "Leaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Participants_ParticipantId",
                table: "User",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
