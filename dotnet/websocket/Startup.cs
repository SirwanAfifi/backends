using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace websocket
{
    public class Startup
    {
        private string[] modelNames = {
            "DecisionTree",
            "AdaBoost",
            "GradientBoosting",
            "NearestNeighbor",
            "SVMLinear",
            "SVMRBF",
            "GaussianProcess",
            "RandomForest",
            "MLP",
            "Bayesian",
            "QuadraticDiscriminationAnalysis",
            "RadiusNeighbors"
        };

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var webSocketOptions = new WebSocketOptions()  
            {  
                KeepAliveInterval = TimeSpan.FromSeconds(120),  
                ReceiveBufferSize = 4 * 1024  
            };  
  
            app.UseWebSockets(webSocketOptions);  

            app.Use(async (context, next) =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    await Task.Run(async () => {
                        for(;;)
                        {
                            await Task.Delay(1000);
                            var model = modelNames.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                            var rnd = new Random();
                            var usage = rnd.Next(50);
                            var ram = rnd.Next(500);
                            var data = new {
                                title = model,
                                usage,
                                ram
                            };
                            await SendMessageAsync(webSocket, JsonSerializer.Serialize(data));
                        }
                    });
                }
                else
                {
                    context.Response.StatusCode = 400;
                }
            });
        }
        
        private async Task SendMessageAsync(WebSocket socket, string message)
        {
            if(socket.State != WebSocketState.Open)
                return;

            await socket.SendAsync(buffer: new ArraySegment<byte>(array: Encoding.ASCII.GetBytes(message),
                    offset: 0,
                    count: message.Length),
                messageType: WebSocketMessageType.Text,
                endOfMessage: true,
                cancellationToken: CancellationToken.None);
        } 
        
    }
}
