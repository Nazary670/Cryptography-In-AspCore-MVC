using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cryptography.Persistence.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] arg)
        =>
            new(new DbContextOptionsBuilder<ApplicationDbContext>().
                UseSqlServer("Server=.;Database=Cryptography_Db;Trusted_Connection=True;TrustServerCertificate=True").Options);
}
