using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrowseCourses.Migrations
{
    public partial class PlanDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    CourseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "PlanDetails",
                columns: table => new
                {
                    PlanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registered = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDetails", x => x.PlanID);
                });

            migrationBuilder.CreateTable(
                name: "PlanLine",
                columns: table => new
                {
                    PlanLineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PlanDetailPlanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanLine", x => x.PlanLineID);
                    table.ForeignKey(
                        name: "FK_PlanLine_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanLine_PlanDetails_PlanDetailPlanID",
                        column: x => x.PlanDetailPlanID,
                        principalTable: "PlanDetails",
                        principalColumn: "PlanID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanLine_CourseID",
                table: "PlanLine",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanLine_PlanDetailPlanID",
                table: "PlanLine",
                column: "PlanDetailPlanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanLine");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "PlanDetails");
        }
    }
}
