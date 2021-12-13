using Microsoft.EntityFrameworkCore.Migrations;

namespace ElBodegon.Data.Migrations
{
    public partial class Menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuViewModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen = table.Column<string>(type:"nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuViewModel", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuViewModel");
        }
    }
}
