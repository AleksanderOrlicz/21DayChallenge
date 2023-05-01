

namespace _21DayChallenge
{
    public static class FormattingTS
    {
        //formatowanie czasu do oczekiwanego formatu mm:ss.fff
        public static string timeFormatting(string time)
        {
            string[] parts, parts2;
            string min = "0";
            string sec = "0";
            string thousands = "0";
            string finalTime = null;

            if (time.Length != 0)
            {
                if (time.Contains(":"))
                {
                    parts = time.Split(':');
                    min = parts[0];
                    sec = parts[1];
                }
                if (time.Contains(".") && sec != "0")
                {
                    parts2 = sec.Split(".");
                    sec = parts2[0];
                    thousands = parts2[1];
                }
                else if (time.Contains(".") && sec == "0")
                {
                    parts2 = time.Split(".");
                    sec = parts2[0];
                    thousands = parts2[1];
                }
                finalTime = min.PadLeft(2, '0') + ":" + sec.PadLeft(2, '0') + "." + thousands.PadRight(3, '0');
            }                           
                       
            return finalTime;
        }

        //formatowanie obiektu timeSpan do string w oczekiwanym formacie
        public static string timeSpanFormattedToString(TimeSpan timeSpan)
        {
            string timeFormat = "mm\\:ss\\.fff";
            return timeSpan.ToString(timeFormat);

        }
    }
}
