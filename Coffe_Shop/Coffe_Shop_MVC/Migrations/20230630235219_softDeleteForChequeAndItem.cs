using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffe_Shop_MVC.Migrations
{
    /// <inheritdoc />
    public partial class softDeleteForChequeAndItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cheques",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cheques");
        }
    }
}
