using Microsoft.EntityFrameworkCore.Migrations;

namespace ZombieParty_DataAccess.Migrations
{
    public partial class addHunter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zombie_ForceLevel_ForceLevelId",
                table: "Zombie");

            migrationBuilder.DropTable(
                name: "ForceLevel");

            migrationBuilder.DropTable(
                name: "WeaponHunter");

            migrationBuilder.DropTable(
                name: "ZombieHuntingLog");

            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Zombie_ForceLevelId",
                table: "Zombie");

            migrationBuilder.DropColumn(
                name: "ForceLevelId",
                table: "Zombie");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Zombie",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Zombie");

            migrationBuilder.AddColumn<int>(
                name: "ForceLevelId",
                table: "Zombie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForceLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForceLevelNiv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForceLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZombieHuntingLog",
                columns: table => new
                {
                    Zombie_Id = table.Column<int>(type: "int", nullable: false),
                    HuntingLog_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZombieHuntingLog", x => new { x.Zombie_Id, x.HuntingLog_Id });
                    table.ForeignKey(
                        name: "FK_ZombieHuntingLog_HuntingLog_HuntingLog_Id",
                        column: x => x.HuntingLog_Id,
                        principalTable: "HuntingLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZombieHuntingLog_Zombie_Zombie_Id",
                        column: x => x.Zombie_Id,
                        principalTable: "Zombie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapon_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeaponHunter",
                columns: table => new
                {
                    Weapon_Id = table.Column<int>(type: "int", nullable: false),
                    Hunter_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponHunter", x => new { x.Weapon_Id, x.Hunter_Id });
                    table.ForeignKey(
                        name: "FK_WeaponHunter_Hunter_Hunter_Id",
                        column: x => x.Hunter_Id,
                        principalTable: "Hunter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeaponHunter_Weapon_Weapon_Id",
                        column: x => x.Weapon_Id,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zombie_ForceLevelId",
                table: "Zombie",
                column: "ForceLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_CategoryId",
                table: "Weapon",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponHunter_Hunter_Id",
                table: "WeaponHunter",
                column: "Hunter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ZombieHuntingLog_HuntingLog_Id",
                table: "ZombieHuntingLog",
                column: "HuntingLog_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zombie_ForceLevel_ForceLevelId",
                table: "Zombie",
                column: "ForceLevelId",
                principalTable: "ForceLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
