using System;
using System.Text;

class Date
{
    public DateTime DateTimeValue { get; set; }

    public Date(int year, int month, int day = 1, int hours = 0, int minutes = 0)
    {
        DateTimeValue = new DateTime(year, month, day, hours, minutes, 0);
    }

    public Date(DateTime dateTime)
    {
        DateTimeValue = dateTime;
    }
}

class Airplane
{
    public string StartCity { get; set; }
    public string FinishCity { get; set; }
    public Date StartDate { get; set; }
    public Date FinishDate { get; set; }

    public Airplane(string startCity, string finishCity, Date startDate, Date finishDate)
    {
        StartCity = startCity;
        FinishCity = finishCity;
        StartDate = startDate;
        FinishDate = finishDate;
    }

    public TimeSpan GetTotalTime()
    {
        return FinishDate.DateTimeValue - StartDate.DateTimeValue;
    }

    public bool IsArriving()
    {
        return StartDate.DateTimeValue.Date == FinishDate.DateTimeValue.Date;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;

        Console.WriteLine("Введіть кількість літаків:");
        int n = int.Parse(Console.ReadLine());

        Airplane[] airplanes = new Airplane[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введіть деталі для літака {i + 1}:");
            Console.Write("Початкове місто: ");
            string startCity = Console.ReadLine();
            Console.Write("Кінцеве місто: ");
            string finishCity = Console.ReadLine();

            Console.Write("Початкова дата (рік-місяць-день години:хвилини): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Кінцева дата (рік-місяць-день години:хвилини): ");
            DateTime finishDate = DateTime.Parse(Console.ReadLine());

            airplanes[i] = new Airplane(startCity, finishCity, new Date(startDate), new Date(finishDate));
        }

        Console.WriteLine("Сортування за датою:");
        Array.Sort(airplanes, (x, y) => x.StartDate.DateTimeValue.CompareTo(y.StartDate.DateTimeValue));
        PrintAirplanes(airplanes);
    }

    static void PrintAirplanes(Airplane[] airplanes)
    {
        foreach (var airplane in airplanes)
        {
            Console.WriteLine($"Маршрут: {airplane.StartCity} → {airplane.FinishCity}");
            Console.WriteLine($"Виліт: {airplane.StartDate.DateTimeValue}");
            Console.WriteLine($"Приліт: {airplane.FinishDate.DateTimeValue}");
            Console.WriteLine($"Час у польоті: {airplane.GetTotalTime()}");
            Console.WriteLine($"Прибуває того ж дня: {airplane.IsArriving()}");
            Console.WriteLine();
        }
    }
}
