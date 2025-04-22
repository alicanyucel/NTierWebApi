using Microsoft.EntityFrameworkCore;
using NTier.Repositories.EFCore.Context;

namespace NTier.WebApi.Extensions;

public static class ServicesExxtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services,IConfiguration configuration)=> services.AddDbContext<RepositoryContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
    
}
