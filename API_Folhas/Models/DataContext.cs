using Microsoft.EntityFrameworkCore;

namespace API_Folhas.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {

        }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}