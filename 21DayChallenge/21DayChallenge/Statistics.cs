namespace _21DayChallenge
{
    public class Statistics
    {
        private List<TimeSpan> lapTimes = new List<TimeSpan>();
        public TimeSpan Fastest
        {
            get
            {
                return this.lapTimes.Min();
            }
            
        }
        public TimeSpan Slowest 
        {
            get
            {
                return this.lapTimes.Max();
            }
        }

        public TimeSpan OverallTime { get; private set; }

        public int LapCounter { get; private set; }

        public TimeSpan Average
        {
            get
            {
                return this.OverallTime.Divide(this.LapCounter);
            }
        }
               
        public Statistics()
        {
            this.OverallTime = TimeSpan.Zero;
        }
        public void AddLapTime(TimeSpan lapTime)
        {
            this.lapTimes.Add(lapTime);
            this.LapCounter++;
            this.OverallTime += lapTime;            
        }
        
    }
}
