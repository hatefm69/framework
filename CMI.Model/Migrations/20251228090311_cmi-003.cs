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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CITY");
        }
    }
}
