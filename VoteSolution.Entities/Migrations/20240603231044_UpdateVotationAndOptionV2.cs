using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoteSolution.Entities.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVotationAndOptionV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the old tables first if they exist
            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "Votation");

            // Recreate the Votation table
            migrationBuilder.CreateTable(
                name: "Votation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votation", x => x.Id);
                });

            // Recreate the Option table
            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalVotes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    VotationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Option_Votation_VotationId",
                        column: x => x.VotationId,
                        principalTable: "Votation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Create an index on VotationId in the Option table
            migrationBuilder.CreateIndex(
                name: "IX_Option_VotationId",
                table: "Option",
                column: "VotationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "Votation");
        }
    }
}
