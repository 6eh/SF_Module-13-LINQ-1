// Задание 14.2.10

//PrintPhoneBookMy();
PrintPhoneBookSF();

Console.ReadKey();

static void PrintPhoneBookMy()
{
    var contacts = GetPhoneBook();
    while (true)
    {
        var keyChar = Console.ReadKey().KeyChar; // получаем символ с консоли
        Console.Clear();  //  очистка консоли от ввода
        if (!Char.IsDigit(keyChar))
        {
            Console.WriteLine("Ошибка ввода, введите число");
        }
        else
        {
            IEnumerable<Contact> page = null;

            //  выбираем нужное кол-во элементов для создания постраничного ввода в зависимости от запроса
            switch (keyChar)
            {
                case ('1'):
                    page = contacts.Take(2);
                    break;
                case ('2'):
                    page = contacts.Skip(2).Take(2);
                    break;
                case ('3'):
                    page = contacts.Skip(4).Take(2);
                    break;
            }

            //   проверим, что ввели существующий номер страницы
            if (page == null)
            {
                Console.WriteLine($"Ошибка ввода, страницы {keyChar} не существует");
                continue;
            }

            // вывод результата на консоль
            foreach (var contact in page)
                Console.WriteLine(contact.Name + " " + contact.PhoneNumber);
        }
    }
}

static void PrintPhoneBookSF()
{
    var phoneBook = GetPhoneBook();
    while (true)
    {
        // Читаем введенный с консоли символ
        var input = Console.ReadKey().KeyChar;

        // проверяем, число ли это
        var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

        // если не соответствует критериям - показываем ошибку
        if (!parsed || pageNumber < 1 || pageNumber > 3)
        {
            Console.WriteLine();
            Console.WriteLine("Страницы не существует");
        }
        // если соответствует - запускаем вывод
        else
        {
            // пропускаем нужное количество элементов и берем 2 для показа на странице
            var pageContent = phoneBook.Skip((pageNumber - 1) * 2).Take(2);
            Console.WriteLine();

            // выводим результат
            foreach (var entry in pageContent)
                Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

            Console.WriteLine();
        }
    }
}

static List<Contact> GetPhoneBook()
{
    //  создаём пустой список с типом данных Contact
    var phoneBook = new List<Contact>();

    // добавляем контакты
    phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
    phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
    phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
    phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
    phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
    phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
    return phoneBook;
}

public class Contact // модель класса
{
    public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
    {
        Name = name;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public String Name { get; }
    public String LastName { get; }
    public long PhoneNumber { get; }
    public String Email { get; }
}