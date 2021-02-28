using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Natedpalm.Blog.Infrastructure.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseMySql(
                    "server=db;Database=blog;user=root;password=iheartdogs123!",
                    new MySqlServerVersion(new Version(8, 0, 21)));
        return new AppDbContext(optionsBuilder.Options);
    }
}