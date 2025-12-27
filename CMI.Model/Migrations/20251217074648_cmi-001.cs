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
                name: "BRANCH_INSPECTION_DAY_ALLOCATION",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    INSPECTION_DAY_NUMBER = table.Column<short>(type: "NUMBER(5)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DEACTIVATION_DATE = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    BRANCH_DEGREE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
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
                    table.PrimaryKey("PK_BRANCH_INSPECTION_DAY_ALLOCATION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CALENDAR_SETTING",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    YEAR = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    HOLIDAY_DATE = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CALENDAR_SETTING", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DISTANCE",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FROM_UNIT = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    TO_UNIT = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    TO_REGION = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    VALUE = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    IS_CONVERT = table.Column<bool>(type: "NUMBER(1)", nullable: true, defaultValue: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DEACTIVATION_DATE = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISTANCE", x => x.ID);
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
                name: "INSPECTION_PERIOD",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TITLE = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DEACTIVATION_DATE = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    YEAR = table.Column<short>(type: "NUMBER(5)", nullable: false),
                    FROM_DATE = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TO_DATE = table.Column<long>(type: "NUMBER(19)", nullable: false),
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
                    table.PrimaryKey("PK_INSPECTION_PERIOD", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INSPECTOR_GROUP",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    INSPECTOR_PROFILE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    INSPECTION_GROUP_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTOR_GROUP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INSPECTOR_PROFILE",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PERSONEL_CODE = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    PROFILE_TYPE_ID = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 1),
                    INSPECTOR_PERSONNEL_NAME = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false),
                    EMPLOYEMENT_DATE = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false, defaultValue: true),
                    STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FROM_DATE = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TO_DATE = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DAY_OFF = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    SIGNATURE_SANA_FILE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    SIGNATURE_FILE_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ADDRESS = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTOR_PROFILE", x => x.ID);
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
                name: "TEST_YEKE",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    BLACK = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    WHITE = table.Column<string>(type: "VARCHAR2(4000)", unicode: false, nullable: false),
                    TICK = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEST_YEKE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BRANCH_MANAGEMENT_TEAM_ALLOCATION",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    REFERRAL_GROUP_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    INSPECTOR_PROFILE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DEACTIVATION_DATE = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    REGION_CODE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANCH_MANAGEMENT_TEAM_ALLOCATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BRANCH_MANAGEMENT_TEAM_ALLOCATION_INSPECTOR_PROFILE_INSPECTOR_PROFILE_ID",
                        column: x => x.INSPECTOR_PROFILE_ID,
                        principalTable: "INSPECTOR_PROFILE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                    InspectorProfileId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    InspectorGroupId = table.Column<long>(type: "NUMBER(19)", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_INSPECTION_SUB_GROUP_INSPECTOR_GROUP_InspectorGroupId",
                        column: x => x.InspectorGroupId,
                        principalTable: "INSPECTOR_GROUP",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_INSPECTION_SUB_GROUP_INSPECTOR_PROFILE_InspectorProfileId",
                        column: x => x.InspectorProfileId,
                        principalTable: "INSPECTOR_PROFILE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSPECTOR_EVALUATION",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EVALUATION_TERM = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    YEAR = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SCORE = table.Column<decimal>(type: "DECIMAL(18, 2)", maxLength: 10, nullable: false),
                    INSPECTOR_PROFILE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTOR_EVALUATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INSPECTOR_EVALUATION_INSPECTOR_PROFILE_INSPECTOR_PROFILE_ID",
                        column: x => x.INSPECTOR_PROFILE_ID,
                        principalTable: "INSPECTOR_PROFILE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSPECTOR_PROFILE_REFERRAL_GROUP",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    INSPECTOR_PROFILE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    REFERRAL_GROUP_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
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
                    table.PrimaryKey("PK_INSPECTOR_PROFILE_REFERRAL_GROUP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INSPECTOR_PROFILE_REFERRAL_GROUP_INSPECTOR_PROFILE_INSPECTOR_PROFILE_ID",
                        column: x => x.INSPECTOR_PROFILE_ID,
                        principalTable: "INSPECTOR_PROFILE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSPECTOR_ROLE_RELATION",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ROLE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    InspectorProfileId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTOR_ROLE_RELATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INSPECTOR_ROLE_RELATION_INSPECTOR_PROFILE_InspectorProfileId",
                        column: x => x.InspectorProfileId,
                        principalTable: "INSPECTOR_PROFILE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INSPECTOR_GROUP_RELATION",
                columns: table => new
                {
                    INSPECTOR_PROFILE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    INSPECTION_SUB_GROUP_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    INSPECTION_GROUP_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true),
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTOR_GROUP_RELATION", x => new { x.INSPECTOR_PROFILE_ID, x.INSPECTION_SUB_GROUP_ID });
                    table.ForeignKey(
                        name: "FK_INSPECTOR_GROUP_RELATION_INSPECTION_GROUP_INSPECTION_GROUP_ID",
                        column: x => x.INSPECTION_GROUP_ID,
                        principalTable: "INSPECTION_GROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INSPECTOR_GROUP_RELATION_INSPECTION_SUB_GROUP_INSPECTION_SUB_GROUP_ID",
                        column: x => x.INSPECTION_SUB_GROUP_ID,
                        principalTable: "INSPECTION_SUB_GROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INSPECTOR_GROUP_RELATION_INSPECTOR_PROFILE_INSPECTOR_PROFILE_ID",
                        column: x => x.INSPECTOR_PROFILE_ID,
                        principalTable: "INSPECTOR_PROFILE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BRANCH_MANAGEMENT_TEAM_ALLOCATION_INSPECTOR_PROFILE_ID",
                table: "BRANCH_MANAGEMENT_TEAM_ALLOCATION",
                column: "INSPECTOR_PROFILE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTION_SUB_GROUP_INSPECTION_GROUP_ID",
                table: "INSPECTION_SUB_GROUP",
                column: "INSPECTION_GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTION_SUB_GROUP_InspectorGroupId",
                table: "INSPECTION_SUB_GROUP",
                column: "InspectorGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTION_SUB_GROUP_InspectorProfileId",
                table: "INSPECTION_SUB_GROUP",
                column: "InspectorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTOR_EVALUATION_INSPECTOR_PROFILE_ID",
                table: "INSPECTOR_EVALUATION",
                column: "INSPECTOR_PROFILE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTOR_GROUP_RELATION_INSPECTION_GROUP_ID",
                table: "INSPECTOR_GROUP_RELATION",
                column: "INSPECTION_GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTOR_GROUP_RELATION_INSPECTION_SUB_GROUP_ID",
                table: "INSPECTOR_GROUP_RELATION",
                column: "INSPECTION_SUB_GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTOR_PROFILE_REFERRAL_GROUP_INSPECTOR_PROFILE_ID",
                table: "INSPECTOR_PROFILE_REFERRAL_GROUP",
                column: "INSPECTOR_PROFILE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTOR_ROLE_RELATION_InspectorProfileId",
                table: "INSPECTOR_ROLE_RELATION",
                column: "InspectorProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BRANCH_INSPECTION_DAY_ALLOCATION");

            migrationBuilder.DropTable(
                name: "BRANCH_MANAGEMENT_TEAM_ALLOCATION");

            migrationBuilder.DropTable(
                name: "CALENDAR_SETTING");

            migrationBuilder.DropTable(
                name: "DISTANCE");

            migrationBuilder.DropTable(
                name: "ERROR");

            migrationBuilder.DropTable(
                name: "INSPECTION_PERIOD");

            migrationBuilder.DropTable(
                name: "INSPECTOR_EVALUATION");

            migrationBuilder.DropTable(
                name: "INSPECTOR_GROUP_RELATION");

            migrationBuilder.DropTable(
                name: "INSPECTOR_PROFILE_REFERRAL_GROUP");

            migrationBuilder.DropTable(
                name: "INSPECTOR_ROLE_RELATION");

            migrationBuilder.DropTable(
                name: "LOG");

            migrationBuilder.DropTable(
                name: "TEST_YEKE");

            migrationBuilder.DropTable(
                name: "INSPECTION_SUB_GROUP");

            migrationBuilder.DropTable(
                name: "INSPECTION_GROUP");

            migrationBuilder.DropTable(
                name: "INSPECTOR_GROUP");

            migrationBuilder.DropTable(
                name: "INSPECTOR_PROFILE");

            migrationBuilder.DropSequence(
                name: "INSPECTION_TERM_CODE_SEQ");
        }
    }
}
