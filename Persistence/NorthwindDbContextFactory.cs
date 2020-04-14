using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Northwind.Persistence
{
    public class NorthwindDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options);
        }
    }
}
