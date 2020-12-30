using Microsoft.EntityFrameworkCore.Migrations;

namespace FooModule.Migrations
{
    public partial class AddAppleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Foo");

            migrationBuilder.CreateTable(
                name: "Apples",
                schema: "Foo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apples", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apples",
                schema: "Foo");
        }
    }
}
