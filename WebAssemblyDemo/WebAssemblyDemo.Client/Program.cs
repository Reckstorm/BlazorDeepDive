using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAssemblyDemo.Client.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient("ServerApi", client =>
{
    client.BaseAddress = new Uri("https://webassebmlydemo-default-rtdb.europe-west1.firebasedatabase.app/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddTransient<IServersRepository, ServersAPIRepository>();

await builder.Build().RunAsync();
