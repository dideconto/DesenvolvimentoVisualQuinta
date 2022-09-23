using System.ComponentModel.DataAnnotations;
using System.Linq;
using API_Folhas.Models;

namespace API_Folhas.Validations
{
    public class CpfEmUso : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cpf = (string)value;

            DataContext context =
                (DataContext)
                validationContext.
                GetService(typeof(DataContext));

            Funcionario resultado =
                context.Funcionarios.FirstOrDefault
                (
                    f => f.Cpf.Equals(cpf)
                );
            return resultado == null ?
                ValidationResult.Success :
                new ValidationResult("Esse funcionário já existe!");
        }
    }
}
