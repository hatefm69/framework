using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMI.Model.Migrations
{
    /// <inheritdoc />
    public partial class cmi008 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STUDENT_EDUCATIONAL_QUALIFICATION",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EDUCATIONAL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EDUCATIONAL_SCORE = table.Column<float>(type: "BINARY_FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT_EDUCATIONAL_QUALIFICATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STUDENT_EDUCATIONAL_QUALIFICATION_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_EDUCATIONAL_QUALIFICATION_StudentId",
                table: "STUDENT_EDUCATIONAL_QUALIFICATION",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STUDENT_EDUCATIONAL_QUALIFICATION");
        }
    }
}
