/* Эти методы работают похожим образом со Skip и Take,
 * но с их помощью можно делать выборки по определенным условиям.
 */

// Допустим, у нас есть база данных машин, и мы знаем, что сначала идут японские:
// Подготовка данных
var cars = new List<Car>()
{
   new Car("Suzuki", "JP"),
   new Car("Toyota", "JP"),
   new Car("Opel", "DE"),
   new Car("Kamaz", "RUS"),
   new Car("Lada", "RUS"),
   new Car("Moskvich", "CN"),
   new Car("Honda", "JP"),
};

Console.WriteLine("Пропустим японские машины в начале списка");
var notJapanCars = cars.SkipWhile(car => car.CountryCode == "JP");

foreach (var notJapanCar in notJapanCars)
    Console.WriteLine(notJapanCar.Manufacturer);
// Honda попадает в выборку, т.к. метод останавливается на первом несоответствии (...new Car("Opel", "DE")...)

Console.WriteLine();

Console.WriteLine("Теперь выберем только японские машины из начала списка");
var japanCars = cars.TakeWhile(car => car.CountryCode == "JP");

foreach (var japanCar in japanCars)
    Console.WriteLine(japanCar.Manufacturer);

RemoveAllJP(cars);

Console.ReadKey();

// Задание 14.2.9
// Удалисть все Японские марки из списка
static void RemoveAllJP(List<Car> cars)
{
    Console.WriteLine("\nRemoveAll method:");
    cars.RemoveAll(c => c.CountryCode == "JP");
    foreach (var c in cars)
        Console.WriteLine(c.Manufacturer);
}

public class Car
{
    public string Manufacturer { get; set; }
    public string CountryCode { get; set; }

    public Car(string manufacturer, string countryCode)
    {
        Manufacturer = manufacturer;
        CountryCode = countryCode;
    }
}