using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMI.Model.Migrations
{
    /// <inheritdoc />
    public partial class cmi001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "INSPECTION_TERM_CODE_SEQ");

            migrationBuilder.CreateTable(
                name: "ATTACHMENT",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FILENAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TABLE_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SANA_ID = table.Column<string>(type: "NVARCHAR2(36)", maxLength: 36, nullable: false),
                    RECORD_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTACHMENT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CITY",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TITLE = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ERROR",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EXCEPTION_DATA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EXTRA_DATA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERROR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INSPECTION_GROUP",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TITLE = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DEACTIVATION_DATE = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTION_GROUP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LEVEL_BY_HATEF",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TITLE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEVEL_BY_HATEF", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOG",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TABLE_NAME = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    ACTION = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    RECORD_DATA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INSPECTION_SUB_GROUP",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TITLE = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false),
                    INSPECTION_GROUP_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DEACTIVATION_DATE = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: true),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTION_SUB_GROUP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INSPECTION_SUB_GROUP_INSPECTION_GROUP_INSPECTION_GROUP_ID",
                        column: x => x.INSPECTION_GROUP_ID,
                        principalTable: "INSPECTION_GROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FIRST_NAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    LEVEL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CITY_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    BIRTH_DATE = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STUDENT_CITY_CITY_ID",
                        column: x => x.CITY_ID,
                        principalTable: "CITY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STUDENT_LEVEL_BY_HATEF_LEVEL_ID",
                        column: x => x.LEVEL_ID,
                        principalTable: "LEVEL_BY_HATEF",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TEACHER",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    FIRST_NAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    LEVEL_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CITY_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    BIRTH_DATE = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEACHER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TEACHER_CITY_CITY_ID",
                        column: x => x.CITY_ID,
                        principalTable: "CITY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TEACHER_LEVEL_BY_HATEF_LEVEL_ID",
                        column: x => x.LEVEL_ID,
                        principalTable: "LEVEL_BY_HATEF",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "FAMILY_RELATIONSHIP",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RecordId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TableId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FAMILY_RELATIONSHIP_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FULL_NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true),
                    StudentId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TeacherId = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAMILY_RELATIONSHIP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FAMILY_RELATIONSHIP_STUDENT_StudentId",
                        column: x => x.StudentId,
                        principalTable: "STUDENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FAMILY_RELATIONSHIP_TEACHER_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "TEACHER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FAMILY_RELATIONSHIP_StudentId",
                table: "FAMILY_RELATIONSHIP",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FAMILY_RELATIONSHIP_TeacherId",
                table: "FAMILY_RELATIONSHIP",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTION_SUB_GROUP_INSPECTION_GROUP_ID",
                table: "INSPECTION_SUB_GROUP",
                column: "INSPECTION_GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_CITY_ID",
                table: "STUDENT",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_LEVEL_ID",
                table: "STUDENT",
                column: "LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_EDUCATIONAL_QUALIFICATION_StudentId",
                table: "STUDENT_EDUCATIONAL_QUALIFICATION",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TEACHER_CITY_ID",
                table: "TEACHER",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TEACHER_LEVEL_ID",
                table: "TEACHER",
                column: "LEVEL_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATTACHMENT");

            migrationBuilder.DropTable(
                name: "ERROR");

            migrationBuilder.DropTable(
                name: "FAMILY_RELATIONSHIP");

            migrationBuilder.DropTable(
                name: "INSPECTION_SUB_GROUP");

            migrationBuilder.DropTable(
                name: "LOG");

            migrationBuilder.DropTable(
                name: "STUDENT_EDUCATIONAL_QUALIFICATION");

            migrationBuilder.DropTable(
                name: "TEACHER");

            migrationBuilder.DropTable(
                name: "INSPECTION_GROUP");

            migrationBuilder.DropTable(
                name: "STUDENT");

            migrationBuilder.DropTable(
                name: "CITY");

            migrationBuilder.DropTable(
                name: "LEVEL_BY_HATEF");

            migrationBuilder.DropSequence(
                name: "INSPECTION_TERM_CODE_SEQ");
        }
    }
}
