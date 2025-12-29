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
            //migrationBuilder.AddColumn<long>(
            //    name: "CITY_ID",
            //    table: "STUDENT",
            //    type: "NUMBER(19)",
            //    nullable: false,
            //    defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_CITY_ID",
                table: "STUDENT",
                column: "CITY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_STUDENT_CITY_CITY_ID",
                table: "STUDENT",
                column: "CITY_ID",
                principalTable: "CITY",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_STUDENT_CITY_CITY_ID",
                table: "STUDENT");

            migrationBuilder.DropIndex(
                name: "IX_STUDENT_CITY_ID",
                table: "STUDENT");

            migrationBuilder.DropColumn(
                name: "CITY_ID",
                table: "STUDENT");
        }
    }
}
