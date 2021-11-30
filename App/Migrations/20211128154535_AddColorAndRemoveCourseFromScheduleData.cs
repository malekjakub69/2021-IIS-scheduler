using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddColorAndRemoveCourseFromScheduleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDatas_Courses_CourseId",
                table: "ScheduleDatas");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleDatas_CourseId",
                table: "ScheduleDatas");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "ScheduleDatas");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Participants",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Participants");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "ScheduleDatas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDatas_CourseId",
                table: "ScheduleDatas",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDatas_Courses_CourseId",
                table: "ScheduleDatas",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
