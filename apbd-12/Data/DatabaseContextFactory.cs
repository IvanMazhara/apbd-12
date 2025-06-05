using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using apbd_12.Data;

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Apbd12Db;Trusted_Connection=True;");

        return new DatabaseContext(optionsBuilder.Options);
    }
}