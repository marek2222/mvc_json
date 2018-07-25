using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonMVC.Models
{
  public class Student
  {
    public string Name { get; set; }
    public IList<Class> ClassesTaken { get; set; }
  }

  public class Class
  {
    public string Name { get; set; }
    public IList<Exam> ExamesTaken { get; set; }
  }

  public class Exam
  {
    public DateTime ExamTime { get; set; }
    public string Description { get; set; }
    public int Score { get; set; }
  }
}