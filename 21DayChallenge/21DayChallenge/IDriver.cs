using static _21DayChallenge.DriverBase;

namespace _21DayChallenge
{
    public interface IDriver
    {
        string Name { get; }
        string Surname { get; }

        void AddLapTime(string time);

        event LapTimeAddedDelegate LapTimeAdded;

        Statistics GetStatistics();
    }
}
