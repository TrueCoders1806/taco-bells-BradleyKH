namespace LoggingKata
{
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public override string ToString()
        {
            return "Longtitude: " + Longitude +
                ", Latitude: " + Latitude;
        }
    }
}