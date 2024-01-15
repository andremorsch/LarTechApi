using LarTechAPi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LarTechApi.XUnitTests.Infrastructure.Context
{
    public class DatabaseTestInMemory
    {
        public static ApplicationDbContext GetDatabase()
        {
            var name = Guid.NewGuid().ToString();
            return GetDatabase(name);
        }

        private static ApplicationDbContext GetDatabase(string name)
        {
            var inMemoryOption = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(name).Options;

            return new ApplicationDbContext(inMemoryOption);
        }
    }
}
