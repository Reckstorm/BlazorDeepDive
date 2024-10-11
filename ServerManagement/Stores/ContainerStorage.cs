using ServerManagement.Models;

namespace ServerManagement.Stores
{
    public class ContainerStorage
    {
        private Server _server = new();

        public void SetServer(Server server) => _server = server;
        public Server GetServer() => _server;
    }
}
