//Task_14_1_5();
Task_14_1_6();

Console.ReadKey();

static void Task_14_1_5()
{
    // Дан список компаний
    // Сделайте выборку тех, которые производят мобильную технику.
    var companies = new Dictionary<string, string[]>();

    companies.Add("Apple", new[] { "Mobile", "Desktop" });
    companies.Add("Samsung", new[] { "Mobile" });
    companies.Add("IBM", new[] { "Desktop" });

    // Решение
    var mobileCompanies = companies
               // смотрим те из выборки, значения в которых содержат искомое
               .Where(c => c.Value.Contains("Mobile"));

    foreach (var company in mobileCompanies)
        Console.WriteLine(company.Key);
}

static void Task_14_1_6()
{
    // Дан массив
    // Сделайте выборку всех чисел в новую коллекцию, расположив их в ней по возрастанию.
    var numsList = new List<int[]>()
    {
       new[] {2, 3, 7, 1},
       new[] {45, 17, 88, 0},
       new[] {23, 32, 44, -6},
    };

    // Решение
    var result = numsList.SelectMany(i => i).OrderBy(i => i);

    foreach (var v in result)
        Console.WriteLine(v);
}