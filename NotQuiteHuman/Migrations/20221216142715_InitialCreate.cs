using Microsoft.EntityFrameworkCore.Migrations;

namespace NotQuiteHuman.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbilityScoreBonus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Strength = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    Constitution = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Wisdom = table.Column<int>(nullable: false),
                    Charisma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityScoreBonus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trait",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trait", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    AbilityScoreBonusId = table.Column<int>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    WalkSpeed = table.Column<int>(nullable: false),
                    SwimSpeed = table.Column<int>(nullable: false),
                    FlySpeed = table.Column<int>(nullable: false),
                    ClimbSpeed = table.Column<int>(nullable: false),
                    CreatureType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Race_AbilityScoreBonus_AbilityScoreBonusId",
                        column: x => x.AbilityScoreBonusId,
                        principalTable: "AbilityScoreBonus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceLanguage_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceTrait",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceId = table.Column<int>(nullable: false),
                    TraitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceTrait", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceTrait_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceTrait_Trait_TraitId",
                        column: x => x.TraitId,
                        principalTable: "Trait",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Race_AbilityScoreBonusId",
                table: "Race",
                column: "AbilityScoreBonusId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceLanguage_LanguageId",
                table: "RaceLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceLanguage_RaceId",
                table: "RaceLanguage",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceTrait_RaceId",
                table: "RaceTrait",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceTrait_TraitId",
                table: "RaceTrait",
                column: "TraitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceLanguage");

            migrationBuilder.DropTable(
                name: "RaceTrait");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "Trait");

            migrationBuilder.DropTable(
                name: "AbilityScoreBonus");
        }
    }
}
