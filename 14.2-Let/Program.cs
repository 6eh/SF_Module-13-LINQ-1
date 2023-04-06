/* Переменные в запросах, let
 * Довольно часто бывает, что при формировании запросов LINQ нам необходимо
 * выполнятьпромежуточные вычисления. Для этого LINQ поддерживает объявление
 * промежуточных переменных по ключевому слову let.
 * 
 * Методы расширения, не поддерживают определение внутренних локальных
 * переменных, и это одно из основных преимуществ операторов перед ними.
 */

List<Student> students = new List<Student>
{
   new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
   new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
   new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
   new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
};

//LetExample(students);
Task_14_2_3(students);


Console.ReadKey();

static void LetExample(List<Student> students)
{
    var fullNameStudents = from s in students
                               // временная переменная для генерации полного имени
                           let fullName = s.Name + " Иванов"
                           // проекция в новую сущность с использованием новой переменной
                           select new
                           {
                               Name = fullName,
                               Age = s.Age
                           };

    foreach (var stud in fullNameStudents)
        Console.WriteLine(stud.Name + ", " + stud.Age);
}

// Задание 14.2.3
// Выберите всех студентов моложе 27, сгенерируйте из них анкеты (модель класса Application).
// При вычислении года рождения используйте ключевое слово let.
static void Task_14_2_3(List<Student> students)
{
    var studentsUnder27 = from s in students
                          where s.Age < 27
                          let yearOfBirth = DateTime.Now.Year - s.Age
                          select new Application
                          {
                              Name = s.Name,
                              YearOfBirth = yearOfBirth
                          };

    foreach (var student in studentsUnder27)
        Console.WriteLine($"{student.Name}, {student.YearOfBirth}");
}


internal class Student
{
    internal string Name { get; set; }
    internal int Age { get; set; }
    internal List<string> Languages { get; set; }
}

public class Application
{
    public string Name { get; set; }
    public int YearOfBirth { get; set; }
}