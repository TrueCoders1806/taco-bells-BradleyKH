using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            if (line == null || line == "") return null;

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogWarning("The array is too long!");
                return null;
            }
            
            var location = new Point();
            location.Latitude = Convert.ToDouble(cells[0]);
            location.Longitude = Convert.ToDouble(cells[1]);
            var name = cells[2];

            var tBell = new TacoBell(name, location);
            logger.LogInfo("New instance of TacoBell made.");

            return tBell;
        }
    }
}