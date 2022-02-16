using App.CooperShip.Infra.AutoMapper;
using App.CooperShip.Infra.Configurations.Settings;
using App.CooperShip.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace App.CooperShip.Api;

public class Startup
{
    public IConfiguration Configuration { get; }   
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();  
        services.AddMvc();
        services.RegisterServices();
        services.RegisterAutoMapper();

        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection")),
             ServiceLifetime.Transient);

        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "UnitOfWork",
                Version = "v1",
                Description = "Estudo UnitOrWork",
                Contact = new OpenApiContact
                {
                    Name = "Esveraldo Martins",
                    Email = "esveraldo@hotmail.com",
                    Url = new Uri("http://way8.com.br")
                },

                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://opensource.org/licences/MIT")
                }
            }); ;
        });

        services.Configure<VooSettings>(Configuration.GetSection(VooSettings.SessionName));
        services.AddSingleton(s => s.GetRequiredService<IOptions<VooSettings>>().Value);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UnitOrWork - v1"));

        app.UseHttpsRedirection();        
        app.UseRouting();
        app.UseAuthentication();    
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

    }
}