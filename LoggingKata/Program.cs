using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToList();

            // Find the two Taco Bells in Alabama that are the furthest from one another.
            
            ITrackable tbell1 = locations[0];
            ITrackable tbell2 = locations[0];
            double distance = 0;
            logger.LogInfo("Searching locations...");

            for (int i = 0; i < locations.Count(); i++)
            {
                var locA = locations[i].Location;
                var coordA = new GeoCoordinate(locA.Latitude, locA.Longitude);
                
                for (int j = 0; j < locations.Count(); j++)
                {
                    var locB = locations[j].Location;
                    var coordB = new GeoCoordinate(locB.Latitude, locB.Longitude);

                    var dist = coordA.GetDistanceTo(coordB);
                    if (dist > distance)
                    {
                        distance = dist;
                        tbell1 = locations[i];
                        tbell2 = locations[j];
                    }
                }
            }

            Console.WriteLine("\nLOCATION 1");
            Console.WriteLine("  Name: " + tbell1.Name);
            Console.WriteLine("  Point: " + tbell1.Location.ToString());
            Console.WriteLine("\nLOCATION 2");
            Console.WriteLine("  Name: " + tbell2.Name);
            Console.WriteLine("  Point: " + tbell2.Location.ToString());
            Console.WriteLine("\nDISTANCE: {0:n2} meters", distance);
            
            Console.ReadKey();
        }
    }
}