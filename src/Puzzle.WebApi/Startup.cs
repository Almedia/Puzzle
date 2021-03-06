using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Amazon.S3;
using Puzzle.Core.Interface;
using Puzzle.Infrastructure.Services;
using Puzzle.Infrastructure.Data.Repository;
using Puzzle.ApplicationServices;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Serilog;
using AutoMapper;
using Puzzle.Infrastructure.Mapping;
using Puzzle.Infrastructure.Data.Context;
using Puzzle.Infrastructure.Data.Repository;

namespace Puzzle.WebApi
{
    public class Startup
    {
        private MapperConfiguration mapperConfiguration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

       

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.LiterateConsole()
                // .WriteTo.RollingFile(@"c:\Logs\Puzzle\Log.txt log-{Date}.txt")
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

            services.AddMvc();
            services.AddSwaggerGen();
            services.AddTransient<IPhotoRepository,PhotoRepository>();
            services.AddDbContext<PhotoContext>(options =>
            {
                options.UseMySQL(sqlConnectionString);
            });

            services.AddDbContext<UserContext>(options =>
            {
                options.UseMySQL(sqlConnectionString);
            });

            var awsOptions=Configuration.GetAWSOptions();

            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());

            services.AddAWSService<IAmazonS3>();

            services.AddTransient<IPhotoService, PhotoService>();
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<IPhotoRepository,PhotoRepository>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddAutoMapper();

            mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            services.AddSingleton<IMapper>(sp => mapperConfiguration.CreateMapper());

            //  MapperConfiguration configuration = new MapperConfiguration(cfg =>
            //     {
            //     cfg.AddProfile<MappingProfile.Profile1>();
            //     cfg.AddProfile<MappingProfile.Profile2>();
            //     });
                
            // services.AddInstance(typeof (IMapper), configuration.CreateMapper());
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
