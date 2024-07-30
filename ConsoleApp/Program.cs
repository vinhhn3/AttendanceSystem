using BusinessLogicLayer;

using DataLayer;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var serviceProvider = ConfigureServices();
      var attendanceService = serviceProvider.GetService<AttendanceService>();

      Console.WriteLine("Attendance System");
      Console.WriteLine("1. List Students");
      Console.WriteLine("2. List Classes");
      Console.WriteLine("3. Mark Attendance");
      Console.Write("Select an option: ");

      var option = Console.ReadLine();

      switch (option)
      {
        case "1":
          var students = await attendanceService.GetAllStudentsAsync();
          Console.WriteLine("Students:");
          foreach (var student in students)
          {
            Console.WriteLine($"{student.StudentId}: {student.Name}");
          }
          break;
        case "2":
          var classes = await attendanceService.GetAllClassesAsync();
          Console.WriteLine("Classes:");
          foreach (var cls in classes)
          {
            Console.WriteLine($"{cls.ClassId}: {cls.ClassName}");
          }
          break;
        case "3":
          Console.Write("Enter Student Id: ");
          int studentId = int.Parse(Console.ReadLine());
          Console.Write("Enter Class Id: ");
          int classId = int.Parse(Console.ReadLine());
          Console.Write("Is Present (true/false): ");
          bool isPresent = bool.Parse(Console.ReadLine());
          await attendanceService.MarkAttendanceAsync(studentId, classId, isPresent);
          Console.WriteLine("Attendance marked.");
          break;
        default:
          Console.WriteLine("Invalid option.");
          break;
      }
    }

    private static ServiceProvider ConfigureServices()
    {
      var configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", false)
          .Build();

      var services = new ServiceCollection();

      services.AddDbContext<AttendanceContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

      services.AddScoped<AttendanceService>();

      return services.BuildServiceProvider();
    }
  }
}
