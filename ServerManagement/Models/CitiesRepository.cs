namespace ServerManagement.Models
{
    public static class CitiesRepository
    {
        private static readonly List<string> Cities = new List<string>
        {
            "Ottawa",
            "Calgary",
            "Halifax",
            "Toronto",
            "Montreal"
        };

        public static List<string> GetCities() => Cities;
    }
}
