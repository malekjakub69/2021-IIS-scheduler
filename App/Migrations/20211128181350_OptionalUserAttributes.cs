using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class OptionalUserAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerUsers_Leaders_LeaderId",
                table: "SchedulerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerUsers_Participants_ParticipantId",
                table: "SchedulerUsers");

            migrationBuilder.DropIndex(
                name: "IX_SchedulerUsers_LeaderId",
                table: "SchedulerUsers");

            migrationBuilder.DropIndex(
                name: "IX_SchedulerUsers_ParticipantId",
                table: "SchedulerUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParticipantId",
                table: "SchedulerUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "LeaderId",
                table: "SchedulerUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerUsers_LeaderId",
                table: "SchedulerUsers",
                column: "LeaderId",
                unique: true,
                filter: "[LeaderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerUsers_ParticipantId",
                table: "SchedulerUsers",
                column: "ParticipantId",
                unique: true,
                filter: "[ParticipantId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SchedulerUsers_Leaders_LeaderId",
                table: "SchedulerUsers",
                column: "LeaderId",
                principalTable: "Leaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchedulerUsers_Participants_ParticipantId",
                table: "SchedulerUsers",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerUsers_Leaders_LeaderId",
                table: "SchedulerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerUsers_Participants_ParticipantId",
                table: "SchedulerUsers");

            migrationBuilder.DropIndex(
                name: "IX_SchedulerUsers_LeaderId",
                table: "SchedulerUsers");

            migrationBuilder.DropIndex(
                name: "IX_SchedulerUsers_ParticipantId",
                table: "SchedulerUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParticipantId",
                table: "SchedulerUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LeaderId",
                table: "SchedulerUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerUsers_LeaderId",
                table: "SchedulerUsers",
                column: "LeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerUsers_ParticipantId",
                table: "SchedulerUsers",
                column: "ParticipantId",
                unique: true);

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
    }
}
