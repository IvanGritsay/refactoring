using System;
using System.Text;

class Airplane
{
    protected string StartCity;
    protected string FinishCity;
    protected DateTime StartDate;
    protected DateTime FinishDate;

    public Airplane() { }

    public Airplane(string startCity, string finishCity, DateTime startDate, DateTime finishDate)
    {
        StartCity = startCity;
        FinishCity = finishCity;
        StartDate = startDate;
        FinishDate = finishDate;
    }

    public string SetGetStartCity
    {
        get { return StartCity; }
        set { StartCity = value; }
    }

    public string SetGetFinishCity
    {
        get { return FinishCity; }
        set { FinishCity = value; }
    }

    public DateTime SetGetStartDate
    {
        get { return StartDate; }
        set { StartDate = value; }
    }

    public DateTime SetGetFinishDate
    {
        get { return FinishDate; }
        set { FinishDate = value; }
    }

    public int GetTotalTime()
    {
        TimeSpan duration = FinishDate - StartDate;
        return (int)duration.TotalMinutes;
    }

    public bool IsArriving()
    {
        return StartDate.Date == FinishDate.Date;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;

        Console.WriteLine("Виберіть номер завдання: ");
        int num = int.Parse(Console.ReadLine());

        switch (num)
        {
            case 1:
                Airplane[] airplanes = ReadAirplaneArray();
                Console.WriteLine("Сортування за датою:");
                SortAirplanesByDate(airplanes);
                PrintAirplanes(airplanes);

                Console.WriteLine("\nСортування за загальним часом:");
                SortAirplanesByTotalTime(airplanes);
                PrintAirplanes(airplanes);

                int minTravelTime, maxTravelTime;
                GetAirplaneInfo(airplanes, out minTravelTime, out maxTravelTime);
                Console.WriteLine($"\nМінімальний час подорожі: {minTravelTime} хвилин");
                Console.WriteLine($"Максимальний час подорожі: {maxTravelTime} хвилин");

                foreach (var airplane in airplanes)
                {
                    Console.WriteLine("Деталі польоту:");
                    PrintAirplane(airplane);
                    Console.WriteLine($"Загальний час подорожі: {airplane.GetTotalTime()} хвилин");
                    Console.WriteLine($"Прибуває: {airplane.IsArriving()}");
                }
                break;
        }
    }

    static Airplane[] ReadAirplaneArray()
    {
        Console.WriteLine("Введіть кількість літаків: ");
        int n = int.Parse(Console.ReadLine());

        Airplane[] airplanes = new Airplane[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введіть деталі для літака {i + 1}:");
            Console.Write("Початкове місто: ");
            string startCity = Console.ReadLine();
            Console.Write("Кінцеве місто: ");
            string finishCity = Console.ReadLine();
            Console.Write("Початкова дата (рік місяць день години хвилини): ");
            DateTime startDate = ReadDateTime();
            Console.Write("Кінцева дата (рік місяць день години хвилини): ");
            DateTime finishDate = ReadDateTime();

            airplanes[i] = new Airplane(startCity, finishCity, startDate, finishDate);
            Console.WriteLine();
        }
        return airplanes;
    }

    static DateTime ReadDateTime()
    {
        string[] input = Console.ReadLine().Split(' ');
        return new DateTime(
            int.Parse(input[0]),
            int.Parse(input[1]),
            int.Parse(input[2]),
            int.Parse(input[3]),
            int.Parse(input[4]),
            0
        );
    }

    static void PrintAirplane(Airplane airplane)
    {
        Console.WriteLine($"Початкове місто: {airplane.SetGetStartCity}");
        Console.WriteLine($"Кінцеве місто: {airplane.SetGetFinishCity}");
        Console.WriteLine($"Початкова дата: {airplane.SetGetStartDate}");
        Console.WriteLine($"Кінцева дата: {airplane.SetGetFinishDate}");
    }

    static void PrintAirplanes(Airplane[] airplanes)
    {
        foreach (var airplane in airplanes)
        {
            PrintAirplane(airplane);
            Console.WriteLine();
        }
    }

    static void GetAirplaneInfo(Airplane[] airplanes, out int maxTravelTime, out int minTravelTime)
    {
        minTravelTime = int.MaxValue;
        maxTravelTime = int.MinValue;

        foreach (var airplane in airplanes)
        {
            int travelTime = airplane.GetTotalTime();
            if (travelTime < minTravelTime)
                minTravelTime = travelTime;
            if (travelTime > maxTravelTime)
                maxTravelTime = travelTime;
        }
    }

    static void SortAirplanesByDate(Airplane[] airplanes)
    {
        Array.Sort(airplanes, (x, y) => x.SetGetStartDate.CompareTo(y.SetGetStartDate));
    }

    static void SortAirplanesByTotalTime(Airplane[] airplanes)
    {
        Array.Sort(airplanes, (x, y) => x.GetTotalTime().CompareTo(y.GetTotalTime()));
    }
}
