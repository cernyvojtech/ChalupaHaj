using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChalupaHaj.Data.Migrations
{
    public partial class PriceList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinterSeasonPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SummerSeasonPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutOfSeasonPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekendPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilvestrPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionBedFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoundaryFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WoodConsumptionFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalCleaningFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deposit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceList");
        }
    }
}
