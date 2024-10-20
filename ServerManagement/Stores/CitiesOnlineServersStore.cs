using ServerManagement.Models;

namespace ServerManagement.Stores
{
    public class CitiesOnlineServersStore
    {
        private readonly IServersEFCoreRepository _serversEFCoreRepository;

        public List<CityStore> Cities { get; set; }

        public CitiesOnlineServersStore(IServersEFCoreRepository ServersEFCoreRepository)
        {
            Cities = new List<CityStore>();
            var cities = CitiesRepository.GetCities();
            _serversEFCoreRepository = ServersEFCoreRepository;

            foreach (var city in cities)
            {
                CityStore store = new CityStore { City = city };
                var servers = _serversEFCoreRepository.GetServersByCity(city).Count(x => x.IsRunning);
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
