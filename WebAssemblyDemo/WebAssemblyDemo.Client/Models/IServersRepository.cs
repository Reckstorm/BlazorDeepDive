
namespace WebAssemblyDemo.Client.Models
{
    public interface IServersRepository
    {
        Task AddServerAsync(Server server);
        Task DeleteServerAsync(int serverId);
        Task<Server> GetServerByIdAsync(int serverId);
        Task<List<Server>> GetServers();
        Task UpdateServerAsync(int serverId, Server server);
    }
}