using System.Text;
using Microsoft.VisualBasic;
using System;

class Date
{
    protected int Year;
    protected int Month;
    protected int Day;
    protected int Hours;
    protected int Minutes;

    public Date()
    {

    }
    public Date(int year, int month, int day, int hours, int minutes)
    {
        Year = year;
        Month = month;
        Day = day;
        Hours = hours;
        Minutes = minutes;
    }

    public Date(int year, int month, int hours, int minutes)
    {
        Year = year;
        Month = month;
        Hours = hours;
        Minutes = minutes;
    }

        public Date(Date copy)
    {
        Year = copy.Year;
        Month = copy.Month;
        Day = copy.Day;
        Hours = copy.Hours;
        Minutes = copy.Minutes;

    }
    public int SetGetYear
    {
        get { return Year; }
        set { Year = value; }
    }
    public int SetGetMonth
    {
        get { return Month; }
        set { Month = value; }
    }
    public int SetGetDay
    {
        get { return Day; }
        set { Day = value; }
    }
    public int SetGetHours
    {
        get { return Hours; }
        set { Hours = value; }
    }
    public int SetGetMinutes
    {
        get { return Minutes; }
        set { Minutes = value; }
    }
}
class Airplane
{
    protected string StartCity;
    protected string FinishCity;
    protected Date StartDate;
    protected Date FinishDate;

    public Airplane()
    {

    }
    public Airplane(string startCity, string finishCity, Date startDate, Date finishDate)
    {
        StartCity = startCity;
        FinishCity = finishCity;
        StartDate = startDate;
        FinishDate = finishDate;
    }
    public Airplane(string startCity, string finishCity, Date startDate)
    {
        StartCity = startCity;
        FinishCity = finishCity;
        StartDate = startDate;
    }
    public Airplane(Airplane copy)
    {
        StartCity = copy.StartCity;
        FinishCity = copy.FinishCity;
        StartDate = copy.StartDate;
        FinishDate = copy.FinishDate;
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
    public Date SetGetStartDate
    {
        get { return StartDate; }
        set { StartDate = value; }
    }
    public Date SetGetFinishDate
    {
        get { return FinishDate; }
        set { FinishDate = value; }
    }
    public int GetTotalTime()
    {
        int startYear = StartDate.SetGetYear;
        int startMonth = StartDate.SetGetMonth;
        int startDay = StartDate.SetGetDay;
        int startHours = StartDate.SetGetHours;
        int startMinutes = StartDate.SetGetMinutes;

        int finishYear = FinishDate.SetGetYear;
        int finishMonth = FinishDate.SetGetMonth;
        int finishDay = FinishDate.SetGetDay;
        int finishHours = FinishDate.SetGetHours;
        int finishMinutes = FinishDate.SetGetMinutes;

        int startTotalMinutes = startYear * 365 * 24 * 60 + startMonth * 30 * 24 * 60 + startDay * 24 * 60 + startHours * 60 + startMinutes;
        int finishTotalMinutes = finishYear * 365 * 24 * 60 + finishMonth * 30 * 24 * 60 + finishDay * 24 * 60 + finishHours * 60 + finishMinutes;

        return finishTotalMinutes - startTotalMinutes;
    }
    public bool IsArriving()
    {
        return StartDate.SetGetDay == FinishDate.SetGetDay &&
               StartDate.SetGetMonth == FinishDate.SetGetMonth &&
               StartDate.SetGetYear == FinishDate.SetGetYear;
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

                for (int i = 0; i < airplanes.Length; i++)
                {
                    Console.WriteLine($"Деталі польоту:");
                    PrintAirplane(airplanes[i]);
                    Console.WriteLine($"Загальний час подорожі: {airplanes[i].GetTotalTime()} хвилин");
                    Console.WriteLine($"Прибуває: {airplanes[i].IsArriving()}");
                }
                break;
            case 2:
                AutoShow[] objects = AutoShow.Objects();
                AutoShow.SortCars(objects);
                Console.Title = "Лабораторна робота №5";
                Console.SetWindowSize(100, 25);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Введіть ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("число ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("масиву ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("структур ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("Сортування за зростанням цін: ");
                for (int i = 0; i < objects.Length; i++)
                {
                    Console.WriteLine($"Марка: {objects[i].GetCar}, Ціна: {objects[i].GetPrice}");
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
            Console.WriteLine($"Введіть деталі для літака: {i + 1}");
            Console.Write("Початкове місто: ");
            string startCity = Console.ReadLine();
            Console.Write("Кінцеве місто: ");
            string finishCity = Console.ReadLine();
            Console.Write("Початкова дата (рік місяць день години хвилини): ");
            string[] startDateInput = Console.ReadLine().Split(' ');
            Date startDate = new Date(int.Parse(startDateInput[0]), int.Parse(startDateInput[1]), int.Parse(startDateInput[2]), int.Parse(startDateInput[3]), int.Parse(startDateInput[4]));
            Console.Write("Кінцева дата (рік місяць день години хвилини): ");
            string[] finishDateInput = Console.ReadLine().Split(' ');
            Date finishDate = new Date(int.Parse(finishDateInput[0]), int.Parse(finishDateInput[1]), int.Parse(finishDateInput[2]), int.Parse(finishDateInput[3]), int.Parse(finishDateInput[4]));
            airplanes[i] = new Airplane(startCity, finishCity, startDate, finishDate);
            Console.WriteLine();
        }
        return airplanes;

       
}
    static void PrintAirplane(Airplane airplane)
    {
        Console.WriteLine($"Початкове місто: {airplane.SetGetStartCity}");
        Console.WriteLine($"Кінцеве місто: {airplane.SetGetFinishCity}");
        Console.WriteLine($"Початкова дата: {airplane.SetGetStartDate.SetGetYear}/{airplane.SetGetStartDate.SetGetMonth}/{airplane.SetGetStartDate.SetGetDay} {airplane.SetGetStartDate.SetGetHours}:{airplane.SetGetStartDate.SetGetMinutes}");
        Console.WriteLine($"Кінцева дата: {airplane.SetGetFinishDate.SetGetYear}/{airplane.SetGetFinishDate.SetGetMonth}/{airplane.SetGetFinishDate.SetGetDay} {airplane.SetGetFinishDate.SetGetHours}:{airplane.SetGetFinishDate.SetGetMinutes}");
    }
    static void PrintAirplanes(Airplane[] airplanes)
    {
        for (int i = 0; i < airplanes.Length; i++)
        {
            Console.WriteLine($"Деталі польоту для літака номер {i + 1}:");
            Console.WriteLine($"Початкове місто: {airplanes[i].SetGetStartCity}");
            Console.WriteLine($"Кінцеве місто: {airplanes[i].SetGetFinishCity}");
            if (airplanes[i].SetGetFinishDate.SetGetYear < airplanes[i].SetGetStartDate.SetGetYear)
            {
                Console.WriteLine("Початкова дата року не може бути більша за кінцеву");
            }
            Console.WriteLine($"Початкова дата: {airplanes[i].SetGetStartDate.SetGetYear}/{airplanes[i].SetGetStartDate.SetGetMonth}/{airplanes[i].SetGetStartDate.SetGetDay} {airplanes[i].SetGetStartDate.SetGetHours}:{airplanes[i].SetGetStartDate.SetGetMinutes}");
            Console.WriteLine($"Кінцева дата: {airplanes[i].SetGetFinishDate.SetGetYear}/{airplanes[i].SetGetFinishDate.SetGetMonth}/{airplanes[i].SetGetFinishDate.SetGetDay} {airplanes[i].SetGetFinishDate.SetGetHours}:{airplanes[i].SetGetFinishDate.SetGetMinutes}");
            Console.WriteLine();
        }
    }
    static void GetAirplaneInfo(Airplane[] airplanes, out int maxTravelTime, out int minTravelTime)
    {
        minTravelTime = airplanes[0].GetTotalTime();
        maxTravelTime = airplanes[0].GetTotalTime();


        for (int i = 1; i < airplanes.Length; i++)
        {
            int travelTime = airplanes[i].GetTotalTime();
            if (travelTime < minTravelTime)
            {
                minTravelTime = travelTime;
            }
            else if (travelTime > maxTravelTime)
            {
                maxTravelTime = travelTime;
            }
        }
    }
    static void SortAirplanesByDate(Airplane[] airplanes)
    {
        Array.Sort(airplanes, (x, y) =>
        {
            int yearCompare = y.SetGetStartDate.SetGetYear.CompareTo(x.SetGetStartDate.SetGetYear);
            if (yearCompare != 0)
                return yearCompare;
            int monthCompare = y.SetGetStartDate.SetGetMonth.CompareTo(x.SetGetStartDate.SetGetMonth);
            if (monthCompare != 0)
                return monthCompare;
            int dayCompare = y.SetGetStartDate.SetGetDay.CompareTo(x.SetGetStartDate.SetGetDay);
            return dayCompare;
        });
    }
    static void SortAirplanesByTotalTime(Airplane[] airplanes)
    {
        Array.Sort(airplanes, (x, y) =>
        {
            int totalTime1 = x.GetTotalTime();
            int totalTime2 = y.GetTotalTime();
            return totalTime1.CompareTo(totalTime2);
        });
    }
}

class AutoShow
{
    protected string Car;
    protected int Price;

  
public AutoShow(string car, int price)
    {
        Car = car;
        Price = price;
    }
    public string GetCar
    {
        get { return Car; }
    }
    public int GetPrice
    {
        get { return Price; }
    }
    public static AutoShow[] Objects()
    {
        Console.WriteLine("Введіть кількість автосалонів: ");
        int number = int.Parse(Console.ReadLine());
        AutoShow[] objects = new AutoShow[number];
        for (int i = 0; i < number; i++)
        {
            Console.WriteLine($"Введіть інформацію для автосалону номер {i + 1}");
            Console.WriteLine("Марка автомобіля: ");
            string car = Console.ReadLine();
            Console.WriteLine("Ціна автомобіля: (в доларах) ");
            int price = int.Parse(Console.ReadLine());

            objects[i] = new AutoShow(car, price);
        }
        return objects;

    }
    public static void SortCars(AutoShow[] cars)
    {
        Array.Sort(cars, (x, y) => x.Price.CompareTo(y.Price));
    }
}