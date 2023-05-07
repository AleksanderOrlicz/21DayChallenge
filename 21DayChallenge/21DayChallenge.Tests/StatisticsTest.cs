

namespace _21DayChallenge.Tests
{
    
    internal class StatisticsTest
    {
        [Test]
        public void DriverGetsTwoTimes_GivesCorrectStatistics()
        {
            var driver = new DriverInMemory("Aleksander", "Orlicz");

            driver.AddLapTime("1:44.5");
            driver.AddLapTime("1:43.5");
            
            var result = driver.GetStatistics();

            Assert.AreEqual("01:44.500", result.Slowest.ToString(@"mm\:ss\.fff"));
            Assert.AreEqual("01:43.500", result.Fastest.ToString(@"mm\:ss\.fff"));
            Assert.AreEqual("01:44.000", result.Average.ToString(@"mm\:ss\.fff"));
            Assert.AreEqual(2, result.LapCounter);
            Assert.AreEqual("03:28.000", result.OverallTime.ToString(@"mm\:ss\.fff"));
        }
    }
}
