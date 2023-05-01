namespace _21DayChallenge.Tests
{
    public class Tests
    {        
        [Test]
        public void twoDriversHaveTheSameNameAndSurnameButTheyAreNotTheSameDrivers()
        {
            var driver1 = new DriverInMemory("Aleksander", "Orlicz");
            var driver2 = new DriverInMemory("Aleksander", "Orlicz");

            Assert.AreNotEqual(driver1, driver2);
        }
    }
}