using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListApi.Migrations
{
    /// <inheritdoc />
    public partial class RebuildDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItems_ShoppingLists_ShoppingListId",
                table: "ListItems");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingListId",
                table: "ListItems",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItems_ShoppingLists_ShoppingListId",
                table: "ListItems",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItems_ShoppingLists_ShoppingListId",
                table: "ListItems");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingListId",
                table: "ListItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ListItems_ShoppingLists_ShoppingListId",
                table: "ListItems",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
