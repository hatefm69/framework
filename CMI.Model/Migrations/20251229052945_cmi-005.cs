using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMI.Model.Migrations
{
    /// <inheritdoc />
    public partial class cmi005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IS_ACTIVE",
                table: "STUDENT",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_ACTIVE",
                table: "STUDENT");
        }
    }
}
