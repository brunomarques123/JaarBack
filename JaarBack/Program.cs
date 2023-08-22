using JaarBack.Data;
using JaarBack.Repositories;
using JaarBack.Services;
using Microsoft.EntityFrameworkCore;


class Program
{
    static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));

                services.AddScoped<IVeiculoRepository, VeiculoRepository>();
                services.AddScoped<IVeiculoService, VeiculoService>();

                services.AddControllers();
            });
}