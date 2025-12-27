using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMI.Model.Migrations
{
    /// <inheritdoc />
    public partial class cmi003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SIGNATURE_SANA_FILE_ID",
                table: "INSPECTOR_PROFILE",
                type: "NVARCHAR2(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SCORE",
                table: "INSPECTOR_EVALUATION",
                type: "DECIMAL(18, 2)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SIGNATURE_SANA_FILE_ID",
                table: "INSPECTOR_PROFILE",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(36)",
                oldMaxLength: 36);

            migrationBuilder.AlterColumn<decimal>(
                name: "SCORE",
                table: "INSPECTOR_EVALUATION",
                type: "DECIMAL(18,2)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldMaxLength: 10);
        }
    }
}
