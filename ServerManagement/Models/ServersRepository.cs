namespace ServerManagement.Models
{
    public static class ServersRepository
    {
        private static List<Server> Servers = new List<Server>()
        {
            new Server { Id = 1, Name = "Server1", City = "Calgary"},
            new Server { Id = 2, Name = "Server2", City = "Halifax"},
            new Server { Id = 3, Name = "Server3", City = "Toronto"},
            new Server { Id = 4, Name = "Server4", City = "Ottawa"},
            new Server { Id = 5, Name = "Server5", City = "Montreal"},
            new Server { Id = 6, Name = "Server6", City = "Calgary"},
            new Server { Id = 7, Name = "Server7", City = "Calgary"},
            new Server { Id = 8, Name = "Server8", City = "Halifax"},
            new Server { Id = 9, Name = "Server9", City = "Halifax"},
            new Server { Id = 10, Name = "Server10", City = "Toronto"},
            new Server { Id = 11, Name = "Server11", City = "Toronto"},
            new Server { Id = 12, Name = "Server12", City = "Ottawa"},
            new Server { Id = 13, Name = "Server13", City = "Ottawa"},
            new Server { Id = 14, Name = "Server14", City = "Montreal"},
            new Server { Id = 15, Name = "Server15", City = "Montreal"},
        };

        public static void AddServer(Server server)
        {
            var maxId = Servers.Max(x => x.Id);
            server.Id = maxId;
            Servers.Add(server);
        }

        public static List<Server> GetServers() => Servers;

        public static List<Server> GetServersByCity(string city) => Servers.Where(server => server.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();

        public static Server GetServerById(int id)
        {
            var server = Servers.FirstOrDefault(x => x.Id == id);
            if (server != null)
            {
                return new Server
                {
                    Id = server.Id,
                    City = server.City,
                    Name = server.Name,
                    IsRunning = server.IsRunning
                };
            }
            return null;
        }

        public static void UpdateServer (int serverId, Server server)
        {
            if (serverId != server.Id) return;
            
            var serverToUpdate = Servers.FirstOrDefault(x => x.Id.Equals(serverId));
            if (serverToUpdate != null)
            {
                serverToUpdate.City = server.City;
                serverToUpdate.Name = server.Name;
                serverToUpdate.IsRunning = server.IsRunning;
            }
        }

        public static void DeleteServer(int serverId)
        {
            var server = Servers.FirstOrDefault(x => x.Id == serverId);
            if (server != null)
            {
                Servers.Remove(server);
            }
        }

        public static List<Server> SearchServers(string serverFilter) => Servers.Where(s => s.Name.Equals(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
