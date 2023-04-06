// Проекция позволяет преобразовать данные текущей выборки в какой-либо другой тип
// Для этого используется оператор select (также есть соответствующий метод расширения)

using static System.Net.Mime.MediaTypeNames;

SelectExample();

Console.ReadKey();

static void SelectExample()
{
    // Подготовим данные
    List<Student> students = new List<Student>
    {
       new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
       new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
       new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
       new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
    };

    // выборка имен в строки
    var names = students.Select(u => u.Name);

    var studentApplications1 = from s in students
                              // создадим анонимный тип для представления анкеты
                              select new
                              {
                                  FirstName = s.Name,
                                  YearOfBirth = DateTime.Now.Year - s.Age
                              };

    // Или так (через методы расшинрения)
    // Проекция в анонимный тип:
    var studentApplications2 = students.Select(u => new { FirstName = u.Name, YearOfBirth = DateTime.Now.Year - u.Age });

    // проекция в другой тип
    var studentApplications3 = students.Select(u => new NewStudent()
    {
        FirstName = u.Name,
        YearOfBirth = DateTime.Now.Year - u.Age
    });

    // Выведем результат
    foreach (var name in studentApplications3)
        Console.WriteLine($"{name.FirstName} - {name.YearOfBirth}");
}

class NewStudent : Student
{
    internal string FirstName { get; set; }
    internal int YearOfBirth { get; set; }
}