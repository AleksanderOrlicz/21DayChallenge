namespace _21DayChallenge
{
    public class DriverInMemory : DriverBase
    {
        private List<TimeSpan> lapTimes = new List<TimeSpan>();

        public override event LapTimeAddedDelegate LapTimeAdded;
        public DriverInMemory(string name, string surname) 
            : base(name, surname)
        {
        }

        

        public override void AddLapTime(string time)
        {
            string timeFormat = @"mm\:ss\.fff";
            time = FormattingTS.timeFormatting(time);
            
            if(TimeSpan.TryParseExact(time, timeFormat, null, out var lapTimeInTimeSpan))
            {                
                this.lapTimes.Add(lapTimeInTimeSpan);
                if(LapTimeAdded != null)
                {
                    LapTimeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Wrong time format");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach(var lapTime in this.lapTimes)
            {
                statistics.AddLapTime(lapTime);
            }
            if (this.lapTimes.Count == 0)
            {
                throw new Exception("Nie ma żadnego czasu");
            }
            return statistics;
        }



        
    }
}
