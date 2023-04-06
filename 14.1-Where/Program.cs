
using System.Linq;

var russianCities = AddRusCities();

//GetBigCities(russianCities);
//Task_14_1_1(russianCities);
HardWhere();
//Task_14_1_2();

Console.ReadKey();

static List<City> AddRusCities()
{
    // Добавим Россию с её городами
    var russianCities = new List<City>();
    russianCities.Add(new City("Москва", 11900000));
    russianCities.Add(new City("Санкт-Петербург", 4991000));
    russianCities.Add(new City("Волгоград", 1099000));
    russianCities.Add(new City("Казань", 1169000));
    russianCities.Add(new City("Ставрополь", 449138));
    return russianCities;
}

static void GetBigCities(List<City> russianCities)
{
    var bigCities1 = from russianCity in russianCities
                    where russianCity.Population > 1000000    // Поиск города с населением более 1000000
                    orderby russianCity.Population descending // Сортировка в обратном порядке (большее сверху)
                    select russianCity;

    // Или так
    var bigCities2 = russianCities.Where(c => c.Population > 1000000).OrderByDescending(c => c.Population);

    foreach (var bigCity in bigCities2)
        Console.WriteLine(bigCity.Name + " - " + bigCity.Population);
}

// Задание 14.1.1 - выбрать все города, название у которых не длиннее 10 букв, и отсортируйте их по длине названия
static void Task_14_1_1(List<City> russianCities)
{
    var cities = russianCities.Where(c => c.Name.Length <= 10).OrderBy(c => c.Name.Length);
    foreach (var city in cities)
        Console.WriteLine(city.Name);
}

// Сложная выборка
static void HardWhere()
{
    // Теперь у нас города будут храниться в списке стран (каждая страна должна иметь свои города).
    // Словарь для хранения стран с городами
    var Countries = new Dictionary<string, List<City>>();

    // Добавим Россию с её городами
    var russianCities = AddRusCities();
    Countries.Add("Россия", russianCities);

    // Добавим Беларусь
    var belarusCities = new List<City>();
    belarusCities.Add(new City("Минск", 1200000));
    belarusCities.Add(new City("Витебск", 362466));
    belarusCities.Add(new City("Гродно", 368710));
    Countries.Add("Беларусь", belarusCities);

    // Добавим США
    var americanCities = new List<City>();
    americanCities.Add(new City("Нью-Йорк", 8399000));
    americanCities.Add(new City("Вашингтон", 705749));
    americanCities.Add(new City("Альбукерке", 560218));
    Countries.Add("США", americanCities);

    // Задача: сделать выборку городов-миллионников по всем странам.
    var cities1 = from country in Countries // пройдемся по странам
                 from city in country.Value // пройдемся по городам
                 where city.Population > 1000000 // выберем города - миллионники
                 orderby city.Population descending // отсортируем по населению
                 select city;

    // Или так
    var cities2 = Countries.SelectMany(country => country.Value)
                       .Where(city => city.Population > 1000000)
                       .OrderByDescending(city => city.Population);

    foreach (var city in cities2)
        Console.WriteLine(city.Name + " - " + city.Population);
}

static void Task_14_1_2()
{
    // Соедините все слова в одну последовательность (каждое слово — отдельный элемент последовательности).
    // Используйте синтаксис LINQ - выражений.
    string[] textArr = { "Раз два три", "четыре пять шесть", "семь восемь девять" };
    var words1 = from str in textArr
               from word in str.Split(' ')
               select word;

    // Или так
    var words2 = textArr.SelectMany(w => w.Split(' '));

    foreach (var word in words2)
        Console.WriteLine(word);
}


public class City
{
    public City(string name, long population)
    {
        Name = name;
        Population = population;
    }

    public string Name { get; set; }
    public long Population { get; set; }
}

