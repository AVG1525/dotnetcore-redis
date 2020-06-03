using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RedisCache.Interface;
using RedisCache.Service;
using StackExchange.Redis;

namespace RedisCache
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Serviço de cache sendo ativado por meioda chamada AddDistributedRedisCache 
            //services.AddDistributedRedisCache(options =>
            //{
            //    options.Configuration = Configuration["ConexaoRedis"];
            //    options.InstanceName = "master";
            //});

            services.AddSingleton<IConnectionMultiplexer>(x =>
                ConnectionMultiplexer.Connect(Configuration.GetValue<string>("ConexaoRedis")));
            services.AddSingleton<ICacheService, CacheService>();

            //var ConnRedis = ConnectionMultiplexer.Connect(Configuration.GetConnectionString("ConexaoRedis"));


            // Dependency Injection
            services.AddTransient<ICacheService, CacheService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
