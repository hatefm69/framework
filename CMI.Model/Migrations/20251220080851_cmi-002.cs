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
            migrationBuilder.AlterColumn<string>(
                name: "SIGNATURE_SANA_FILE_ID",
                table: "INSPECTOR_PROFILE",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)");

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
            migrationBuilder.AlterColumn<long>(
                name: "SIGNATURE_SANA_FILE_ID",
                table: "INSPECTOR_PROFILE",
                type: "NUMBER(19)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

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
