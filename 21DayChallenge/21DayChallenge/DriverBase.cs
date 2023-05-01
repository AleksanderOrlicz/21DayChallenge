namespace _21DayChallenge
{
    public abstract class DriverBase : IDriver
    {
        public DriverBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }

        public abstract void AddLapTime(string time);
        public abstract Statistics GetStatistics();        
    }
}
