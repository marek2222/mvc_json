using JsonMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonMVC.Repositories
{
  public class StudentsRepository
  {

    public void Initialize(int NoOfStudents, int NoOfClasses, int NoOfExams)
    {
      List<Student> students = new List<Student>();
      Random rd = new Random();
      for (int iStudent = 0; iStudent < NoOfStudents; iStudent++)
      {
        Student aStudent = new Student();
        aStudent.Name = "Student Name No. " + iStudent.ToString();
        aStudent.ClassesTaken = new List<Class>();
        for (int iClass = 0; iClass < NoOfClasses; iClass++)
        {
          Class aClass = new Class();
          aClass.Name = "Class No. " + iClass.ToString();
          aClass.ExamesTaken = new List<Exam>();
          for (int iExam = 0; iExam < NoOfExams; iExam++)
          {
            Exam aExam = new Exam();
            aExam.ExamTime = System.DateTime.Now;
            aExam.Description = "Exam No. " + iExam.ToString();
            aExam.Score = Convert.ToInt16(60 + rd.NextDouble() * 40);

            aClass.ExamesTaken.Add(aExam);
          }

          aStudent.ClassesTaken.Add(aClass);
        }
        students.Add(aStudent);
      }
      HttpContext.Current.Session["Students"] = students;
    }

    public IList<Student> GetStudents()
    {
      return (List<Student>)HttpContext.Current.Session["Students"];
    }

    public void SetStudents(IList<Student> students)
    {
      HttpContext.Current.Session["Students"] = students;
    }


  }
}