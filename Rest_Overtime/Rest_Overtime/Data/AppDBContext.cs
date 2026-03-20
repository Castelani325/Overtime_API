using Microsoft.EntityFrameworkCore;
using Rest_Overtime.Model;



namespace Rest_Overtime.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<RequestModel> OvertimeRequest { get; set; }
        public DbSet<RequestEmployeeModel> OvertimeEmployees { get; set; }

    }
    
}