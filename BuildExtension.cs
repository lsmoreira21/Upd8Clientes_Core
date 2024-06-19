using Microsoft.EntityFrameworkCore;
using Upd8Clientes_Core.Data;
using Swashbuckle.AspNetCore;

namespace Upd8Clientes_Core
{
    public static class BuildExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            Configuration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddDbContext<ClienteContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddEndpointsApiExplorer();

            builder
                .Services
                .AddSwaggerGen();

            builder
                .Services
                .AddDatabaseDeveloperPageExceptionFilter();

            builder
                .Services
                .AddMvc();

            builder
                .Services
                .AddControllersWithViews();
        }
    }
}
