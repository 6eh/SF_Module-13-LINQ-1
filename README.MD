<H1>LINQ</H1>
LINQ to Objects: применяется для работы с массивами и коллекциями;
LINQ to Entities: применяется для работы с базой данных через Entity Framework;
LINQ to SQL: технология доступа к данным в MS SQL Server;
LINQ to XML: применяется при работе с файлами XML;
LINQ to DataSet: применяется при работе с объектом DataSet;
Parallel LINQ (PLINQ): используется для выполнения параллельных запросов.

<H2>Методы LINQ</H2>

<b>OrderBy</b>
Упорядочивает элементы по возрастанию.
```csharp
var nums = new List<int>() {2, 9, 7};
var orderedNums = nums.OrderBy(n => n);
 
// вернёт 2, 7, 9
foreach (var num in orderedNums)
   Console.WriteLine(num);
```
<b>OrderByDescending</b>
Упорядочивает элементы по убыванию.
```csharp
var nums = new List<int>() {2, 9, 7};
var orderedNums = nums.OrderByDescending(n => n);
 
// вернeт 9, 7, 2
foreach (var num in orderedNums)
   Console.WriteLine(num);
```
<b>Where</b>
Определяет фильтр выборки.
```csharp
var nums = new List<int>() {2, 9, 7};
var lessThenFive = nums.Where(n => n < 5);
 
// вернёт 2
foreach (var num in lessThenFive)
   Console.WriteLine(num);
```
<b>All</b>
Определяет, все ли элементы коллекции удовлетворяют определенному условию.
```csharp
var nums = new List<int>() {2, 9, 7};
 
if (nums.All(n => n < 5))
{
   Console.WriteLine( "Все меньше пяти" );
}
```
<b>Any</b>
Определяет, удовлетворяет ли хотя бы один элемент коллекции определенному условию.
```csharp
var nums = new List<int>() {2, 9, 7};
 
if (nums.Any(n => n < 5))
{
   Console.WriteLine( "Хотя бы один < 5" );
}
```
<b>GroupBy</b>
Группирует элементы по ключу.
```csharp
var employees = new List<Employee>
{
   new Employee {Name="Иван", DepartMent= "Продажи" },
   new Employee {Name="Анна", DepartMent="Продажи" },
   new Employee {Name="Кирилл", DepartMent="Разработка" },
   new Employee {Name="Дмитрий", DepartMent="Разработка" },
   new Employee {Name="Олег", DepartMent="Разработка" },
};
 
// группируем сотрудников по департаменту
var groups = employees
   .GroupBy(e => e.DepartMent);
 
foreach (var group in groups)
{
   Console.WriteLine(group.Key);
 
   foreach (var e in group)
       Console.WriteLine(e.Name);
 
   Console.WriteLine();
}
```
<b>ThenBy</b>
Задает дополнительные критерии для упорядочивания элементов возрастанию.
```csharp
var studentList  = new List<Student>() {
   new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
   new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
   new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
   new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
   new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 },
   new Student() { StudentID = 6, StudentName = "Ram" , Age = 18 }
};
 
var byNameAndAge = studentList
   // сортируем сначала по имени
   .OrderBy(s => s.StudentName)
   // потом по возрасту (по возрастанию)
   .ThenBy(s => s.Age);
```
<b>ThenByDescending</b>
Задает дополнительные критерии для упорядочивания элементов по убыванию.
```csharp
var byNameAndAge = studentList
   // сортируем сначала по имени
   .OrderBy(s => s.StudentName)
   // потом по возрасту (по убыванию)
   .ThenByDescending(s => s.Age);
```
<b>Reverse</b>
Располагает элементы в обратном порядке.
```csharp
var nums = new List<int>() {2, 9, 7};
nums.Reverse(); // вернет 7, 9, 2
```
<b>Contains</b>
Определяет, содержит ли коллекция определенный элемент.
```csharp
var nums = new List<int>() {2, 9, 7};
 
if (nums.Contains(2))
{
   Console.WriteLine("Нашли двойку");
}
```
<b>Distinct</b>
Удаляет дублирующиеся элементы из коллекции.
```csharp
var nums = new List<int>() {2, 9, 7 , 2};
var uniqueNums = nums.Distinct();
 
foreach (var number in uniqueNums)
   Console.WriteLine(number);   // выведет 2, 9, 7
```
<b>Except</b>
Возвращает разность двух коллекций, то есть те элементы, которые создаются только в одной коллекции.
```csharp
var listOne = new List<int>() {7 , 2, 4, 11};
var listTwo = new List<int>() {2, 9, 7 , 8, 0};
 
var result = listOne.Except(listTwo);
 
foreach (var number in result)
   Console.WriteLine(number);
 
// выведет 4 и 11, так как их нет во второй коллекции
```
<b>Union</b>
Объединяет уникальные элементы двух однородных коллекций.
```csharp
var listOne = new List<int>() {7 , 2};
var listTwo = new List<int>() {2, 9};
 
var result = listOne.Union(listTwo);
 
foreach (var number in result)
   Console.WriteLine(number);
 
// выведет 7, 2, 9
```
<b>Intersect</b>
Возвращает пересечение двух коллекций, то есть те элементы, которые встречаются в обоих коллекциях.
```csharp
var listOne = new List<int>() {7 , 2};
var listTwo = new List<int>() {2, 9};
 
var result = listOne.Intersect(listTwo);
 
foreach (var number in result)
   Console.WriteLine(number);
 
// выведет общий элемент для обеих коллекций - 2
```
<b>Count</b>
Подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию.
```csharp
var listOne = new List<int>() {7 , 2, 57, 8};
 
var result = listOne.Count(e => e < 10);
 
Console.WriteLine($"Количество элементов меньше 10: {result}");
// Выведет 3
```
<b>Sum</b>
Подсчитывает сумму числовых значений в коллекции.
```csharp
var listOne = new List<int>() {7 , 2, 57, 8};
var sum = listOne.Sum();
// Выведет 74
```
<b>Average</b>
Подсчитывает cреднее значение числовых значений в коллекции.
```csharp
var listOne = new List<int>() {7 , 2, 57, 8};
var average = listOne.Average();
// Выведет среднее арифметическое ( 18.5 )
```
<b>Min, Max</b>
Находит минимальное и максимальное значения соответственно.
```csharp
var listOne = new List<int>() {7 , 2, 57, 8};
 
Console.WriteLine(listOne.Min()); // 2
Console.WriteLine(listOne.Max()); // 57
```
<b>Take</b>
Выбирает определенное количество элементов.
```csharp
var listOne = new List<int>() {7 , 2, 57, 8};
 
var res = listOne.Take(2);
// выберет первые два элемента (7 и 2)
```
<b>Skip</b>
Пропускает определенное количество элементов.
```csharp
var listOne = new List<int>() {7 , 2, 57, 8};
 
var res = listOne.Skip(1);
// пропустит 1 элемент (получит 2, 57, 8)
```
<b>TakeWhile</b>
Возвращает цепочку элементов последовательности до тех пор, пока условие истинно.
```csharp
var listOne = new List<int>() {7 , 2, 57, 8};
 
var res = listOne.TakeWhile( e => e < 10 );
// будет возвращать новые элементы коллекции до тех пор, пока не встретит тот, для которого условие не выполнится (в выборку попадут только 7 и 2)
```
<b>SkipWhile</b>
Пропускает элементы в последовательности пока они удовлетворяют заданному условию и затем возвращает оставшиеся элементы.
```csharp
var listOne = new List<int>() {7 , 2, 57, 8};
 
var res = listOne.SkipWhile( e => e < 10 );
// пропустит все элементы до первого, который удовлетворит условию
```
<b>Concat</b>
Объединяет две коллекции.
```csharp
var listOne = new List<int>() {7 , 2, };
var listTwo = new List<int>() { 2, 8};
 
var concatenation = listOne.Concat(listTwo);
// выведет 7, 2, 2, 8 (т.е. допускает повторяющиеся элементы)
```
<b>Zip</b>
Объединяет две коллекции в соответствии с определенным условием.
```csharp
var listOne = new List<int>() {7 , 2, };
var listTwo = new List<int>() { 2, 8};
 
var result = listOne.Zip(listTwo, (a, b) => a + b);
 
// объединяет элементы коллекций, выполняя определенные действия
// здесь - попарное сложение, в результате 9 и 10
```
<b>First</b>
Выбирает первый элемент коллекции, удовлетворяющий условию.
```csharp
var listOne = new List<int>() {7 , 2, };
Console.WriteLine(listOne.First()); 
// получим 7
```
<b>FirstOrDefault</b>
Выбирает первый элемент коллекции, удовлетворяющий условию, или возвращает значение по умолчанию.
```csharp
var listOne = new List<int>() {7 , 2, 4, 10 };
Console.WriteLine(listOne.FirstOrDefault(a => a < 7)); 
// получим 2, но если бы ничего не нашлось - вернуло бы 0
```
<b>Single</b>
Выбирает единственный элемент коллекции, если коллекция содержит больше или меньше одного элемента, удовлетворяющего условию, то генерируется исключение.
```csharp
string[] students = { "Оля", "Иван", "Сергей", "Бонифаций"};

string firstWithLongName = students.Single(student => student.Length > 8);
 
Console.WriteLine(firstWithLongName);   // Бонифаций
```
<b>SingleOrDefault</b>
Выбирает первый элемент коллекции или возвращает значение по умолчанию.
```csharp
string[] students = { "Оля", "Иван", "Сергей", "Бонифаций"};
string firstWithLongName = students.SingleOrDefault(student => student.Length > 10);
 
Console.WriteLine(firstWithLongName);
// Здесь вернет null, так как это значение по умолчанию для типа String
```
<b>ElementAt</b>
Выбирает элемент последовательности по определенному индексу.
```csharp
var listOne = new List<int>() {7 , 2, 4, 10 };
var second = listOne.ElementAt(1);
Console.WriteLine(second);
// получим 2
```
<b>Last</b>
Выбирает последний элемент коллекции.
```csharp
var listOne = new List<int>() {7 , 2, };
Console.WriteLine(listOne.Last()); 
// получим 2
```
<b>LastOrDefault</b>
Выбирает последний элемент коллекции или возвращает значение по умолчанию.
```csharp
var emptyList = new List<int>() {};
Console.WriteLine(listOne.LastOrDefault()); 
// получим 0, так как это значение по умолчанию для типа int
```