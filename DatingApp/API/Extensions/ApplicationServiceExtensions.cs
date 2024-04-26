using Microsoft.EntityFrameworkCore;

namespace API;

public static class ApplicationServiceExtensions
{   
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
    IConfiguration config)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(opt=> 
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRepostory, UserRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }

}
