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

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTION_SUB_GROUP_INSPECTION_GROUP_ID",
                table: "INSPECTION_SUB_GROUP",
                column: "INSPECTION_GROUP_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ERROR");

            migrationBuilder.DropTable(
                name: "INSPECTION_SUB_GROUP");

            migrationBuilder.DropTable(
                name: "LEVEL_BY_HATEF");

            migrationBuilder.DropTable(
                name: "LOG");

            migrationBuilder.DropTable(
                name: "INSPECTION_GROUP");

            migrationBuilder.DropSequence(
                name: "INSPECTION_TERM_CODE_SEQ");
        }
    }
}
