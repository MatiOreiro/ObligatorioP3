
using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaAccesoDatos;
using Obligatorio.LogicaAccesoDatos.Repositorios;
using Obligatorio.LogicaAplicacion.CasosUso.CUEnvio;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEnvio;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            // Configurar la cadena de conexión (desde appsettings.json)
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection debe coincidir con el nombre designado en el JSON.
            // Registrar el DbContext en el contenedor de servicios
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();

            builder.Services.AddScoped<ICUObtenerEnvioPorTracking, CUObtenerEnvioPorTracking>();
            builder.Services.AddScoped<ICUObtenerComentarios, CUObtenerComentarios>();



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
