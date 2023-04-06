using _14._3._3_FinalTask;

/* Доработайте вашу телефонную книгу из задания 14.2.10 предыдущего юнита так,
 * чтобы контакты телефонной книги были отсортированы сперва по имени, а затем по фамилии.
 */

PrintPhoneBook();

static void PrintPhoneBook()
{
    // Заполняем книгу
    var phoneBook = GetPhoneBook();

    while (true)
    {
        Console.WriteLine($"Введите число от 1 до {phoneBook.Count/2}");
        // Читаем введенный с консоли символ
        var input = Console.ReadKey().KeyChar;

        if (!Int32.TryParse(input.ToString(), out int pageNumber))
            Console.WriteLine(" - Это не число\n");
        else
        {
            /* Эту проверку уберем, т.к. реализована другая
            var parsed = Int32.TryParse(input.ToString(), out int pageNumber);
            */
            // пропускаем нужное количество элементов и берем 2 для показа на странице
            var pageContent = phoneBook.Skip((pageNumber - 1) * 2).Take(2).OrderBy(c => c.Name).ThenBy(c => c.LastName);

            Console.WriteLine();

            // Если в выборке нет результата, выводим сообщение
            if (pageContent.Count() == 0)
                Console.WriteLine("Страницы не существует");

            // выводим результат
            foreach (var entry in pageContent)
                Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

            Console.WriteLine();
        }
    }
}

static List<Contact> GetPhoneBook()
{
    var phoneBook = new List<Contact>();
    phoneBook.Add(new Contact("Игорь", "Николаев", 79990000331, "igor@example.com"));
    phoneBook.Add(new Contact("Игорь", "Анисимов", 79990000001, "igor2@example.com"));
    phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
    phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
    phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
    phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
    phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
    phoneBook.Add(new Contact("Иван", "Бобров", 79990088001, "ivbob@example.com"));
    return phoneBook;
}