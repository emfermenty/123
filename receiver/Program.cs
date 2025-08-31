using System.Configuration;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Receiver_server.Database;
using Receiver_server.Receiver;

namespace Receiver_server
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<DataBaseHandler>();
            services.AddScoped<GpsEndPoint>();

            var provider = services.BuildServiceProvider();
            using var scope =  provider.CreateScope();
            var endpoint = scope.ServiceProvider.GetRequiredService<GpsEndPoint>();
            await endpoint.OpenEndPoint();
        }
    }
}
