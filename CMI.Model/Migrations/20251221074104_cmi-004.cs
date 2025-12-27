using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMI.Model.Migrations
{
    /// <inheritdoc />
    public partial class cmi004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INSPECTION_SUB_GROUP_INSPECTOR_GROUP_InspectorGroupId",
                table: "INSPECTION_SUB_GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_INSPECTION_SUB_GROUP_INSPECTOR_PROFILE_InspectorProfileId",
                table: "INSPECTION_SUB_GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_INSPECTOR_GROUP_RELATION_INSPECTION_GROUP_INSPECTION_GROUP_ID",
                table: "INSPECTOR_GROUP_RELATION");

            migrationBuilder.DropForeignKey(
                name: "FK_INSPECTOR_GROUP_RELATION_INSPECTION_SUB_GROUP_INSPECTION_SUB_GROUP_ID",
                table: "INSPECTOR_GROUP_RELATION");

            migrationBuilder.DropTable(
                name: "INSPECTOR_GROUP");

            migrationBuilder.DropIndex(
                name: "IX_INSPECTOR_GROUP_RELATION_INSPECTION_GROUP_ID",
                table: "INSPECTOR_GROUP_RELATION");

            migrationBuilder.DropIndex(
                name: "IX_INSPECTION_SUB_GROUP_InspectorGroupId",
                table: "INSPECTION_SUB_GROUP");

            migrationBuilder.DropColumn(
                name: "INSPECTION_GROUP_ID",
                table: "INSPECTOR_GROUP_RELATION");

            migrationBuilder.DropColumn(
                name: "InspectorGroupId",
                table: "INSPECTION_SUB_GROUP");

            migrationBuilder.AlterColumn<decimal>(
                name: "SCORE",
                table: "INSPECTOR_EVALUATION",
                type: "DECIMAL(18, 2)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<long>(
                name: "InspectorProfileId",
                table: "INSPECTION_SUB_GROUP",
                type: "NUMBER(19)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)");

            migrationBuilder.AddForeignKey(
                name: "FK_INSPECTION_SUB_GROUP_INSPECTOR_PROFILE_InspectorProfileId",
                table: "INSPECTION_SUB_GROUP",
                column: "InspectorProfileId",
                principalTable: "INSPECTOR_PROFILE",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_INSPECTOR_GROUP_RELATION_INSPECTION_SUB_GROUP_INSPECTION_SUB_GROUP_ID",
                table: "INSPECTOR_GROUP_RELATION",
                column: "INSPECTION_SUB_GROUP_ID",
                principalTable: "INSPECTION_SUB_GROUP",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INSPECTION_SUB_GROUP_INSPECTOR_PROFILE_InspectorProfileId",
                table: "INSPECTION_SUB_GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_INSPECTOR_GROUP_RELATION_INSPECTION_SUB_GROUP_INSPECTION_SUB_GROUP_ID",
                table: "INSPECTOR_GROUP_RELATION");

            migrationBuilder.AddColumn<long>(
                name: "INSPECTION_GROUP_ID",
                table: "INSPECTOR_GROUP_RELATION",
                type: "NUMBER(19)",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<decimal>(
                name: "SCORE",
                table: "INSPECTOR_EVALUATION",
                type: "DECIMAL(18,2)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<long>(
                name: "InspectorProfileId",
                table: "INSPECTION_SUB_GROUP",
                type: "NUMBER(19)",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InspectorGroupId",
                table: "INSPECTION_SUB_GROUP",
                type: "NUMBER(19)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "INSPECTOR_GROUP",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CREATED_AT = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: false),
                    CREATED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    INSPECTION_GROUP_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    INSPECTOR_PROFILE_ID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    LAST_EDITED_AT = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LAST_EDITED_VIA = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    LAST_EDITOR_BY = table.Column<string>(type: "NVARCHAR2(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSPECTOR_GROUP", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTOR_GROUP_RELATION_INSPECTION_GROUP_ID",
                table: "INSPECTOR_GROUP_RELATION",
                column: "INSPECTION_GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INSPECTION_SUB_GROUP_InspectorGroupId",
                table: "INSPECTION_SUB_GROUP",
                column: "InspectorGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_INSPECTION_SUB_GROUP_INSPECTOR_GROUP_InspectorGroupId",
                table: "INSPECTION_SUB_GROUP",
                column: "InspectorGroupId",
                principalTable: "INSPECTOR_GROUP",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_INSPECTION_SUB_GROUP_INSPECTOR_PROFILE_InspectorProfileId",
                table: "INSPECTION_SUB_GROUP",
                column: "InspectorProfileId",
                principalTable: "INSPECTOR_PROFILE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_INSPECTOR_GROUP_RELATION_INSPECTION_GROUP_INSPECTION_GROUP_ID",
                table: "INSPECTOR_GROUP_RELATION",
                column: "INSPECTION_GROUP_ID",
                principalTable: "INSPECTION_GROUP",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_INSPECTOR_GROUP_RELATION_INSPECTION_SUB_GROUP_INSPECTION_SUB_GROUP_ID",
                table: "INSPECTOR_GROUP_RELATION",
                column: "INSPECTION_SUB_GROUP_ID",
                principalTable: "INSPECTION_SUB_GROUP",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
