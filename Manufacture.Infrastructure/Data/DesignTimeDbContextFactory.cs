using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Manufacture.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(
                "Data Source=LENOVO\\SQLEXPRESS01;Initial Catalog=CourseManufacture;User Id=1;Password=1;TrustServerCertificate=True");
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}