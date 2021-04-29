using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using RestAPI.Models;

namespace RestAPI
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

            services.AddCors();
                    
            // var databaseConnection = "databaseConnectionString";
            
            // string value = ConfigurationManager.ConnectionStrings[databaseConnection].ConnectionString;

            services.AddDbContext<RestAPIContext>(options =>
                options.UseMySql(

                    // Kaelen Connection
                    // "server=localhost;database=myapp_development;uid=root;password=Pa$$w0rd!",

                    // Cristiane Connection
                    // "server=localhost;port=3306;database=myapp_development;uid=codeboxx;password=Codeboxx1*",
                    // Live Site Connection
                    "server=codeboxx.cq6zrczewpu2.us-east-1.rds.amazonaws.com;user=codeboxx;password=Codeboxx1!;port=3306;database=myapp_development;sslmode=none;",

                    new MySqlServerVersion(new Version(8, 0, 21)),
                        mySqlOptions => mySqlOptions
                            .CharSetBehavior(CharSetBehavior.NeverAppend))
                    // Everything from this point on is optional but helps with debugging.
                    // .EnableSensitiveDataLogging()
                    // .EnableDetailedErrors();
                    );

            services.AddMvc();

            // "server=localhost;database=myapp_development;uid=root;password=Pa$$w0rd!",

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestAPI v1"));
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
