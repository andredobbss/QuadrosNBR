using FluentValidation.Results;
using QuadrosNBR.Dominio.Entities.Base;
using QuadrosNBR.Dominio.Validations;

namespace QuadrosNBR.Dominio.Entities
{
    public class MemoriaDominio : BaseDominio
    {
        private readonly MemoriaValidator _memoriaValidator = new();

        public MemoriaDominio(
            string nomeDaLayer,
            decimal area,
            string descricao,
            uint repeticao,
            string unidade,
            string pavimento,
            string uso,
            decimal coeficiente,
            bool areaCobertaAberta,
            bool proporcionalidade,
            bool acessoria,
            string observacao,
            bool terreno,
            Guid projetoId,
            Guid tenantId) : base(projetoId, tenantId)
        {
            NomeDaLayer = nomeDaLayer;
            Area = area;
            Descricao = descricao;
            Repeticao = repeticao;
            Unidade = unidade;
            Pavimento = pavimento;
            Uso = uso;
            Coeficiente = coeficiente;
            AreaCobertaAberta = areaCobertaAberta;
            Proporcionalidade = proporcionalidade;
            Acessoria = acessoria;
            Observacao = observacao;
            Terreno = terreno;
            AreaCobertaPadrao = CalculoAreaCobertaAberta();
            AreaDiferenteDaCobertaPadrao = CalculoAreaDiferenteDaCobertaPadrao();
            AreaEquivalenteDiferenteDaCobertaPadraoTotal = CalculoAreaEquivalenteDiferenteDaCobertaPadraoTotal();
            AreaEquivalenteDiferenteDaCobertaPadraoUnitaria = CalculoAreaEquivalenteDiferenteDaCobertaPadraoInitaria();
            AreaCobertaPadrao1 = CalculoAreaCobertaPadrao1();
            AreaDiferenteDaCobertaPadrao1 = CalculoAreaDiferenteDaCobertaPadrao1();
            AreaEquivalenteDiferenteDaCobertaPadraoTotal1 = CalculoAreaEquivalenteDiferenteDaCobertaPadraoTotal1();
            AreaEquivalenteDiferenteDaCobertaPadraoUnitaria1 = CalculoAreaEquivalenteDiferenteDaCobertaPadraoUnitaria1();
            AreaAcessoria = CalculoAreaAcessoria();
            AreaDoTerreno = CalculoAreaDoTerreno();
        }

        public string NomeDaLayer { get; private set; }
        public decimal Area { get; private set; }
        public string Descricao { get; private set; }
        public uint Repeticao { get; private set; }
        public string Unidade { get; private set; }
        public string Pavimento { get; private set; }
        public string Uso { get; private set; }
        public decimal Coeficiente { get; private set; }
        public bool AreaCobertaAberta { get; private set; }
        public bool Proporcionalidade { get; private set; }
        public bool Acessoria { get; private set; }
        public string Observacao { get; private set; }
        public bool Terreno { get; private set; }
        public double AreaCobertaPadrao { get; private set; }
        public double AreaDiferenteDaCobertaPadrao { get; private set; }
        public double AreaEquivalenteDiferenteDaCobertaPadraoTotal { get; private set; }
        public double AreaEquivalenteDiferenteDaCobertaPadraoUnitaria { get; private set; }
        public double AreaCobertaPadrao1 { get; private set; }
        public double AreaDiferenteDaCobertaPadrao1 { get; private set; }
        public double AreaEquivalenteDiferenteDaCobertaPadraoTotal1 { get; private set; }
        public double AreaEquivalenteDiferenteDaCobertaPadraoUnitaria1 { get; private set; }
        public double AreaAcessoria { get; private set; }
        public double AreaDoTerreno { get; private set; }


        private double CalculoAreaCobertaAberta()
        {
            if (AreaCobertaAberta is true && Acessoria is false && Terreno is false)
            {
                return (double)Math.Round(Area * Repeticao, 4);
            }
            else
            {
                return 0;
            }
        }

        private double CalculoAreaDiferenteDaCobertaPadrao()
        {
            if(AreaCobertaAberta is false && Acessoria is false && Terreno is false)
            {
                return (double)Math.Round(Area * Repeticao, 4);
            }
            else
            {
                return 0;
            }
        }

        private double CalculoAreaEquivalenteDiferenteDaCobertaPadraoTotal()
        {
            if (AreaCobertaAberta is false && Acessoria is false && Terreno is false)
            {
                return (double)Math.Round(Area * Repeticao * Coeficiente, 4);
            }
            else
            {
                return 0;
            }
        }

        private double CalculoAreaEquivalenteDiferenteDaCobertaPadraoInitaria()
        {
            if (AreaCobertaAberta is false && Acessoria is false && Terreno is false)
            {
                return (double)Math.Round(Area * Repeticao, 4);
            }
            else
            {
                return 0;
            }

        }

        private double CalculoAreaCobertaPadrao1()
        {
            if (AreaCobertaAberta is true && Acessoria is false && Terreno is false)
            {
                return (double)Math.Round(Area, 4);
            }
            else
            {
                return 0;
            }
        }

        private double CalculoAreaDiferenteDaCobertaPadrao1()
        {
            if (AreaCobertaAberta is false && Acessoria is false && Terreno is false)
            {
                return (double)Math.Round(Area, 4);
            }
            else
            {
                return 0;
            }
        }

        private double CalculoAreaEquivalenteDiferenteDaCobertaPadraoTotal1()
        {
            if (AreaCobertaAberta is false && Acessoria is false && Terreno is false)
            {
                return (double)Math.Round(Area * Coeficiente, 4);
            }
            else
            {
                return 0;
            }
        }

        private double CalculoAreaEquivalenteDiferenteDaCobertaPadraoUnitaria1()
        {
            if (AreaCobertaAberta is false && Acessoria is false && Terreno is false)
            {
                return (double)Math.Round(Area * Coeficiente, 4);
            }
            else
            {
                return 0;
            }
        }
         
        private double CalculoAreaAcessoria()
        {
            if(Acessoria is true)
            {
                return (double)Math.Round(Area, 4);
            }
            else
            {
                return 0;
            }
        }

        private double CalculoAreaDoTerreno()
        {
            if (Terreno is true)
            {
                return (double)Math.Round(Area, 4);
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
