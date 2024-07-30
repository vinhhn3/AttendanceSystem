using System;

namespace DataLayer
{
  public class Attendance
  {
    public int AttendanceId { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int ClassId { get; set; }
    public Class Class { get; set; }
    public DateTime Date { get; set; }
    public bool IsPresent { get; set; }
  }
}
