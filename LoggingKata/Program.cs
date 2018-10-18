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

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var thing = parser.Parse(lines[0]);

            Console.WriteLine("Name: " + thing.Name);
            Console.WriteLine("Location: {0}, {1}", thing.Location.Latitude, thing.Location.Longitude);

            var locations = lines.Select(parser.Parse).ToList();

            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops

            ITrackable tbell1 = null;
            ITrackable tbell2 = null;
            double distance = 0;

            for (int i = 0; i < locations.Count(); i++)
            {
                var locA = locations[i].Location;
                var coordA = new GeoCoordinate(locA.Latitude, locA.Longitude);

                for (int j = 0; j < locations.Count(); j++)
                {
                    var locB = locations[i].Location;
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

            Console.WriteLine("Location 1: " + tbell1.Name);
            Console.WriteLine("Location 2: " + tbell2.Name);
            Console.WriteLine("Distance: " + distance);

            Console.ReadKey();
        }
    }
}