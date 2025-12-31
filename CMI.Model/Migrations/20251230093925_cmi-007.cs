using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMI.Model.Migrations
{
    /// <inheritdoc />
    public partial class cmi007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FAMILY_RELATIONSHIP",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    STUDENT_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FAMILY_RELATIONSHIP_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FULL_NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAMILY_RELATIONSHIP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FAMILY_RELATIONSHIP_STUDENT_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalTable: "STUDENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FAMILY_RELATIONSHIP_STUDENT_ID",
                table: "FAMILY_RELATIONSHIP",
                column: "STUDENT_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FAMILY_RELATIONSHIP");
        }
    }
}
