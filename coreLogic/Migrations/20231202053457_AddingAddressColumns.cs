using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace coreLogic.Migrations
{
    /// <inheritdoc />
    public partial class AddingAddressColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AddColumn<int>(
				name: "StreetAddress",
				table: "Accounts",
				type: "TEXT",
				nullable: true);

			migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Accounts",
                type: "TEXT",
                nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "StateProvince",
				table: "Accounts",
				type: "TEXT",
				nullable: true);

			migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Accounts",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "StateProvince",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Accounts");
        }
    }
}
