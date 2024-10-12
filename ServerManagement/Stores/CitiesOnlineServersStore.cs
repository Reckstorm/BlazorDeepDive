using ServerManagement.Models;

namespace ServerManagement.Stores
{
    public class CitiesOnlineServersStore
    {
        public List<CityStore> Cities { get; set; }

        public CitiesOnlineServersStore()
        {
            Cities = new List<CityStore>();
            var cities = CitiesRepository.GetCities();

            foreach (var city in cities)
            {
                CityStore store = new CityStore { City = city };
                var servers = ServersRepository.GetServersByCity(city).Count(x => x.IsRunning);
                if (servers != null)
                    store.ServersOnline = servers;
                Cities.Add(store);
            }
        }

        public void UpdateOnlineServersCount(string cityName, bool status)
        {
            var city = Cities.Find(c => c.City.Equals(cityName, StringComparison.OrdinalIgnoreCase));
            if (status) city.ServersOnline++;
            else city.ServersOnline--;
        }
    }
}
