using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TfGM_API_Wrapper.Models.Resources;
using static System.AppDomain;

namespace TfGM_API_Wrapper;

/// <summary>
/// Builds and configures the application
/// </summary>
public class Startup
{
    /// <summary>
    /// Generates application builder using appSettings JSON.
    /// </summary>
    public Startup()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(CurrentDomain.BaseDirectory)
            .AddJsonFile("appSettings.json", true, true);

        Configuration = builder.Build();
    }

    private IConfiguration Configuration { get; }
    
    /// <summary>
    /// Method called by runtime, used to add services to the container
    /// </summary>
    /// <param name="services">Services for the Container</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();
        services.Configure<ResourcesConfig>(Configuration.GetSection("Resources"));
        services.AddControllers();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TfGM API Wrapper", Version = "v1" });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
            c.EnableAnnotations();
        });
    }
    
    /// <summary>
    /// Configures HTTP request pipeline
    /// </summary>
    /// <param name="app">App being built</param>
    /// <param name="env">Host Environment being used.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TfGM_API_Wrapper v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}