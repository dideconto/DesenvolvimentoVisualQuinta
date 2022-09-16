using Microsoft.EntityFrameworkCore;

namespace API_Folhas.Models
{
    //Classe que reprenta o banco de dados dentro da aplicação
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        { }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FolhaPagamento> Folhas { get; set; }
    }
}