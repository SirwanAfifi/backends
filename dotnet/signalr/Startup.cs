using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using signalr.hubs;

namespace signalr
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            services.AddCors();
            
            services.AddSingleton<IConfiguration>(Configuration);


            services.AddControllers();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.
                        GetBytes(Configuration["JWT:ServerSecret"]));
                    options.TokenValidationParameters = new
                        TokenValidationParameters
                        {
                            IssuerSigningKey = serverSecret,
                            ValidIssuer = Configuration["JWT:Issuer"],
                            ValidAudience = Configuration["JWT:Audience"]
                        };
                });
            IdentityModelEventSource.ShowPII = true;


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=default}/{action=Index}/{id?}");
            });
        }
    }
}
