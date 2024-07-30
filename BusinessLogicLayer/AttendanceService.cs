using DataLayer;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
  public class AttendanceService
  {
    private readonly AttendanceContext _context;

    public AttendanceService(AttendanceContext context)
    {
      _context = context;
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
      return await _context.Students.ToListAsync();
    }

    public async Task<List<Class>> GetAllClassesAsync()
    {
      return await _context.Classes.ToListAsync();
    }

    public async Task MarkAttendanceAsync(int studentId, int classId, bool isPresent)
    {
      var attendance = new Attendance
      {
        StudentId = studentId,
        ClassId = classId,
        Date = DateTime.Now,
        IsPresent = isPresent
      };

      _context.Attendances.Add(attendance);
      await _context.SaveChangesAsync();
    }
  }
}
