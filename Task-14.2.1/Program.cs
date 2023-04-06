// Задание 14.2.1
// Дан массив слов
// Сделайте выборку в анонимный тип с одновременной сортировкой слов по длине. Результат выведите в консоль.

string[] words = { "Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха" };

var wordsAnonim = words.Select(w => new
{
    Word = w,
    WordLength = w.Length
}).OrderBy(w => w.WordLength);

foreach (var v in wordsAnonim)
    Console.WriteLine($"{v.Word} ({v.WordLength})");

Console.ReadKey();