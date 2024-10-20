using Microsoft.EntityFrameworkCore;
using ServerManagement.Components.Pages;
using ServerManagement.Persistence;

namespace ServerManagement.Models
{
    public class ServersEFCoreRepository : IServersEFCoreRepository
    {
        private readonly IDbContextFactory<ServerManagementContext> _dbContextFactory;

        public ServersEFCoreRepository(IDbContextFactory<ServerManagementContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddServer(Server server)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.Servers.Add(server);
            context.SaveChanges();
        }

        public List<Server> GetServers()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.Servers.ToList();
        }

        public List<Server> GetServersByCity(string city)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.Servers.Where(s => s.City != null && s.City.ToLower().IndexOf(city.ToLower()) >= 0).ToList();
        }

        public Server GetServerById(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var server = context.Servers.Find(id);
            if (server != null) return server;
            return new Server();
        }

        public void UpdateServer(int serverId, Server server)
        {
            if (serverId != server.Id) return;
            if (server == null) return;
            using var context = _dbContextFactory.CreateDbContext();
            var serverToUpdate = context.Servers.Find(serverId);
            if (serverToUpdate == null) return;

            serverToUpdate.City = server.City;
            serverToUpdate.Name = server.Name;
            serverToUpdate.IsRunning = server.IsRunning;
            context.SaveChanges();
        }

        public void DeleteServer(int serverId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var server = context.Servers.Find(serverId);
            if (server == null) return;
            context.Servers.Remove(server);
            context.SaveChanges();
        }

        public List<Server> SearchServers(string serverFilter)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.Servers.Where(s => s.Name != null && s.Name.ToLower().IndexOf(serverFilter.ToLower()) >= 0).ToList();
        }
    }
}
