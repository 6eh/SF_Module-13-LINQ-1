using System.Runtime.InteropServices;

/* LINQ позволяет выбирать объекты из разных источников данных, соединяя их в одну сущность. */

// Список студентов
List<Student> students = new List<Student>
{
   new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
   new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
   new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
   new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
};

// Список курсов
var courses = new List<Course>
{
   new Course {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
   new Course {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
};

// Добавим всех студентов в курсы
var studentsWithCources = from student in students
                          from course in courses
                          select new { Name = student.Name, CourseName = course.Name };

// Добавим в курсы только студентов, знающих английский
var studentsEngWithCources = from student in students
                          where student.Languages.Contains("английский")
                          from course in courses
                          select new { Name = student.Name, CourseName = course.Name };


Console.WriteLine("\nВ эти курсы добавлены все студенты:");
foreach (var stud in studentsWithCources)
    Console.WriteLine($"{stud.Name} длбавлен к курсу {stud.CourseName}");

Console.WriteLine("\nВ эти курсы добавлены только студенты со знанием английского:");

foreach (var stud in studentsEngWithCources)
    Console.WriteLine($"{stud.Name} длбавлен к курсу {stud.CourseName}");

Console.ReadKey();


internal class Student
{
    internal string Name { get; set; }
    internal int Age { get; set; }
    internal List<string> Languages { get; set; }
}

internal class Course
{
    internal string Name { get; set; }
    internal DateTime StartDate { get; set; }
}