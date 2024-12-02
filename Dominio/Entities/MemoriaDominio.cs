using FluentValidation.Results;
using QuadrosNBR.Dominio.Entities.Base;
using QuadrosNBR.Dominio.Validations;

namespace QuadrosNBR.Dominio.Entities
{
    public class MemoriaDominio : BaseDominio
    {
        private readonly MemoriaValidator _memoriaValidator = new();

        public MemoriaDominio(
            string? dependencia,
            string nomeDaLayer,
            decimal area,
            ushort? ordenacao,
            ushort? repeticao,
            string? pavimento,
            string? uso,
            decimal? coeficiente,
            bool? decideDivisaoProporcional,
            bool? decideAreaPadrao,
            bool? decideAreaAcessoria,
            bool? decideAreaSubrogada,
            bool? decideAreaDoTerreno,
            string? observacao,
            Guid projetoId,
            Guid tenantId) : base(projetoId, tenantId)
        {
            Dependencia = dependencia;
            NomeDaLayer = nomeDaLayer;
            Area = Math.Round(area, 4);
            Ordenacao = ordenacao;
            Repeticao = repeticao;
            Pavimento = pavimento;
            Uso = uso;
            Coeficiente = coeficiente;
            DecideDivisaoProporcional = decideDivisaoProporcional;
            DecideAreaPadrao = decideAreaPadrao;
            DecideAreaAcessoria = decideAreaAcessoria;
            DecideAreaSubrogada = decideAreaSubrogada;
            DecideAreaDoTerreno = decideAreaDoTerreno;
            Observacao = observacao;
            AreaRealCobertaPadraoTotal = CalculaAreaRealCobertaPadraoTotal();
            AreaRealDiferenteDaCobertaPadraoTotal = CalculaAreaRealDiferenteDaCobertaPadraoTotal();
            AreaEquivalenteDiferenteDaCobertaPadraoTotal = CalculaAreaEquivalenteDiferenteDaCobertaPadraoTotal();
            AreaEquivalenteDiferenteDaCobertaPadraoUnitaria = CalculaAreaEquivalenteDiferenteDaCobertaPadraoUnitaria();
            AreaDoTerreno = CalculaAreaDoTerreno();
        }

        public string? Dependencia { get; private set; } = null;
        public string NomeDaLayer { get; private set; }
        public decimal Area { get; private set; }
        public ushort? Ordenacao { get; private set; } = null;
        public ushort? Repeticao { get; private set; } = null;
        public string? Pavimento { get; private set; } = null;
        public string? Uso { get; private set; } = null;
        public decimal? Coeficiente { get; private set; } = null;
        public bool? DecideDivisaoProporcional { get; private set; } = null;
        public bool? DecideAreaPadrao { get; private set; } = null;
        public bool? DecideAreaAcessoria { get; private set; } = null;
        public bool? DecideAreaSubrogada { get; private set; } = null;
        public bool? DecideAreaDoTerreno { get; private set; } = null;
        public string? Observacao { get; private set; } = null;
        public decimal AreaRealCobertaPadraoTotal { get; private set; }
        public decimal AreaRealDiferenteDaCobertaPadraoTotal { get; private set; }
        public decimal AreaEquivalenteDiferenteDaCobertaPadraoTotal { get; private set; }
        public decimal AreaEquivalenteDiferenteDaCobertaPadraoUnitaria { get; private set; }
        public decimal AreaDoTerreno { get; private set; }

        private decimal CalculaAreaRealCobertaPadraoTotal()
        {
            if (DecideAreaPadrao is true)
            {
                AreaRealDiferenteDaCobertaPadraoTotal = 0;
                AreaEquivalenteDiferenteDaCobertaPadraoTotal = 0;
                AreaEquivalenteDiferenteDaCobertaPadraoUnitaria = 0;
                DecideAreaDoTerreno = false;
                AreaDoTerreno = 0;
                try
                {
                    return (decimal)(Area * Repeticao);
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                AreaRealCobertaPadraoTotal = 0;
                DecideAreaDoTerreno = false;
                AreaDoTerreno = 0;
                return 0;
            }
        }

        private decimal CalculaAreaRealDiferenteDaCobertaPadraoTotal()
        {
            if (DecideAreaPadrao is false)
            {
                try
                {
                    return (decimal)(Area * Repeticao);
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        private decimal CalculaAreaEquivalenteDiferenteDaCobertaPadraoTotal()
        {
            if (DecideAreaPadrao is false)
            {
                try
                {
                    return (decimal)(Area * Repeticao * Coeficiente);
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        private decimal CalculaAreaEquivalenteDiferenteDaCobertaPadraoUnitaria()
        {
            if (DecideAreaPadrao is false)
            {
                try
                {
                    return (decimal)(Area * Coeficiente);
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        private decimal CalculaAreaDoTerreno()
        {
            if (DecideAreaDoTerreno is true)
            {
                AreaRealCobertaPadraoTotal = 0;
                AreaRealDiferenteDaCobertaPadraoTotal = 0;
                AreaEquivalenteDiferenteDaCobertaPadraoTotal = 0;
                AreaEquivalenteDiferenteDaCobertaPadraoUnitaria = 0;
                DecideAreaPadrao = false;
                try
                {
                    return (decimal)(Area * Repeticao);
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public ValidationResult MemoriaDominioResult()
        {
            return _memoriaValidator.Validate(this);
        }
    }
}
