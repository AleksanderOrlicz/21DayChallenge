
using _21DayChallenge;
using System.Runtime.CompilerServices;

Console.ForegroundColor = ConsoleColor.White;
//string lapTime = "1:43.834";
//string lapTime2 = "1:3.8";
//string lapTime3 = "aaa1:44";

//string czas = "1:43.2";
//string timeFormat = @"mm\:ss\.fff";
//timeFormatting(czas);
//Console.WriteLine(czas);

bool CloseApp = false;


Console.WriteLine("======================================================");
Console.WriteLine("Witaj w aplikacji sprawdzającej Twoje czasy okrążenia");

while (!CloseApp)
{
    Console.WriteLine("Wybierz sposób działania: ");
    Console.WriteLine("m - aby wykonać wszystkie obliczenia w pamięci");
    Console.WriteLine("f - aby zapisać okrążenia do pliku Laps.txt");
    Console.WriteLine("q - aby wyjśc z aplikacji");
    var method = Console.ReadLine();

    switch(method.ToUpper())
    {
        case "M":
            AddLapsToMemory();
            CloseApp = true;
            break;
        case "F":
            AddLapsToFile();
            break;
        case "Q":
            CloseApp = true;
            break;
        default:
            Console.WriteLine("Wrong character try one more time!");
            continue;
    }
}

static void AddLapsToFile()
{
    Console.Write("Podaj imię: ");
    string name = Console.ReadLine();
    Console.Write("Podaj nazwisko: ");
    string surname = Console.ReadLine();

    if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var driverInFile = new DriverInFile(name, surname);

        EnterLapTime(driverInFile);
    }
    else
    {
        Console.WriteLine("Driver's name or surename cannot be empty!");
    }


    
}

static void AddLapsToMemory()
{
    Console.Write("Podaj imię: ");
    string name = Console.ReadLine();
    Console.Write("Podaj nazwisko: ");
    string surname = Console.ReadLine();

    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
    {
        var driverInMemory = new DriverInMemory(name, surname);

        EnterLapTime(driverInMemory);
    }
    else
    {
        Console.WriteLine("Driver's name or surename cannot be empty!");
    }
}

static void EnterLapTime(IDriver driver)
{
    while (true)
    {
        Console.WriteLine("Podaj czas okrążenia: ");
        var input = Console.ReadLine();
        if (input.ToUpper() == "Q")
        {
            break;
        }
        try
        {
            driver.AddLapTime(input);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        finally
        {
            Console.WriteLine("To leave and show statistics press 'q'");
        }
    }

    try
    {
        StatisticsToConsole(driver);
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception.Message);
    }


}








static void StatisticsToConsole(IDriver driver)
{
    var statistics = driver.GetStatistics();
    Console.WriteLine("======================================================");
    Console.WriteLine($"Driver: {driver.Surname} {driver.Name}");
    Console.WriteLine($"Average: {FormattingTimeSpan(statistics.Average)}");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"Fastest: {FormattingTimeSpan(statistics.Fastest)}");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Slowest: {FormattingTimeSpan(statistics.Slowest)}");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"Overall time: {FormattingTimeSpan(statistics.OverallTime)}");
    Console.WriteLine($"Laps done: {statistics.LapCounter}");    
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
}

static string FormattingTimeSpan(TimeSpan time)
{
    return FormattingTS.timeSpanFormattedToString( time );
}