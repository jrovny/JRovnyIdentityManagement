using Microsoft.EntityFrameworkCore.Migrations;

namespace JRovnySites.IdentityManagement.Data.Migrations.Identity
{
    public partial class AddFirstLastNameMigrationApplicationDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "identity_user",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "identity_user",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "first_name",
                table: "identity_user");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "identity_user");
        }
    }
}
