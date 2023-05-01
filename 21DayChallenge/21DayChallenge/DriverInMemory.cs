namespace _21DayChallenge
{
    public class DriverInMemory : DriverBase
    {
        public List<TimeSpan> lapTimes = new List<TimeSpan>(); //zmienić na private
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
