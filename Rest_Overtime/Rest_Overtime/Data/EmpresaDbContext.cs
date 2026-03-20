using Microsoft.EntityFrameworkCore;
using Rest_Overtime.Model; 
using Rest_Overtime.Entity; // Onde está a sua Entity (Entidade)

namespace Rest_Overtime.Data
{
    public class EmpresaDbContext : DbContext
    {
        public EmpresaDbContext(DbContextOptions<EmpresaDbContext> options) : base(options)
        {
        }

        // Aqui você mapeia a Entidade que aponta para a tabela da empresa
        public DbSet<EmployeeEntity> FuncionariosEmpresa { get; set; }

        
    }
}