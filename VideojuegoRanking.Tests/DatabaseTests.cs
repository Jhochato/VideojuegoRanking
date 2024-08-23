using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideojuegoRanking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace VideojuegoRanking.Tests
{
    public class DatabaseTests
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DatabaseTests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=ALUCARDV82\\SQLEXPRESS;Database=Celsia_Prueba;TrustServerCertificate=True;Trusted_Connection=True;"));
            _scopeFactory = serviceCollection.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();
        }

        [Fact]
        public async Task TestDatabaseConnection()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var canConnect = await context.Database.CanConnectAsync();
                Assert.True(canConnect, "No se pudo conectar a la base de datos.");
            }
        }
    }
}
