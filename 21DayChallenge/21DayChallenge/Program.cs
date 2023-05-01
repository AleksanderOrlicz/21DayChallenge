
using _21DayChallenge;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;

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

            switch (method.ToUpper())
            {
                case "M":
                    AddLapsToMemory();
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
            CloseApp = true;
        }

        

        static void AddLapsToFile()
        {
            Console.Write("Podaj imię: ");
            string name = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            string surname = Console.ReadLine();

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                var driverInFile = new DriverInFile(name, surname);
                driverInFile.LapTimeAdded += DriverLapTimeAdded;
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
                driverInMemory.LapTimeAdded += DriverLapTimeAdded;
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
                Console.WriteLine("Podaj czas okrążenia: [MM:SS.fff]");
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
            return FormattingTS.timeSpanFormattedToString(time);
        }
    }

    private static void DriverLapTimeAdded(object sender, EventArgs args)
    {
        Console.WriteLine("Dodano kolejny czas okrążenia!");
    }
}