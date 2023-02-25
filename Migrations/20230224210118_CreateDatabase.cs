using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_ImobiliariaSantos.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "imoveis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipoImovel = table.Column<string>(maxLength: 64, nullable: true),
                    enderecoImovel = table.Column<string>(maxLength: 64, nullable: true),
                    finalidadeImovel = table.Column<string>(maxLength: 64, nullable: true),
                    descricaoImovel = table.Column<string>(maxLength: 64, nullable: true),
                    precoImovel = table.Column<decimal>(type: "DECIMAL(5,2)", nullable: false),
                    imagemImovel = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imoveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "locatarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomeLocatario = table.Column<string>(nullable: true),
                    cpfLocatario = table.Column<string>(nullable: true),
                    dataNascLocatario = table.Column<string>(nullable: true),
                    dataLocLocatario = table.Column<string>(nullable: true),
                    dataVencimentoAlugLocatario = table.Column<string>(nullable: true),
                    imagemLocatario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locatarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imoveis");

            migrationBuilder.DropTable(
                name: "locatarios");
        }
    }
}
