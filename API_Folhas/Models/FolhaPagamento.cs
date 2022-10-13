using System.ComponentModel.DataAnnotations;

namespace API_Folhas.Models
{
    public class FolhaPagamento
    {
        [Key]
        public int Id { get; set; }
        public int QuantidadeHoras { get; set; }
        public double ValorHora { get; set; }
        public double SalarioBruto { get; set; }
        public double ImpostoRenda { get; set; }
        public double ImpostoInss { get; set; }
        public double ImpostoFgts { get; set; }
        public double SalarioLiquido { get; set; }

    }
}