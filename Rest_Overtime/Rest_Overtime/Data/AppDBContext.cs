using Microsoft.EntityFrameworkCore;
using Rest_Overtime.Model;


namespace Rest_Overtime.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<OvertimeRequestDTO> OvertimeRequest { get; set; }
        public DBSet<EmployeeDto> Employees { get; set; }

    }
    }
}