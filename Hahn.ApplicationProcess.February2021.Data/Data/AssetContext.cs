using System.Reflection;
using Hahn.ApplicationProcess.February2021.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicationProcess.February2021.Data.Data
{
    public class AssetContext : DbContext
    {
        public AssetContext(DbContextOptions<AssetContext> options) : base(options)
        {

        }

        public DbSet<Asset> Assets { get; set; }

        //use with a real db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}