using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingChallenge.Infrastructure.Persistence.Migrations
{
    public partial class InitialDomainDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChallengeTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StdIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedStdOut = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExecutionInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Script = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stdin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Output = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsedMemory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpuTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ChallengeTaskId = table.Column<int>(type: "int", nullable: false),
                    ExecutionInfoId = table.Column<int>(type: "int", nullable: false),
                    IsPassed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solutions_ChallengeTasks_ChallengeTaskId",
                        column: x => x.ChallengeTaskId,
                        principalTable: "ChallengeTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solutions_ExecutionInfos_ExecutionInfoId",
                        column: x => x.ExecutionInfoId,
                        principalTable: "ExecutionInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solutions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_ChallengeTaskId",
                table: "Solutions",
                column: "ChallengeTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_ExecutionInfoId",
                table: "Solutions",
                column: "ExecutionInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solutions_PlayerId",
                table: "Solutions",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.DropTable(
                name: "ChallengeTasks");

            migrationBuilder.DropTable(
                name: "ExecutionInfos");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
