using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    class TacoBell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }

        public TacoBell(string n, Point l)
        {
            Name = n;
            Location = l;
        }
    }
}
