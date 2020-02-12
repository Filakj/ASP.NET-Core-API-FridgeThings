using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WhatYouGotDataAccess.Entities;
using WhatYouGotDataAccess.Repos;
using WhatYouGotLibrary.Interfaces;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace WhatYouGotAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string AllMyOrigins = "_allMyOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Looks for connection string from one of the .json files
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            // Register the database context
            services.AddDbContext<FridgeThingsDBContext>(options =>
                options.UseSqlServer(connectionString));

            // Register the repositories
            services.AddTransient<IAccountRepo, AccountRepo>();
            services.AddTransient<IFavoriteRepo, FavoriteRepo>();
            services.AddTransient<IIngredientRepo, IngredientRepo>();
            services.AddTransient<IInstructionRepo, InstructionRepo>();
            services.AddTransient<IRecipeRepo, RecipeRepo>();
            services.AddTransient<IReviewRepo, ReviewRepo>();

            
            //services.AddControllers();

            services.AddControllers(options =>
            {
                /*
                 By default, when the framework detects that the request is coming from a browser:
                        The Accept header is ignored. The content is returned in JSON, unless otherwise configured*/
                options.RespectBrowserAcceptHeader = true; // false by default
            });




            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Fridge Things API", Version = "v1" });
            });






            
            services.AddCors(options =>
            {
                options.AddPolicy(AllMyOrigins, b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            
            /*
            
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin();
                });
                options.AddPolicy(AllMyOrigins, builder =>
                {
                    builder.WithOrigins("http://localhost:44363")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            */
            

            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            
            var swaggerOptions = new SwaggerOptions();

            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(options =>
            {
                options.RouteTemplate = swaggerOptions.JsonRoute;
            });
            


            app.UseSwaggerUI(options =>
            {
                //options.SwaggerEndpoint("/swagger/v1/swagger.json", swaggerOptions.Description);
                options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });
            


            app.UseCors(AllMyOrigins);
            

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
