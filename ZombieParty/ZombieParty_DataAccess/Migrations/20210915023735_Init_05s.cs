using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZombieParty_DataAccess.Migrations
{
    public partial class Init_05s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Hunter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hunter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZombieType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZombieType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
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
                name: "HuntingLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdventureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HunterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuntingLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HuntingLog_Hunter_HunterId",
                        column: x => x.HunterId,
                        principalTable: "Hunter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zombie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZombieTypeId = table.Column<int>(type: "int", nullable: false),
                    ForceLevelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zombie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zombie_ForceLevel_ForceLevelId",
                        column: x => x.ForceLevelId,
                        principalTable: "ForceLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zombie_ZombieType_ZombieTypeId",
                        column: x => x.ZombieTypeId,
                        principalTable: "ZombieType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeaponHunter",
                columns: table => new
                {
                    Hunter_Id = table.Column<int>(type: "int", nullable: false),
                    Weapon_Id = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_HuntingLog_HunterId",
                table: "HuntingLog",
                column: "HunterId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_CategoryId",
                table: "Weapon",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponHunter_Hunter_Id",
                table: "WeaponHunter",
                column: "Hunter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zombie_ForceLevelId",
                table: "Zombie",
                column: "ForceLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Zombie_ZombieTypeId",
                table: "Zombie",
                column: "ZombieTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ZombieHuntingLog_HuntingLog_Id",
                table: "ZombieHuntingLog",
                column: "HuntingLog_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeaponHunter");

            migrationBuilder.DropTable(
                name: "ZombieHuntingLog");

            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropTable(
                name: "HuntingLog");

            migrationBuilder.DropTable(
                name: "Zombie");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Hunter");

            migrationBuilder.DropTable(
                name: "ForceLevel");

            migrationBuilder.DropTable(
                name: "ZombieType");
        }
    }
}
