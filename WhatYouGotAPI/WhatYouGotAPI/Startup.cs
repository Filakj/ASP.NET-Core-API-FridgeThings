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

namespace WhatYouGotAPI
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
