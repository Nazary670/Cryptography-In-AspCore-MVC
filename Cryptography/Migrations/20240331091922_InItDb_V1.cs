using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cryptography.Migrations
{
    /// <inheritdoc />
    public partial class InItDb_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    State = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    City = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
