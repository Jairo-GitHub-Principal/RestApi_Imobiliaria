using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_ImobiliariaSantos.Migrations
{
    public partial class CreateDatabase10 : Migration
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
                    nomeLocatario = table.Column<string>(maxLength: 64, nullable: true),
                    cpfLocatario = table.Column<string>(maxLength: 64, nullable: true),
                    dataNascLocatario = table.Column<string>(maxLength: 64, nullable: true),
                    dataLocLocatario = table.Column<string>(maxLength: 64, nullable: true),
                    dataVencimentoAlugLocatario = table.Column<string>(maxLength: 64, nullable: true),
                    ImovelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locatarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_locatarios_imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "imoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_locatarios_ImovelId",
                table: "locatarios",
                column: "ImovelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "locatarios");

            migrationBuilder.DropTable(
                name: "imoveis");
        }
    }
}
