using System.Collections.Generic;

namespace DataLayer
{
  public class Class
  {
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public ICollection<Attendance> Attendances { get; set; }
  }
}
