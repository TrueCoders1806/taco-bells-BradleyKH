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

            // Use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If the array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogWarning("The array is too short!");
                return null;
            }

            // If the array.Length is greater than 3, something went wrong
            if (cells.Length > 3)
            {
                logger.LogWarning("The array is too long!");
                return null;
            }


            // If the first two elements in the array are not decimals...            
            var location = new Point();
            try
            {
                location.Latitude = Convert.ToDouble(cells[0]);
            } catch (Exception e)
            {
                logger.LogWarning("Latitude is not formatted correctly.");
                return null;
            }

            try
            {
                location.Longitude = Convert.ToDouble(cells[1]);
            } catch (Exception e)
            {
                logger.LogWarning("Longtitude is not formatted correctly.");
                return null;
            }

            if (Math.Abs(location.Latitude) > 90)
            {
                logger.LogWarning("Latitude must be between -90 and 90.");
                return null;
            }

            if (Math.Abs(location.Longitude) > 180)
            {
                logger.LogWarning("Latitude must be between -180 and 180.");
                return null;
            }

            var name = cells[2];

            var tBell = new TacoBell(name, location);
            
            return tBell;
        }
    }
}