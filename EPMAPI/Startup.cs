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
using EPM.API.Data;
using EPM.API.Repository;
using EPM.API.Repository.IRepository;
using AutoMapper;
using EPM.API.EPMMapper;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using Microsoft.AspNetCore.Routing;


namespace EPM.API
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
            services.AddDbContext<ApplicationDbContext>
               (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();           
            services.AddAutoMapper(typeof(EPMMappings));

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
            var appSettingsSection = Configuration.GetSection("AppSettings");

           services.Configure<AppSettings>(appSettingsSection);


           // services.Configure<RouteOptions>(options =>
           //  {
           //      options.ConstraintMap.Add("constraintname", typeof(ConstraintType));
           //  });

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

          //  services.AddControllersWithViews();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var desc in provider.ApiVersionDescriptions)
                    options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json",
                        desc.GroupName.ToUpperInvariant());
                options.RoutePrefix = "";
            });
            app.UseRouting();
            app.UseCors(x => x
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
            //    if (env.IsDevelopment())
            //    {
            //        app.UseDeveloperExceptionPage();
            //    }

            //    app.UseHttpsRedirection();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(options =>
            //    {
            //        foreach (var desc in provider.ApiVersionDescriptions)
            //            options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json",
            //                desc.GroupName.ToUpperInvariant());
            //        options.RoutePrefix = "";
            //    });

            //    //app.UseSwaggerUI(options=> {
            //    //    options.SwaggerEndpoint("/swagger/EPMOpenAPISpec/swagger.json", "EPM API");
            //    //    //options.SwaggerEndpoint("/swagger/EPMOpenAPISpecClients/swagger.json", "EPM API Clients");
            //    //    options.RoutePrefix = "";
            //    //});

            //    app.UseRouting();
            //    app.UseCors(x => x
            //      .AllowAnyOrigin()
            //      .AllowAnyMethod()
            //      .AllowAnyHeader());
            //    app.UseAuthentication();
            //    app.UseAuthorization();

            //    app.UseEndpoints(endpoints =>
            //    {
            //        endpoints.MapControllers();
            //    });
            //}
        }
}
