using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMI.Model.Migrations
{
    /// <inheritdoc />
    public partial class cmi002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FAMILY_RELATIONSHIP_STUDENT_StudentId",
                table: "FAMILY_RELATIONSHIP");

            migrationBuilder.DropForeignKey(
                name: "FK_FAMILY_RELATIONSHIP_TEACHER_TeacherId",
                table: "FAMILY_RELATIONSHIP");

            migrationBuilder.DropIndex(
                name: "IX_FAMILY_RELATIONSHIP_StudentId",
                table: "FAMILY_RELATIONSHIP");

            migrationBuilder.DropIndex(
                name: "IX_FAMILY_RELATIONSHIP_TeacherId",
                table: "FAMILY_RELATIONSHIP");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "FAMILY_RELATIONSHIP");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "FAMILY_RELATIONSHIP");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentCategoryId",
                table: "ATTACHMENT",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachmentCategoryId",
                table: "ATTACHMENT");

            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                table: "FAMILY_RELATIONSHIP",
                type: "NUMBER(19)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TeacherId",
                table: "FAMILY_RELATIONSHIP",
                type: "NUMBER(19)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FAMILY_RELATIONSHIP_StudentId",
                table: "FAMILY_RELATIONSHIP",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FAMILY_RELATIONSHIP_TeacherId",
                table: "FAMILY_RELATIONSHIP",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_FAMILY_RELATIONSHIP_STUDENT_StudentId",
                table: "FAMILY_RELATIONSHIP",
                column: "StudentId",
                principalTable: "STUDENT",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FAMILY_RELATIONSHIP_TEACHER_TeacherId",
                table: "FAMILY_RELATIONSHIP",
                column: "TeacherId",
                principalTable: "TEACHER",
                principalColumn: "ID");
        }
    }
}
