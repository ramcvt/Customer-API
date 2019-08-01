using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerIdentityAPI.Migrations
{
    public partial class address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "custaddress",
                columns: table => new
                {
                    Phonenumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Address1 = table.Column<string>(nullable: false),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    Pincode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custaddress", x => x.Phonenumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "custaddress");
        }
    }
}
