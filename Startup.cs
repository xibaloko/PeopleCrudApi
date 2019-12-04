using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudPessoas.Model.Context;
using CrudPessoas.Business;
using CrudPessoas.Business.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CrudPessoas
{
    public class Startup
    {
        /*public readonly ILogger _logger;*/
        public IConfiguration _configuration { get; }
        public IWebHostEnvironment _environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment/*, ILogger<Startup> logger*/)
        {
            _configuration = configuration;
            _environment = environment;
            /*_logger = logger;*/
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));
            services.AddControllers();

            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    var evolve = new Evolve.Evolve(evolveConnection/*, msg => _logger.LogInformation(msg)*/)
                    {
                        
                        Locations = new List<string> { "Database/migrations" },
                        IsEraseDisabled = true,
                    };
                    evolve.Migrate();
                }
                catch (Exception e)
                {
                    /*_logger.LogCritical("Database exception failed", e);*/
                    throw e;
                }
            }

            services.AddApiVersioning();

            // Dependency injection
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

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
