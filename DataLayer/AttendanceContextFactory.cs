using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System.IO;

namespace DataLayer
{
  public class AttendanceContextFactory : IDesignTimeDbContextFactory<AttendanceContext>
  {
    public AttendanceContext CreateDbContext(string[] args)
    {
      var configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .Build();

      var optionsBuilder = new DbContextOptionsBuilder<AttendanceContext>();
      optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

      return new AttendanceContext(optionsBuilder.Options);
    }
  }
}
