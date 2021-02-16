using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Qorus.Assessment.Data.Data;
using System;

namespace Qorus.Assessment.Data.Contexts
{
    public class MockContext
    {
        public static void ConfigureMockContext(IServiceCollection services)
        {
            // Create a new service provider.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            services.AddDbContext<SqlContext>(options =>
            {
                options.UseInMemoryDatabase("TestStartupTesting");
                options.EnableSensitiveDataLogging();
                options.UseInternalServiceProvider(serviceProvider);
            });

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<SqlContext>();
                var logger = scopedServices
                    .GetRequiredService<ILogger<MockContext>>();

                // Ensure the database is created.
                db.Database.EnsureCreated();

                try
                {
                    // Seed the database with test data.
                    MockData.SeedTestData(db);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the " +
                        $"database with test messages. Error: {ex.Message}");
                }
            }
        }
    }
}
