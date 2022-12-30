using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MQTTnet.AspNetCore;

var builder = new HostBuilder();

builder.UseOrleans(silo =>
{
    silo.UseLocalhostClustering();
});

builder.Services
    .AddMqttServer(options =>
    {
        options.WithDefaultEndpoint();
    })
    .AddMqttServerOrleansClustering();

var host = builder.Build();

await host.RunAsync();