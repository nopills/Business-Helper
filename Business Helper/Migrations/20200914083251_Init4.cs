using Microsoft.EntityFrameworkCore.Migrations;

namespace Business_Helper.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    KPP = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Sender = table.Column<string>(nullable: true),
                    CheckingAcc = table.Column<string>(nullable: true),
                    BIK = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    CorpAcc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    KPP = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Sender = table.Column<string>(nullable: true),
                    CheckingAcc = table.Column<string>(nullable: true),
                    BIK = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    CorpAcc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
