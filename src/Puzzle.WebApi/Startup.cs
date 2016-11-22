using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Puzzle.Core;
using Puzzle.Core.Interface;
using Puzzle.Infrastructure.Context;
using Puzzle.Infrastructure.Services;
using Puzzle.Infrastructure.Repository;
using Puzzle.ApplicationServices;
using MySQL.Data.EntityFrameworkCore.Extensions; 
using Serilog;
using RabbitMQ; 
namespace Puzzle.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            
            //     Hostname = _config["RABBITMQ_HOST"],
            //     Username = _config["RABBITMQ_USER"],
            //     Password = _config["RABBITMQ_PASSWORD"],
            //     Exchange = _config["RABBITMQ_EXCHANGE"],
            //     ExchangeType = _config["RABBITMQ_EXCHANGE_TYPE"],
            //     DeliveryMode = RabbitMQDeliveryMode.Durable,
            //     RouteKey = "Logs",
            //     Port = 5672
            // };

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.LiterateConsole()
                // .WriteTo.RabbitMQ(rabbitMQConfig, new JsonFormatter())
                .CreateLogger();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration.GetConnectionString("DataAccessMySqlProvider");

             var config = new ConfigurationBuilder()
            .AddUserSecrets("aspnet-WebApp1-c23d27a4-eb88-4b18-9b77-2a93f3b15119")
            .Build();

            var accessKey = config["aws-access-key"];
            var secretKey = config["aws-secret-key"];

            //  var credentials = new BasicAWSCredentials(
            //     accessKey: accessKey,
            //     secretKey: secretKey);
            
            // Add framework services.
            services.AddMvc();
            services.AddSwaggerGen();
            services.AddTransient<IPhotoRepository,PhotoRepository>();
            services.AddDbContext<PhotoContext>(options =>
            {
                options.UseMySQL(sqlConnectionString);
            });

            var awsOptions=Configuration.GetAWSOptions();

            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());

            services.AddAWSService<IAmazonS3>();

            services.AddTransient<IPhotoService, PhotoService>();
            services.AddTransient<IPhotoRepository,PhotoRepository>();
          
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddSerilog();

            app.UseSwagger();

            app.UseSwaggerUi();

            app.UseMvc();
        }
    }
}
