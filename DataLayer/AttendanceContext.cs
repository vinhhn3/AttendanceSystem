using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
  public class AttendanceContext : DbContext
  {
    public AttendanceContext(DbContextOptions<AttendanceContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
  }
}
