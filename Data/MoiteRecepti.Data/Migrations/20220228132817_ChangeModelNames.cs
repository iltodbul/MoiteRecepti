namespace MoiteRecepti.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeModelNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PortionCount",
                table: "Recipes",
                newName: "PortionsCount");

            migrationBuilder.RenameColumn(
                name: "Instruction",
                table: "Recipes",
                newName: "Instructions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PortionsCount",
                table: "Recipes",
                newName: "PortionCount");

            migrationBuilder.RenameColumn(
                name: "Instructions",
                table: "Recipes",
                newName: "Instruction");
        }
    }
}
