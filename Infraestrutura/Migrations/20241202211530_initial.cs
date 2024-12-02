using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuadrosNBR.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InformacoesPreliminares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeDoIncorporador = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CNPJdoIncorporador = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    EnderecoDoIncorporador = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    NomeDoResponsavelTecnico = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CREAdoResponsavelTecnico = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    ARTdoResponsavelTecnico = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    EnderecoDoResponsavelTecnico = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    NomeDoImovel = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    EnderecoDoImovel = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    CidadeDoImovel = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    UFdoImovel = table.Column<string>(type: "VARCHAR(2)", maxLength: 2, nullable: false),
                    DesignacaoDoImovel = table.Column<string>(type: "NVARCHAR(4)", maxLength: 4, nullable: false),
                    UnidadesAutonomasDoImovel = table.Column<byte>(type: "tinyint", nullable: false),
                    PadraoDeAcabamentoDoImovel = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false),
                    NumeroDePavimentosDoImovel = table.Column<byte>(type: "tinyint", nullable: false),
                    NumeroDeVagasDeAutomovelAutonomas = table.Column<byte>(type: "tinyint", nullable: false),
                    NumeroDeVagasDeAutomovelAcessorias = table.Column<byte>(type: "tinyint", nullable: false),
                    NumeroDeVagasDeAutomovelComum = table.Column<byte>(type: "tinyint", nullable: false),
                    AreaDoLote = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    DataDeAprovacaoDoProjeto = table.Column<DateTime>(type: "date", nullable: false),
                    NumeroDoAlvara = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacoesPreliminares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dependencia = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    NomeDaLayer = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Area = table.Column<double>(type: "FLOAT", nullable: false),
                    Ordenacao = table.Column<byte>(type: "tinyint", nullable: true),
                    Repeticao = table.Column<byte>(type: "tinyint", nullable: true),
                    Pavimento = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    Uso = table.Column<string>(type: "VARCHAR(9)", maxLength: 9, nullable: true),
                    Coeficiente = table.Column<double>(type: "FLOAT", nullable: true),
                    DecideDivisaoProporcional = table.Column<bool>(type: "BIT", nullable: true, defaultValue: false),
                    DecideAreaPadrao = table.Column<bool>(type: "BIT", nullable: true, defaultValue: false),
                    DecideAreaAcessoria = table.Column<bool>(type: "BIT", nullable: true, defaultValue: false),
                    DecideAreaSubrogada = table.Column<bool>(type: "BIT", nullable: true, defaultValue: false),
                    DecideAreaDoTerreno = table.Column<bool>(type: "BIT", nullable: true, defaultValue: false),
                    Observacao = table.Column<string>(type: "TEXT", nullable: true),
                    AreaRealCobertaPadraoTotal = table.Column<double>(type: "FLOAT", nullable: false, defaultValue: 0.0),
                    AreaRealDiferenteDaCobertaPadraoTotal = table.Column<double>(type: "FLOAT", nullable: false, defaultValue: 0.0),
                    AreaEquivalenteDiferenteDaCobertaPadraoTotal = table.Column<double>(type: "FLOAT", nullable: false, defaultValue: 0.0),
                    AreaEquivalenteDiferenteDaCobertaPadraoUnitaria = table.Column<double>(type: "FLOAT", nullable: false, defaultValue: 0.0),
                    AreaDoTerreno = table.Column<double>(type: "FLOAT", nullable: false, defaultValue: 0.0),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pavimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Repeticao = table.Column<byte>(type: "tinyint", nullable: false),
                    Ordenacao = table.Column<byte>(type: "tinyint", nullable: false),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pavimento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformacoesPreliminares_ProjetoId",
                table: "InformacoesPreliminares",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacoesPreliminares_TenantId",
                table: "InformacoesPreliminares",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Memoria_DecideAreaAcessoria",
                table: "Memoria",
                column: "DecideAreaAcessoria");

            migrationBuilder.CreateIndex(
                name: "IX_Memoria_DecideAreaDoTerreno",
                table: "Memoria",
                column: "DecideAreaDoTerreno");

            migrationBuilder.CreateIndex(
                name: "IX_Memoria_DecideAreaSubrogada",
                table: "Memoria",
                column: "DecideAreaSubrogada");

            migrationBuilder.CreateIndex(
                name: "IX_Memoria_DecideDivisaoProporcional",
                table: "Memoria",
                column: "DecideDivisaoProporcional");

            migrationBuilder.CreateIndex(
                name: "IX_Memoria_Ordenacao",
                table: "Memoria",
                column: "Ordenacao");

            migrationBuilder.CreateIndex(
                name: "IX_Memoria_ProjetoId",
                table: "Memoria",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Memoria_TenantId",
                table: "Memoria",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Memoria_Uso",
                table: "Memoria",
                column: "Uso");

            migrationBuilder.CreateIndex(
                name: "IX_Pavimento_Ordenacao",
                table: "Pavimento",
                column: "Ordenacao");

            migrationBuilder.CreateIndex(
                name: "IX_Pavimento_ProjetoId",
                table: "Pavimento",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pavimento_TenantId",
                table: "Pavimento",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformacoesPreliminares");

            migrationBuilder.DropTable(
                name: "Memoria");

            migrationBuilder.DropTable(
                name: "Pavimento");
        }
    }
}
