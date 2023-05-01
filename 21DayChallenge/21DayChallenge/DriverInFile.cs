

namespace _21DayChallenge
{
    internal class DriverInFile : DriverBase
    {
        private const string fileName = "Laps.txt";

        public override event LapTimeAddedDelegate LapTimeAdded;
        public DriverInFile(string name, string surname) 
            : base(name, surname)
        {
        }

        public override void AddLapTime(string time)
        {
            string timeFormat = @"mm\:ss\.fff";
            time = FormattingTS.timeFormatting(time);

            if(TimeSpan.TryParseExact(time, timeFormat, null,out var lapTimeInTimeSpan))
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(lapTimeInTimeSpan);
                    if (LapTimeAdded != null)
                    {
                        LapTimeAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new Exception("Invalid timw format!");
            }
        }

        public override Statistics GetStatistics()
        {
            var lapsFromFile = this.StatisticsFromFile();
            var statistics = new Statistics();

            foreach (var lapTime in lapsFromFile)
            {
                statistics.AddLapTime(lapTime);
            }

            return statistics;            
        }

        private List<TimeSpan> StatisticsFromFile()
        {
            var lapsFromFile = new List<TimeSpan>();

            using (var reader = File.OpenText(fileName))
            {
                var line = reader.ReadLine();
                if (File.Exists(fileName))
                {
                    while (line != null)
                    {
                        var lapTime = TimeSpan.Parse(line);
                        lapsFromFile.Add(lapTime);
                        line = reader.ReadLine();
                    }
                }
            }
            return lapsFromFile;
        }
        
    }
}
