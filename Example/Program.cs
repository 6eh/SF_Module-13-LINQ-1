// Задача: выбрать имена на букву А и отсортировать в алфавитном порядке.

/*string[] people = { "Анна", "Мария", "Сергей", "Алексей", "Дмитрий", "Ян" };

SortNoLinq(people);

Console.WriteLine("\n---\n");

SortWithLinq(people);*/

Task8();

Console.ReadKey();

// Метод без использования LINQ
static void SortNoLinq(string[] people)
{
    // список, куда будем сохранять выборку
    var orderedList = new List<string>();

    // пробежимся по массиву и добавим искомое в наш список
    foreach (string person in people)
    {
        if (person.ToUpper().StartsWith("А"))
            orderedList.Add(person);
    }

    // отсортируем список
    orderedList.Sort();
    foreach (string s in orderedList)
        Console.WriteLine(s);
}

// Метод с использованием LINQ (лаконичнее)
static void SortWithLinq(string[] people)
{
    var selectedPeople1 = from p in people // промежуточная переменная p 
                         where p.StartsWith("А") // фильтрация по условию
                         orderby p // сортировка по возрастанию (дефолтная)
                         select p; // выбираем объект и сохраняем в выборку

    // Или так
    var selectedPeople2 = people.Where(p => p.StartsWith("А")).OrderBy(p => p);

    Console.WriteLine("selectedPeople1:");
    foreach (string s in selectedPeople1)
        Console.WriteLine(s);

    Console.WriteLine("\nselectedPeople2:");
    foreach (string s in selectedPeople2)
        Console.WriteLine(s);
}

// Задание 8
// Используйте выражения LINQ, чтобы достать оттуда все имена
// и вывести их в консоль в алфавитном порядке.
static void Task8()
{
    var objects = new List<object>() { 1, "Сергей ", "Андрей ", 300 };

    var names1 = from n in objects
                 where n is string
                 orderby n
                 select n;

    var names2 = objects.Where(n => n is string).OrderBy(n => n);

    foreach (var name in names1)
        Console.WriteLine(name);

    Console.WriteLine();

    foreach (var name in names2)
        Console.WriteLine(name);
}