using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class fixCourseMN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseLeader_Leaders_LeaderId",
                table: "CourseLeader");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseParticipant_Participants_ParticipantId",
                table: "CourseParticipant");

            migrationBuilder.DropColumn(
                name: "ParticipantListId",
                table: "CourseParticipant");

            migrationBuilder.DropColumn(
                name: "LeaderListId",
                table: "CourseLeader");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParticipantId",
                table: "CourseParticipant",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LeaderId",
                table: "CourseLeader",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseLeader_Leaders_LeaderId",
                table: "CourseLeader",
                column: "LeaderId",
                principalTable: "Leaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseParticipant_Participants_ParticipantId",
                table: "CourseParticipant",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseLeader_Leaders_LeaderId",
                table: "CourseLeader");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseParticipant_Participants_ParticipantId",
                table: "CourseParticipant");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParticipantId",
                table: "CourseParticipant",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantListId",
                table: "CourseParticipant",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "LeaderId",
                table: "CourseLeader",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "LeaderListId",
                table: "CourseLeader",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_CourseLeader_Leaders_LeaderId",
                table: "CourseLeader",
                column: "LeaderId",
                principalTable: "Leaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseParticipant_Participants_ParticipantId",
                table: "CourseParticipant",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
