using System.Collections.Generic;

namespace DataLayer
{
  public class Student
  {
    public int StudentId { get; set; }
    public string Name { get; set; }
    public ICollection<Attendance> Attendances { get; set; }
  }
}
