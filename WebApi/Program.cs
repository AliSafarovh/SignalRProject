using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Business.DependencyResolvers.Mappers;
using WebApi.Hubs;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(opt => 
            { 
                opt.AddPolicy("CorsPolicy",builder=>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials(); 
                });
            });
            builder.Services.AddSignalR();
            // Add services to the container.
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });

            // AutoMapper ?lav? edin
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddControllers();

            // Swagger/OpenAPI konfiqurasiyasý
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // HTTP sorðularý üçün pipeline t?nziml?m?si
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("CorsPolicy");    
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.MapHub<SignalRHub>("/signalrgub");
            app.Run();
        }
    }
}
