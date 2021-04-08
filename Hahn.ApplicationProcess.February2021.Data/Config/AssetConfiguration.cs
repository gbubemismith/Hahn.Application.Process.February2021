using Hahn.ApplicationProcess.February2021.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.ApplicationProcess.February2021.Data.Config
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).ValueGeneratedOnAdd();


            builder.Property(p => p.AssetName).IsRequired().HasMaxLength(255);

            builder.Property(p => p.Department)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasConversion<string>();

            builder.Property(p => p.CountryOfDepartment).IsRequired().HasMaxLength(255);
            builder.Property(p => p.EMailAdressOfDepartment).IsRequired();
            builder.Property(p => p.PurchaseDate).IsRequired();
            builder.Property(p => p.broken).IsRequired();





        }
    }
}