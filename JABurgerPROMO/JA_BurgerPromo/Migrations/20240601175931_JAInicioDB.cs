using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JA_BurgerPromo.Migrations
{
    /// <inheritdoc />
    public partial class JAInicioDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JA_Burger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WithCheese = table.Column<bool>(type: "bit", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JA_Burger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JA_Promo",
                columns: table => new
                {
                    PromoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPromo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BurgerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JA_Promo", x => x.PromoID);
                    table.ForeignKey(
                        name: "FK_JA_Promo_JA_Burger_BurgerID",
                        column: x => x.BurgerID,
                        principalTable: "JA_Burger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JA_Promo_BurgerID",
                table: "JA_Promo",
                column: "BurgerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JA_Promo");

            migrationBuilder.DropTable(
                name: "JA_Burger");
        }
    }
}
