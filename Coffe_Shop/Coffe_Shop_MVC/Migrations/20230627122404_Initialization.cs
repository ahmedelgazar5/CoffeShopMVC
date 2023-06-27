using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffe_Shop_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cheques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cheque_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cheque_Value = table.Column<int>(type: "int", nullable: false),
                    Cheque_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Table_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cheques_Tables_Table_Id",
                        column: x => x.Table_Id,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ordered_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Table_Id = table.Column<int>(type: "int", nullable: false),
                    Cheque_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cheques_Cheque_Id",
                        column: x => x.Cheque_Id,
                        principalTable: "Cheques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Tables_Table_Id",
                        column: x => x.Table_Id,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_Items",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Items", x => new { x.Order_Id, x.Item_Id });
                    table.ForeignKey(
                        name: "FK_Order_Items_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Items_Orders_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_Table_Id",
                table: "Cheques",
                column: "Table_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_Item_Id",
                table: "Order_Items",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Cheque_Id",
                table: "Orders",
                column: "Cheque_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Table_Id",
                table: "Orders",
                column: "Table_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Items");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cheques");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
