using Microsoft.EntityFrameworkCore.Migrations;

namespace eBook.Data.Migrations
{
    public partial class UpdateBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedOn",
                table: "Books",
                newName: "UpdatedOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedOn",
                table: "Books",
                newName: "DeletedOn");
        }
    }
}
