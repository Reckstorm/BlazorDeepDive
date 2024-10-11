using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ServerManagement.Models;

namespace ServerManagement.Stores
{
    public class SessionStorage
    {
        private readonly ProtectedSessionStorage _sessionStorage;

        public SessionStorage(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task<Server> GetServer()
        {
            var storageValue = await _sessionStorage.GetAsync<Server>("server");
            if (storageValue.Value != null) return storageValue.Value;
            return null;
        }

        public async void SetServer(Server server)
        {
            if(server != null) 
                await _sessionStorage.SetAsync("server", server);
            return;
        }
    }
}
