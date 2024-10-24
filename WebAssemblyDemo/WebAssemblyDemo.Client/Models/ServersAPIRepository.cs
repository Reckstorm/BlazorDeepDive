using System.Text;
using System.Text.Json;

namespace WebAssemblyDemo.Client.Models
{
    public class ServersAPIRepository : IServersRepository
    {
        private string _serverApi { get; set; } = "ServerApi";
        private readonly IHttpClientFactory _httpClientFactory;

        public ServersAPIRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Server>> GetServers()
        {
            var client = _httpClientFactory.CreateClient(_serverApi);

            var result = await client.GetAsync("servers.json");

            result.EnsureSuccessStatusCode();

            var content = await result.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content) && content == "null") return new List<Server>();

            return JsonSerializer.Deserialize<List<Server>>(content) ?? new List<Server>();
        }

        public async Task<Server> GetServerByIdAsync(int serverId)
        {
            var client = _httpClientFactory.CreateClient(_serverApi);

            var result = await client.GetAsync($"servers/{serverId}.json");

            result.EnsureSuccessStatusCode();

            var content = await result.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(content) && content == "null") return new Server();

            return JsonSerializer.Deserialize<Server>(content) ?? new Server();
        }

        public async Task AddServerAsync(Server server)
        {
            server.ServerId = await GenerateServerId();
            var client = _httpClientFactory.CreateClient(_serverApi);
            var content = new StringContent(JsonSerializer.Serialize(server), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"servers/{server.ServerId}.json", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateServerAsync(int serverId, Server server)
        {
            if (serverId != server.ServerId) return;
            var client = _httpClientFactory.CreateClient(_serverApi);
            var content = new StringContent(JsonSerializer.Serialize(server), Encoding.UTF8, "application/json");

            var response = await client.PatchAsync($"servers/{server.ServerId}.json", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteServerAsync(int serverId)
        {
            var client = _httpClientFactory.CreateClient(_serverApi);
            var response = await client.DeleteAsync($"servers/{serverId}.json");
            response.EnsureSuccessStatusCode();
        }

        private async Task<int> GenerateServerId()
        {
            var servers = await GetServers();
            if (servers == null || servers.Count == 0) return 1;
            return servers.Where(x => x != null).Max(x => x.ServerId) + 1;
        }
    }
}
