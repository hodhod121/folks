using Microsoft.EntityFrameworkCore.Migrations;

namespace folk.Migrations
{
    public partial class mi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 75, nullable: false),
                    CountryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(maxLength: 75, nullable: false),
                    PersonPhone = table.Column<string>(maxLength: 75, nullable: false),
                    CountryCode = table.Column<string>(maxLength: 3, nullable: false),
                    CityCode = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Peoples_Cities_CityCode",
                        column: x => x.CityCode,
                        principalTable: "Cities",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Peoples_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryCode",
                table: "Cities",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_CityCode",
                table: "Peoples",
                column: "CityCode");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_CountryCode",
                table: "Peoples",
                column: "CountryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
