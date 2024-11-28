using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuadrosNBR.Dominio.Entities;

namespace QuadrosNBR.Infraestrutura.DataBase.Configuracoes;

public class InformacoesPreliminaresConfiguracoes : IEntityTypeConfiguration<InformacoesPreliminaresDominio>
{
    public void Configure(EntityTypeBuilder<InformacoesPreliminaresDominio> builder)
    {
        builder.ToTable("InformacoesPreliminares");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(x => x.ProjetoId)
            .IsRequired()
            .HasColumnName("ProjetoId")
            .HasColumnType("uniqueidentifier");

        builder.Property(x => x.TenantId)
            .IsRequired()
            .HasColumnName("TenantId")
            .HasColumnType("uniqueidentifier");

        builder.Property(x => x.NomeDoIncorporador)
            .IsRequired()
            .HasColumnName("NomeDoIncorporador")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.CNPJdoIncorporador)
            .IsRequired()
            .HasColumnName("CNPJdoIncorporador")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.EnderecoDoIncorporador)
            .IsRequired()
            .HasColumnName("EnderecoDoIncorporador")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.NomeDoResponsavelTecnico)
            .IsRequired()
            .HasColumnName("NomeDoResponsavelTecnico")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.CREAdoResponsavelTecnico)
            .IsRequired()
            .HasColumnName("CREAdoResponsavelTecnico")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        builder.Property(x => x.ARTdoResponsavelTecnico)
            .IsRequired()
            .HasColumnName("ARTdoResponsavelTecnico")
            .HasColumnType("VARCHAR")
            .HasMaxLength(30);

        builder.Property(x => x.EnderecoDoResponsavelTecnico)
            .IsRequired()
            .HasColumnName("EnderecoDoResponsavelTecnico")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.NomeDoImovel)
            .IsRequired()
            .HasColumnName("NomeDoImovel")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.EnderecoDoImovel)
            .IsRequired()
            .HasColumnName("EnderecoDoImovel")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.CidadeDoImovel)
            .IsRequired()
            .HasColumnName("CidadeDoImovel")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(30);

        builder.Property(x => x.UFdoImovel)
            .IsRequired()
            .HasColumnName("UFdoImovel")
            .HasColumnType("VARCHAR")
            .HasMaxLength(2);

        builder.Property(x => x.DesignacaoDoImovel)
            .IsRequired()
            .HasColumnName("DesignacaoDoImovel")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(4);

        builder.Property(x => x.UnidadesAutonomasDoImovel)
            .IsRequired()
            .HasColumnName("UnidadesAutonomasDoImovel")
            .HasColumnType("SMALLINT");

        builder.Property(x => x.PadraoDeAcabamentoDoImovel)
            .HasColumnName("PadraoDeAcabamentoDoImovel")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(10);
          
        builder.Property(x => x.NumeroDePavimentosDoImovel)
            .IsRequired()
            .HasColumnName("NumeroDePavimentosDoImovel")
            .HasColumnType("SMALLINT");

        builder.Property(x => x.NumeroDeVagasDeAutomovelAutonomas)
            .HasColumnName("NumeroDeVagasDeAutomovelAutonomas")
            .HasColumnType("SMALLINT");

        builder.Property(x => x.NumeroDeVagasDeAutomovelAcessorias)
            .HasColumnName("NumeroDeVagasDeAutomovelAcessorias")
            .HasColumnType("SMALLINT");

        builder.Property(x => x.NumeroDeVagasDeAutomovelComum)
            .HasColumnName("NumeroDeVagasDeAutomovelComum")
            .HasColumnType("SMALLINT");

        builder.Property(x => x.AreaDoLote)
            .IsRequired()
            .HasColumnName("AreaDoLote")
            .HasColumnType("numeric(8, 2)");

        builder.Property(x => x.DataDeAprovacaoDoProjeto)
            .IsRequired()
            .HasColumnName("DataDeAprovacaoDoProjeto")
            .HasColumnType("date");

        builder.Property(x => x.NumeroDoAlvara)
            .HasColumnName("NumeroDoAlvara")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20);

        // Indices
        builder.HasIndex(x => x.ProjetoId, "IX_InformacoesPreliminares_ProjetoId");
        builder.HasIndex(x => x.TenantId, "IX_InformacoesPreliminares_TenantId");
    }
}
